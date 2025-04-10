import express, { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";
import mysql, { RowDataPacket } from "mysql2";
import { AuthenticatedRequest, User } from "../../interfaces/User";
import { Car } from "../../interfaces/Car";
import { getLocationByParam } from "./location";

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

    const imageRows = await db.query<RowDataPacket>(
      `SELECT image_url FROM car_images WHERE car_id = ?`,
      [carId]
    );

    const imageUrls = imageRows.map(
      (row) => row.image_url.split("uploads/cars/")[1]
    );

    if (availableRows && (availableRows as RowDataPacket).available_to) {
      rows["available_to"] = (availableRows as RowDataPacket).available_to;
      rows["car_owner"] = (availableRows as RowDataPacket).user_id;
      rows["images"] = imageUrls as unknown as string;
    }

    const locationName = await getLocationByParam(Number(rows["location_id"])?.toString());

    rows["location_id"] = locationName ? (locationName as unknown as { location_id: number, location: string }).location : "Location not found";
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

export const getRentHistory = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const userId = (req as AuthenticatedRequest).user.user_id;

    if (!userId) {
      res.status(401).json({ error: "User not authenticated" });
      return;
    }

    const rentHistory = await db.query(
      `
      SELECT o.orders_id, o.car_id, c.car_brand, c.car_model, 
             o.start_date, o.end_date, o.rental_status, o.payment_status,
             COALESCE(po.amount, i.payment_amount) as amount
      FROM orders o
      INNER JOIN car c ON o.car_id = c.car_id
      LEFT JOIN payment_orders po ON o.car_id = po.car_id AND o.user_id = po.user_id
      LEFT JOIN invoice i ON o.orders_id = i.orders_id
      WHERE o.user_id = ?
      ORDER BY o.start_date DESC
      `,
      [userId]
    );

    if (Array.isArray(rentHistory)) {
      const formattedHistory = rentHistory.map((rental) => {
        return typeof rental === "object" && rental !== null ? { ...rental } : {};
      });

      res.status(200).json(formattedHistory);
    } else {
      res.status(200).json([]);
    }
  } catch (error) {
    console.error("Error fetching rent history:", error);
    res.status(500).json({ error: "Failed to fetch rent history" });
  }
};