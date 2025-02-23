import express, { Request, Response } from "express";
import db from "../../db/connection";
import jwt from "jsonwebtoken";

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

    const { id, email, username } = decoded as {
      id: number;
      email: string;
      username: string;
    };

    const [user] = await db.query<
      { id: number; email: string; username: string }[]
    >(
      "SELECT * FROM user WHERE user_id = ? AND user_email = ? AND user_name = ?",
      [id, email, username]
    );

    if (!user || user.length === 0) {
      res.status(401).json({ error: "Invalid authentication" });
      return;
    }

    res.status(200).json({
      user: {
        id,
        email,
        username,
      },
    });
  } catch (error) {
    console.error("Error verifying user:", error);
    res.status(500).json({ error: "Internal server error" });
  }
};
