import express, { Request, Response } from "express";
import db from "../../db/connection";
import { RowDataPacket } from "mysql2";
import { Car } from "../../interfaces/Car";

export const carsHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const rows = await db.query<Car>("SELECT * FROM car WHERE car_active = 1");
    res.json(rows);
  } catch (error) {
    console.error("Error fetching cars:", error);
    res.status(500).json({ error: "Failed to fetch cars" });
  }
};

import path from "path";
import fs from "fs";

export const getCarImage = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const { car_id } = req.query;

    if (!car_id) {
      res.status(400).json({ error: "car_id is required" });
      return;
    }

    const [rows] = await db.query<RowDataPacket>(
      `SELECT image_url FROM car_images WHERE car_id = ? LIMIT 1`,
      [car_id]
    );

    if (rows.length === 0) {
      res.status(404).json({ error: "No image found for this car" });
      return;
    }

    const imagePath = path.resolve(rows.image_url);

    if (!fs.existsSync(imagePath)) {
      res.status(404).json({ error: "Image file not found" });
      return;
    }

    res.sendFile(imagePath);
  } catch (error) {
    console.error("Error fetching car image:", error);
    res.status(500).json({ error: "Failed to fetch car image" });
  }
};
