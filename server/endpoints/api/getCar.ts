import express, { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";
import mysql, { RowDataPacket } from "mysql2";
import { AuthenticatedRequest, User } from "../../interfaces/User";
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

    const [availableRows] = await db.query<RowDataPacket>(
      `
      SELECT 
        c.car_id, 
        c.car_model, 
        c.car_brand, 
        c.car_type, 
        c.car_price,
        ca.available_to,
        cu.user_id
      FROM 
        car c
      JOIN 
        car_user cu ON cu.car_id = c.car_id
      LEFT JOIN 
        car_availability ca ON c.car_id = ca.car_id
      WHERE 
        c.car_id = ?
    `,
      [carId]
    );

    if (availableRows && (availableRows as RowDataPacket).available_to) {
      rows["available_to"] = (availableRows as RowDataPacket).available_to;
      rows["car_owner"] = (availableRows as RowDataPacket).user_id;
    }
    res.json(rows);
  } catch (error) {
    console.error("Error fetching cars:", error);
    res.status(500).json({ error: "Failed to fetch cars" });
  }
};

export const getCars = async (req: Request, res: Response): Promise<void> => {
  const id = (req as AuthenticatedRequest).user.user_id;

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

export const getRentedCars = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const userId = (req as AuthenticatedRequest).user.user_id;

    if (!userId) {
      res.status(401).json({ error: "User not authenticated" });
      return;
    }

    const rentedCars = await db.query(
      `
      SELECT DISTINCT car.*
      FROM car
      INNER JOIN orders ON car.car_id = orders.car_id
      WHERE orders.user_id = ?
      ORDER BY orders.start_date DESC
    `,
      [userId]
    );

    if (Array.isArray(rentedCars)) {
      const formattedCars = rentedCars.map((car) => {
        return typeof car === "object" && car !== null ? { ...car } : {};
      });

      res.status(200).json(formattedCars);
    } else {
      res.status(200).json([]);
    }
  } catch (error) {
    console.error("Error fetching rented cars:", error);
    res.status(500).json({ error: "Failed to fetch rented cars" });
  }
};
