import { NextFunction, Request, Response } from "express";
import fs from "fs";
import { check, validationResult } from "express-validator";
import { ResultSetHeader, RowDataPacket } from "mysql2";
import db from "../../db/connection";
import { Car } from "../../interfaces/Car";
import { AuthenticatedRequest } from "../../interfaces/User";

export const uploadCar = async (
  req: Request,
  res: Response,
  next: NextFunction
): Promise<void> => {
  try {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      if (req.files && Array.isArray(req.files)) {
        req.files.forEach((file: Express.Multer.File) => {
          fs.unlinkSync(file.path);
        });
      }
      res.status(400).json({ errors: errors.array() });
      return;
    }

    const userId = (req as AuthenticatedRequest).user.user_id;

    const {
      car_brand: brand,
      car_model: model,
      car_condition: condition,
      car_year: year,
      car_type: carType,
      fuel_type: fuelType,
      transmission_type: transmissionType,
      car_regnumber: regNumber,
      seats,
      number_of_doors: doors,
      price_per_hour: pricePerHour,
      price_per_day: pricePerDay,
      car_description: description,
    } = req.body as Car;

    console.log({
      brand,
      model,
      condition,
      year,
      carType,
      fuelType,
      transmissionType,
      regNumber,
      seats,
      doors,
      pricePerHour,
      pricePerDay,
      description,
    });

    const pool = db.pool;
    const connection = await pool.getConnection();
    await connection.beginTransaction();

    try {
      const [insuranceRows] = await connection.query<RowDataPacket[]>(
        "SELECT insurance_id FROM insurance LIMIT 1"
      );

      if (insuranceRows.length === 0) {
        throw new Error(
          "No default insurance found. Please set up an insurance plan first."
        );
      }

      const insuranceId = insuranceRows[0].insurance_id;

      const [carResult] = await connection.query<ResultSetHeader>(
        `INSERT INTO car (
              car_brand, 
              car_model, 
              car_condition, 
              car_year, 
              car_type, 
              fuel_type, 
              transmission_type, 
              car_regnumber, 
              seats, 
              number_of_doors, 
              price_per_hour, 
              price_per_day, 
              car_description,
              insurance_id,
              car_price,
              mileage
            ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`,
        [
          brand,
          model,
          condition,
          year,
          carType,
          fuelType,
          transmissionType,
          regNumber,
          seats,
          doors,
          pricePerHour,
          pricePerDay,
          description,
          insuranceId,
          (pricePerDay * 7).toString(),
          0,
        ]
      );

      const carId = carResult.insertId;

      await connection.query(
        "INSERT INTO car_user (car_id, user_id) VALUES (?, ?)",
        [carId, userId]
      );

      if (req.files && Array.isArray(req.files) && req.files.length > 0) {
        const imageInsertPromises = req.files.map(
          (file: Express.Multer.File) => {
            const imagePath = file.path.replace(/\\/g, "/");

            return connection.query(
              "INSERT INTO car_images (car_id, image_url, uploaded_at) VALUES (?, ?, NOW())",
              [carId, imagePath]
            );
          }
        );

        await Promise.all(imageInsertPromises);
      }

      const now = new Date();
      const oneYearLater = new Date();
      oneYearLater.setFullYear(now.getFullYear() + 1);

      await connection.query(
        "INSERT INTO car_availability (car_id, available_from, available_to) VALUES (?, ?, ?)",
        [carId, now, oneYearLater]
      );

      await connection.commit();

      res.status(201).json({
        success: true,
        message: "Car uploaded successfully",
        carId,
      });
    } catch (error) {
      await connection.rollback();

      if (req.files && Array.isArray(req.files)) {
        req.files.forEach((file: Express.Multer.File) => {
          fs.unlinkSync(file.path);
        });
      }

      throw error;
    } finally {
      connection.release();
    }
  } catch (error) {
    console.error("Error uploading car:", error);

    if ((error as any).code === "ER_DUP_ENTRY") {
      res.status(400).json({
        success: false,
        error: "A car with this registration number already exists.",
        field: "regNumber",
      });
      return;
    }
    res.status(400).json({
      success: false,
      error:
        (error as Error).message ||
        "An error occurred while uploading the car.",
    });
    return;
  }
};
