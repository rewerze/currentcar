import { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";
import { User } from "../../interfaces/User";

export const loginHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  const { email, password } = req.body;

  if (!email || !password) {
    res.status(400).json({ error: "Email and password are required" });
    return;
  }

  try {
    const userRows = await db.query<User>(
      "SELECT * FROM user WHERE user_email = ?",
      [email]
    );

    if (userRows.length === 0) {
      res.status(400).json({ error: "Hibás adatok" });
      return;
    }

    const user = userRows[0];

    const validPassword = await bcrypt.compare(password, user.password);

    if (!validPassword) {
      res.status(400).json({ error: "Hibás adatok" });
      return;
    }

    if (!process.env.SECRET_KEY) {
      res.status(500).json({
        error: "Secret key not defined. Please contact an administrator",
      });
      return;
    }

    const token = jwt.sign(user, process.env.SECRET_KEY, { expiresIn: "24h" });

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
    console.error("Error logging in:", error);
    res.status(500).json({ error: "Internal server error" });
    return;
  }
};
