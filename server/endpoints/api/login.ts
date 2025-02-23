import { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";

interface AuthenticatedRequest extends Request {
  user?: any;
}

export const loginHandler = async (
  req: AuthenticatedRequest,
  res: Response
): Promise<void> => {
  const { email, password } = req.body;

  if (!email || !password) {
    res.status(400).json({ error: "Email and password are required" });
    return;
  }

  try {
    const userRows = await db.query<{
      user_id: number;
      user_email: string;
      user_name: string;
      password: string;
    }>("SELECT * FROM user WHERE user_email = ?", [email]);

    if (userRows.length === 0) {
      res.status(400).json({ error: "Invalid credentials" });
      return;
    }

    const user = userRows[0];

    const validPassword = await bcrypt.compare(password, user.password);

    if (!validPassword) {
      res.status(400).json({ error: "Invalid credentials" });
      return;
    }

    if (!process.env.SECRET_KEY) {
      res.status(500).json({
        error: "Secret key not defined. Please contact an administrator",
      });
      return;
    }

    const token = jwt.sign(
      { id: user.user_id, email: user.user_email, username: user.user_name },
      process.env.SECRET_KEY,
      { expiresIn: "24h" }
    );

    res.cookie("auth_token", token, {
      domain:
        process.env.NODE_ENV === "production" ? "pantheonmacro.store" : "",
      httpOnly: true,
      secure: process.env.NODE_ENV === "production",
      maxAge: 24 * 60 * 60 * 1000,
      sameSite: "lax",
    });

    res.status(200).json({
      user: {
        id: user.user_id,
        email: user.user_email,
        username: user.user_name,
      },
      token,
    });
  } catch (error) {
    console.error("Error logging in:", error);
    res.status(500).json({ error: "Internal server error" });
    return;
  }
};
