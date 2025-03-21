import express, { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";
import mysql from "mysql2";
import { User } from "../../interfaces/User";

export const registerHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  const { email, password, username, bornDate } = req.body;

  if (!email || !password || !username) {
    res.status(400).json({ error: "All fields are required" });
    return;
  }

  try {
    const existingUsers = await db.query<User[]>(
      "SELECT * FROM user WHERE user_email = ? OR user_name = ?",
      [email, username]
    );

    if (existingUsers.length > 0) {
      res.status(400).json({ error: "Email or username is already taken" });
      return;
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const formattedDate = new Date(bornDate)
      .toISOString()
      .slice(0, 19)
      .replace("T", " ");

    const now = new Date().toISOString().slice(0, 19).replace("T", " ");

    const [result] = await db.pool.execute<mysql.ResultSetHeader>(
      "INSERT INTO user (user_email, password, user_name, born_at, created_at, updated_at) VALUES (?, ?, ?, ?, ?, ?)",
      [email, hashedPassword, username, formattedDate, now, now]
    );

    const id = result.insertId;

    const userRows = await db.query<User>(
      "SELECT * FROM user WHERE user_email = ?",
      [email]
    );

    if (userRows.length === 0) {
      res.status(400).json({ error: "Invalid credentials" });
      return;
    }

    const user = userRows[0];

    const token = jwt.sign(
      user,
      process.env.SECRET_KEY!,
      {
        expiresIn: "24h",
      }
    );

    res.cookie("auth_token", token, {
      domain: process.env.NODE_ENV === "production" ? "beniary.com" : "",
      httpOnly: true,
      secure: process.env.NODE_ENV === "production",
      maxAge: 24 * 60 * 60 * 1000,
      sameSite: "lax",
    });

    res.status(200).json({
      user: user,
      token,
    });
  } catch (error) {
    console.error("Error registering user:", error);
    res.status(500).json({ error: "Internal server error" });
  }
};
