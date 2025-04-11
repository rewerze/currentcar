import express, { Request, Response } from "express";
import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import db from "../../db/connection";
import mysql from "mysql2";
import { User } from "../../interfaces/User";
import { Car } from "../../interfaces/Car";

export const carsSearchHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const page = parseInt(req.query.page as string) || 1;
    const limit = parseInt(req.query.limit as string) || 12;
    const offset = (page - 1) * limit;

    let query = "SELECT * FROM car WHERE car_active = 1";
    let countQuery = "SELECT COUNT(*) as total FROM car WHERE car_active = 1";
    const params: any[] = [];
    const countParams: any[] = [];

    if (req.query.q) {
      const searchCondition =
        " AND (car_brand LIKE ? OR car_model LIKE ? OR car_description LIKE ?)";
      query += searchCondition;
      countQuery += searchCondition;

      const searchTerm = `%${req.query.q}%`;
      params.push(searchTerm, searchTerm, searchTerm);
      countParams.push(searchTerm, searchTerm, searchTerm);
    }

    const filters = {
      car_brand: req.query.brand,
      car_type: req.query.type,
      car_condition: req.query.condition,
      transmission_type: req.query.transmission,
      fuel_type: req.query.fuel,
      car_year: req.query.year,
    };

    Object.entries(filters).forEach(([key, value]) => {
      if (value) {
        const filterCondition = ` AND ${key} = ?`;
        query += filterCondition;
        countQuery += filterCondition;

        params.push(value);
        countParams.push(value);
      }
    });

    query += " LIMIT ? OFFSET ?";
    params.push(limit, offset);

    const [rows, countResult] = await Promise.all([
      db.query<Car>(query, params),
      db.query<{ total: number }>(countQuery, countParams),
    ]);

    const total = countResult[0]?.total || 0;
    const totalPages = Math.ceil(total / limit);

    res.json({
      data: rows,
      pagination: {
        total,
        totalPages,
        currentPage: page,
        limit,
      },
    });
  } catch (error) {
    console.error("Error searching cars:", error);
    res.status(500).json({ error: "Failed to search cars" });
  }
};
