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

    const { id, email, username } = decoded as {
      id: number;
      email: string;
      username: string;
    };

    const userRows = await db.query<User>(
      "SELECT * FROM user WHERE user_id = ? AND user_email = ? AND user_name = ?",
      [id, email, username]
    );

    if (!userRows || userRows.length === 0) {
      res.status(401).json({ error: "Invalid authentication" });
      return;
    }

    const user = userRows[0];

    res.status(200).json({
      user: {
        id: user.user_id,
        email: user.user_email,
        username: user.user_name,
        born_date: user.born_at,
        phone_number: user.phone_number,
        role: user.user_role,
        jogositvany_szam: user.driver_license_number,
        jogositvany_lejarat: user.driver_license_expiry,
      },
    });
  } catch (error) {
    console.error("Error verifying user:", error);
    res.status(500).json({ error: "Internal server error" });
  }
};
