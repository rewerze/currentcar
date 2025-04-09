import { Request, Response } from "express";
import { AuthenticatedRequest } from "../../interfaces/User";
import db from "../../db/connection";

export const getDepos = async (
    req: Request,
    res: Response
): Promise<void> => {
    try {
        if (!(req as AuthenticatedRequest).user) {
            res.status(401).json({ error: "User not authenticated" });
            return;
        }

        const userId = (req as AuthenticatedRequest).user.user_id;

        const deposits = await db.query<any>(
            "SELECT * FROM location",
            [userId]
        );

        if (!deposits || deposits.length === 0) {
            res.status(404).json({ error: "No deposits found" });
            return;
        }

        res.json(deposits);
    } catch (error) {
        console.error("Error fetching deposits:", error);
        res.status(500).json({ error: "Failed to fetch depos" });
    }
};