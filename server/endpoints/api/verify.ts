import express, { Request, Response } from "express";
import db from "../../db/connection";
import jwt from "jsonwebtoken";
import { User } from "../../interfaces/User";

export const verifyHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  const token = req.cookies.auth_token;

  if (!token) {
    res.status(401).json({ error: "No authentication token found" });
    return;
  }

  try {
    const decoded = jwt.verify(token, process.env.SECRET_KEY!);

    const { user_id, user_email, user_name } = decoded as {
      user_id: number;
      user_email: string;
      user_name: string;
    };

    if (user_id === undefined || user_email === undefined || user_name === undefined) {
      res.status(400).json({ error: "Invalid token payload" });
      return;
    }

    const userRows = await db.query<User>(
      "SELECT * FROM user WHERE user_id = ? AND user_email = ? AND user_name = ?",
      [user_id, user_email, user_name]
    );

    if (!userRows || userRows.length === 0) {
      res.status(401).json({ error: "Invalid authentication" });
      return;
    }

    const user = userRows[0];

    res.status(200).json({
      user: user,
    });
  } catch (error) {
    console.error("Error verifying user:", error);
    res.status(500).json({ error: "Internal server error" });
  }
};
