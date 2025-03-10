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
        let query = 'SELECT * FROM car WHERE car_active = 1';
        const params: any[] = [];

        // Add search query if provided
        if (req.query.q) {
            query += ' AND (car_brand LIKE ? OR car_model LIKE ? OR car_description LIKE ?)';
            const searchTerm = `%${req.query.q}%`;
            params.push(searchTerm, searchTerm, searchTerm);
        }

        // Add filters if provided
        const filters = {
            car_brand: req.query.brand,
            car_type: req.query.type,
            car_condition: req.query.condition,
            transmission_type: req.query.transmission,
            fuel_type: req.query.fuel,
            car_year: req.query.year
        };

        Object.entries(filters).forEach(([key, value]) => {
            if (value) {
                query += ` AND ${key} = ?`;
                params.push(value);
            }
        });

        const rows = await db.query<Car>(query, params);
        res.json(rows);
    } catch (error) {
        console.error('Error searching cars:', error);
        res.status(500).json({ error: 'Failed to search cars' });
    }

}