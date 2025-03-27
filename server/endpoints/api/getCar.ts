import express, { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";
import mysql from "mysql2";
import { User } from "../../interfaces/User";
import { Car } from "../../interfaces/Car";

export const carHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  const carId = req.query.id;

  if (!carId) {
    res.status(404).json({
      error: "Car not found!",
    });
    return;
  }

  try {
    const [rows] = await db.query<Car>(`SELECT * FROM car WHERE car_id = ?`, [
      carId,
    ]);
    res.json(rows);
  } catch (error) {
    console.error("Error fetching cars:", error);
    res.status(500).json({ error: "Failed to fetch cars" });
  }
};

interface AuthenticatedRequest extends Request {
  user?: any;
}

export const getCars = async (
  req: AuthenticatedRequest,
  res: Response
): Promise<void> => {
  const id = req.user.user_id;

  if (!id) {
    res.status(404).json({
      error: "User not found!",
    });
    return;
  }

  try {
    const rows: (Car & { images: string | null })[] = await db.query(
      `SELECT car.*, 
              GROUP_CONCAT(car_images.image_url) AS images
       FROM car
       JOIN car_user ON car.car_id = car_user.car_id
       LEFT JOIN car_images ON car.car_id = car_images.car_id
       WHERE car_user.user_id = ?
       GROUP BY car.car_id`,
      [id]
    );

    const formattedRows = rows.map((car) => ({
      ...car,
      images: car.images ? car.images.split(",") : [],
    }));

    res.json(rows);
  } catch (error) {
    console.error("Error fetching cars:", error);
    res.status(500).json({ error: "Failed to fetch cars" });
  }
};
