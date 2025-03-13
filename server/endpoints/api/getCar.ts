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
