import express, { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";
import mysql from "mysql2";
import { User } from "../../interfaces/User";
import { Car } from "../../interfaces/Car";

export const carsHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
        try {
          const rows = await db.query<Car>('SELECT * FROM car WHERE car_active = 1');
          res.json(rows);
        } catch (error) {
          console.error('Error fetching cars:', error);
          res.status(500).json({ error: 'Failed to fetch cars' });
        }
      
}