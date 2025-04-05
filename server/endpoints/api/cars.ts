import express, { Request, Response } from "express";
import db from "../../db/connection";
import { QueryResult, RowDataPacket } from "mysql2";
import { Car } from "../../interfaces/Car";

export const carsHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const rows = await db.query<Car>("SELECT * FROM car");
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

export const rentCar = async (req: Request, res: Response): Promise<void> => {
  const userId = (req as AuthenticatedRequest).user.user_id;

  const {
    car_id,
    start_date,
    end_date,
    pickup_location,
    payment_method,
    discount_code = "",
  } = req.body;

  if (
    !car_id ||
    !start_date ||
    !end_date ||
    !pickup_location ||
    !payment_method
  ) {
    res.status(400).json({ error: "Missing required fields" });
    return;
  }

  let connection;

  try {
    const pool = db.pool;
    connection = await pool.getConnection();

    await connection.beginTransaction();

    const [carRows] = await connection.query<RowDataPacket[]>(
      "SELECT * FROM car WHERE car_id = ?",
      [car_id]
    );

    if (carRows.length === 0) {
      await connection.rollback();
      res.status(400).json({ error: "Car is not available for rent" });
      return;
    }

    const [availabilityRows] = await connection.query<RowDataPacket[]>(
      "SELECT * FROM car_availability WHERE car_id = ? AND available_from <= ? AND available_to >= ?",
      [car_id, start_date, end_date]
    );

    if (availabilityRows.length === 0) {
      await connection.rollback();
      res
        .status(400)
        .json({ error: "Car is not available for the requested dates" });
      return;
    }

    const [locationResult] = await connection.query<RowDataPacket[]>(
      "INSERT INTO location (pickup_location, dropoff_location, longitude, latitude) VALUES (?, ?, ?, ?)",
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

    const taxRate = 0.1;
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
      [
        orderId,
        carDetails[0].insurance_id,
        paymentAmount,
        taxAmount,
        payment_method,
        "",
      ]
    );

    await connection.query("UPDATE car SET car_active = 0 WHERE car_id = ?", [
      car_id,
    ]);

    await connection.query(
      `INSERT INTO notifications (
        user_id,
        message,
        status,
        created_at
      ) VALUES (?, ?, 'unread', NOW())`,
      [
        userId,
        `Your car rental for ${carDetails[0].car_brand} ${carDetails[0].car_model} has been successfully booked.`,
      ]
    );

    const [queryResult] = await connection.query<RowDataPacket[]>(
      `SELECT * FROM car_user WHERE car_id = ?`,
      [car_id]
    );

    await connection.query(
      `INSERT INTO notifications (
        user_id,
        message,
        status,
        created_at
      ) VALUES (?, ?, 'unread', NOW())`,
      [
        userId,
        `Your car rental for ${carDetails[0].car_brand} ${carDetails[0].car_model} has been successfully booked.`,
      ]
    );

    await connection.query(
      `INSERT INTO notifications (
        user_id,
        message,
        status,
        created_at
      ) VALUES (?, ?, 'unread', NOW())`,
      [
        (queryResult as RowDataPacket[])[0].user_id,
        `Your car has been successfully rented out to a customer. The rental is for a ${carDetails[0].car_brand} ${carDetails[0].car_model}.`,
      ]
    );

    await connection.commit();

    res.status(201).json({
      success: true,
      message: "Car rental successful",
      data: {
        order_id: orderId,
        total_amount: totalAmount,
        payment_status: "pending",
        rental_details: {
          car: `${carDetails[0].car_brand} ${carDetails[0].car_model}`,
          start_date,
          end_date,
          pickup_location,
          dropoff_location: pickup_location,
        },
      },
    });
  } catch (error) {
    if (connection) {
      await connection.rollback();
    }

    console.error("Error during car rental:", error);
    res.status(500).json({
      success: false,
      message: "An error occurred during car rental",
      error: (error as any).message,
    });
  } finally {
    if (connection) {
      connection.release();
    }
  }
};

export const editCar = async (req: Request, res: Response): Promise<void> => {
  const userId = (req as AuthenticatedRequest).user?.user_id;
  const {
    car_id,
    car_price,
    car_description,
    car_type,
    seats,
    number_of_doors,
    insurance_id,
    car_model,
    car_regnumber,
    price_per_hour,
    price_per_day,
    car_condition,
    mileage,
    car_year,
    fuel_type,
    transmission_type,
    car_brand,
  } = req.body;

  if (!userId) {
    res.status(401).json({ error: "Unauthorized" });
    return;
  }

  if (!car_id) {
    res.status(400).json({ error: "Car ID is required" });
    return;
  }

  try {
    const [carOwnership] = await db.query(
      "SELECT * FROM car JOIN car_user ON car.car_id = car_user.car_id WHERE car.car_id = ? AND car_user.user_id = ?",
      [car_id, userId]
    );

    if (!carOwnership) {
      res
        .status(403)
        .json({ error: "You don't have permission to edit this car" });
      return;
    }

    const activeOrdersResult = await db.query(
      'SELECT * FROM orders WHERE car_id = ? AND rental_status IN ("pending", "confirmed", "extended")',
      [car_id]
    );

    if (Array.isArray(activeOrdersResult) && activeOrdersResult.length > 0) {
      res.status(400).json({ error: "Cannot edit car with active bookings" });
      return;
    }

    if (
      car_type &&
      ![
        "sedan",
        "suv",
        "hatchback",
        "convertible",
        "coupe",
        "wagon",
        "pickup",
        "minivan",
      ].includes(car_type)
    ) {
      res.status(400).json({ error: "Invalid car type" });
      return;
    }

    if (
      car_condition &&
      !["new", "excellent", "good", "fair", "poor"].includes(car_condition)
    ) {
      res.status(400).json({ error: "Invalid car condition" });
      return;
    }

    if (
      fuel_type &&
      !["petrol", "diesel", "electric", "hybrid", "gas"].includes(fuel_type)
    ) {
      res.status(400).json({ error: "Invalid fuel type" });
      return;
    }

    if (
      transmission_type &&
      !["automatic", "manual", "semi-automatic", "CVT"].includes(
        transmission_type
      )
    ) {
      res.status(400).json({ error: "Invalid transmission type" });
      return;
    }

    if (car_regnumber) {
      const existingCar = await db.query(
        "SELECT * FROM car WHERE car_regnumber = ? AND car_id != ?",
        [car_regnumber, car_id]
      );

      if (existingCar.length > 0) {
        res
          .status(409)
          .json({ error: "Registration number is already in use" });
        return;
      }
    }

    // Prepare update query
    const updateFields: string[] = [];
    const updateValues: any[] = [];

    if (car_price !== undefined) {
      updateFields.push("car_price = ?");
      updateValues.push(car_price);
    }

    if (car_description !== undefined) {
      updateFields.push("car_description = ?");
      updateValues.push(car_description);
    }

    if (car_type !== undefined) {
      updateFields.push("car_type = ?");
      updateValues.push(car_type);
    }

    if (seats !== undefined) {
      updateFields.push("seats = ?");
      updateValues.push(seats);
    }

    if (number_of_doors !== undefined) {
      updateFields.push("number_of_doors = ?");
      updateValues.push(number_of_doors);
    }

    if (insurance_id !== undefined) {
      updateFields.push("insurance_id = ?");
      updateValues.push(insurance_id);
    }

    if (car_model !== undefined) {
      updateFields.push("car_model = ?");
      updateValues.push(car_model);
    }

    if (car_regnumber !== undefined) {
      updateFields.push("car_regnumber = ?");
      updateValues.push(car_regnumber);
    }

    if (price_per_hour !== undefined) {
      updateFields.push("price_per_hour = ?");
      updateValues.push(price_per_hour);
    }

    if (price_per_day !== undefined) {
      updateFields.push("price_per_day = ?");
      updateValues.push(price_per_day);
    }

    if (car_condition !== undefined) {
      updateFields.push("car_condition = ?");
      updateValues.push(car_condition);
    }

    if (mileage !== undefined) {
      updateFields.push("mileage = ?");
      updateValues.push(mileage);
    }

    if (car_year !== undefined) {
      updateFields.push("car_year = ?");
      updateValues.push(car_year);
    }

    if (fuel_type !== undefined) {
      updateFields.push("fuel_type = ?");
      updateValues.push(fuel_type);
    }

    if (transmission_type !== undefined) {
      updateFields.push("transmission_type = ?");
      updateValues.push(transmission_type);
    }

    if (car_brand !== undefined) {
      updateFields.push("car_brand = ?");
      updateValues.push(car_brand);
    }

    if (updateFields.length === 0) {
      res.status(400).json({ error: "No update fields provided" });
      return;
    }

    // Add car_id for WHERE clause
    updateValues.push(car_id);

    const updateQuery = `
      UPDATE car 
      SET ${updateFields.join(", ")} 
      WHERE car_id = ?
    `;

    await db.query(updateQuery, updateValues);

    const [updatedCar] = await db.query(`SELECT * FROM car WHERE car_id = ?`, [
      car_id,
    ]);

    res.json({
      message: "Car updated successfully",
      car: updatedCar,
    });
  } catch (error) {
    console.error("Car update error:", error);
    res.status(500).json({ error: "Failed to update car information" });
  }
};

export const deleteCar = async (req: Request, res: Response): Promise<void> => {
  try {
    const carId = parseInt(req.body.id);
    const userId = (req as AuthenticatedRequest).user.user_id;

    if (!carId || isNaN(carId)) {
      res.status(400).json({ error: "Invalid car ID" });
      return;
    }

    const carOwnerResult = await db.query(
      "SELECT * FROM car_user WHERE car_id = ? AND user_id = ?",
      [carId, userId]
    );

    if (!Array.isArray(carOwnerResult) || carOwnerResult.length === 0) {
      res
        .status(403)
        .json({ error: "You do not have permission to deactivate this car" });
      return;
    }

    const activeOrdersResult = await db.query(
      'SELECT * FROM orders WHERE car_id = ? AND rental_status IN ("pending", "confirmed", "extended")',
      [carId]
    );

    if (Array.isArray(activeOrdersResult) && activeOrdersResult.length > 0) {
      res
        .status(400)
        .json({ error: "Cannot deactivate car with active bookings" });
      return;
    }

    const updateResult = await db.query(
      "UPDATE car SET car_active = 0 WHERE car_id = ?",
      [carId]
    );

    const affectedRows =
      updateResult && "affectedRows" in updateResult
        ? updateResult.affectedRows
        : 0;

    if (affectedRows === 0) {
      res.status(404).json({ error: "Car not found or already deactivated" });
      return;
    }

    res.status(200).json({ message: "Car deactivated successfully" });
  } catch (error) {
    console.error("Error deactivating car:", error);
    res.status(500).json({ error: "Failed to deactivate car" });
  }
};
