import express, { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";

export const registerHandler = async (req: Request, res: Response): Promise<void> => {
    const { email, password, username } = req.body;

    if (!email || !password || !username) {
        res.status(400).json({ error: "All fields are required" });
        return;
    }

    try {
        const [existingUser] = await db.query<{ id: number; email: string; username: string }[]>(
            "SELECT * FROM users WHERE email = ? OR username = ?",
            [email, username]
        );

        if (existingUser && existingUser.length > 0) {
            res.status(400).json({ error: "Email or username is already taken" });
            return;
        }

        const hashedPassword = await bcrypt.hash(password, 10);

        const [result] = await db.query<{ insertId: number }>(
            "INSERT INTO users (email, password, username) VALUES (?, ?, ?)",
            [email, hashedPassword, username]
        );

        const id = result.insertId;

        const token = jwt.sign({ id, email, username }, process.env.SECRET_KEY!, {
            expiresIn: "24h",
        });

        res.cookie("auth_token", token, {
            domain: process.env.NODE_ENV === "production" ? "beniary.com" : "",
            httpOnly: true,
            secure: process.env.NODE_ENV === "production",
            maxAge: 24 * 60 * 60 * 1000,
            sameSite: "lax",
        });

        res.status(200).json({
            user: {
                id,
                email,
                username,
            },
            token,
        });
    } catch (error) {
        console.error("Error registering user:", error);
        res.status(500).json({ error: "Internal server error" });
    }
};