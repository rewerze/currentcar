import express, { Request, Response } from "express";
import db from "../../db/connection";
import { QueryResult, RowDataPacket } from "mysql2";
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
import { AuthenticatedRequest } from "../../interfaces/User";

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

export const rentCar = async (
  req: Request,
  res: Response
): Promise<void> => {
  const userId = (req as AuthenticatedRequest).user.user_id;

  const {
    car_id,
    start_date,
    end_date,
    pickup_location,
    payment_method,
    discount_code = ''
  } = req.body;

  if (!car_id || !start_date || !end_date || !pickup_location || !payment_method) {
    res.status(400).json({ error: 'Missing required fields' });
    return;
  }

  let connection;

  try {
    const pool = db.pool;
    connection = await pool.getConnection();

    await connection.beginTransaction();

    const [carRows] = await connection.query<RowDataPacket[]>(
      'SELECT * FROM car WHERE car_id = ? AND car_active = 1',
      [car_id]
    );

    if (carRows.length === 0) {
      await connection.rollback();
      res.status(400).json({ error: 'Car is not available for rent' });
      return;
    }

    const [availabilityRows] = await connection.query<RowDataPacket[]>(
      'SELECT * FROM car_availability WHERE car_id = ? AND available_from <= ? AND available_to >= ?',
      [car_id, start_date, end_date]
    );

    if (availabilityRows.length === 0) {
      await connection.rollback();
      res.status(400).json({ error: 'Car is not available for the requested dates' });
      return;
    }

    const [locationResult] = await connection.query<RowDataPacket[]>(
      'INSERT INTO location (pickup_location, dropoff_location, longitude, latitude) VALUES (?, ?, ?, ?)',
      [pickup_location, pickup_location, 0, 0]
    );

    const locationId = (locationResult as RowDataPacket).insertId;

    const [orderResult] = await connection.query(
      `INSERT INTO orders (
        user_id, 
        car_id, 
        start_date, 
        end_date, 
        rental_status, 
        location_id, 
        payment_status, 
        discount_code,
        extended_rental
      ) VALUES (?, ?, ?, ?, 'pending', ?, 'pending', ?, false)`,
      [userId, car_id, start_date, end_date, locationId, discount_code]
    );

    const orderId = (orderResult as RowDataPacket).insertId;

    const [carDetails]: any = await connection.query(
      `SELECT c.*, i.insurance_fee, i.insurance_id
       FROM car c
       JOIN insurance i ON c.insurance_id = i.insurance_id
       WHERE c.car_id = ?`,
      [car_id]
    );

    const startDate = new Date(start_date).getTime();
    const endDate = new Date(end_date).getTime();
    const durationMs = endDate - startDate;
    const durationDays = Math.ceil(durationMs / (1000 * 60 * 60 * 24));
    const durationHours = Math.ceil(durationMs / (1000 * 60 * 60));

    let paymentAmount = 0;
    if (durationDays <= 1) {
      paymentAmount = carDetails[0].price_per_hour * durationHours;
    } else {
      paymentAmount = carDetails[0].price_per_day * durationDays;
    }

    paymentAmount += parseFloat(carDetails[0].insurance_fee);

    const taxRate = 0.10;
    const taxAmount = paymentAmount * taxRate;
    const totalAmount = paymentAmount + taxAmount;

    const [invoiceResult] = await connection.query(
      `INSERT INTO invoice (
        orders_id,
        insurance_id,
        payment_amount,
        tax_amount,
        payment_method,
        payment_status,
        payment_date,
        invoice_address
      ) VALUES (?, ?, ?, ?, ?, 'pending', NOW(), ?)`,
      [orderId, carDetails[0].insurance_id, paymentAmount, taxAmount, payment_method, '']
    );

    await connection.query(
      'UPDATE car SET car_active = 0 WHERE car_id = ?',
      [car_id]
    );

    await connection.query(
      `INSERT INTO notifications (
        user_id,
        message,
        status,
        created_at
      ) VALUES (?, ?, 'unread', NOW())`,
      [userId, `Your car rental for ${carDetails[0].car_brand} ${carDetails[0].car_model} has been successfully booked.`]
    );

    await connection.commit();

    res.status(201).json({
      success: true,
      message: 'Car rental successful',
      data: {
        order_id: orderId,
        total_amount: totalAmount,
        payment_status: 'pending',
        rental_details: {
          car: `${carDetails[0].car_brand} ${carDetails[0].car_model}`,
          start_date,
          end_date,
          pickup_location,
          dropoff_location: pickup_location
        }
      }
    });

  } catch (error) {
    if (connection) {
      await connection.rollback();
    }

    console.error('Error during car rental:', error);
    res.status(500).json({
      success: false,
      message: 'An error occurred during car rental',
      error: (error as any).message
    });
  } finally {
    if (connection) {
      connection.release();
    }
  }
}