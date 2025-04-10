import { Request, Response } from "express";
import db from "../../db/connection";

export const getLocationById = async (
    req: Request,
    res: Response
): Promise<void> => {
    try {
        const { locationId } = req.query;

        if (!locationId) {
            res.status(400).json({ error: "Location ID is required" });
            return;
        }

        const location = await db.query(
            "SELECT * FROM location WHERE location_id = ?",
            [locationId]
        );

        if (location.length === 0) {
            res.status(404).json({ error: "Location not found" });
            return;
        }

        res.json(location[0]);
    } catch (error) {
        console.error("Error fetching location:", error);
        res.status(500).json({ error: "Failed to fetch location" });
    }
}

export const getLocationByParam = async (id: string): Promise<string | undefined> => {
    try {

        if (!id) {
            return "missing id";
        }

        const location = await db.query(
            "SELECT * FROM location WHERE location_id = ?",
            [id]
        );

        if (location.length === 0) {
            return "location not found";
        }

        return location[0] as string | undefined;
    } catch (error) {
        console.error("Error fetching location:", error);
    }
}

export const getLocationByName = async (name: string): Promise<string | undefined> => {
    try {
        if (!name) {
            return "missing id";
        }

        const location = await db.query(
            "SELECT * FROM location WHERE location = ?",
            [name]
        );

        if (location.length === 0) {
            return "location not found";
        }

        return location[0] as string | undefined;
    } catch (error) {
        console.error("Error fetching location:", error);
    }
}