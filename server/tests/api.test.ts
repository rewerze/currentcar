import request from "supertest";
import db from "../db/connection";
import { jest } from "@jest/globals";
import { NextFunction, Request, Response } from "express";
import { describe, beforeEach, afterEach, it, expect } from "@jest/globals";
import { app } from "../server";
import { RowDataPacket } from "mysql2";
import { Car } from "../interfaces/Car";

type MockResult<T> = [T[], any];
type MockUpdateResult = { affectedRows: number };

const mockDbQuery = jest.fn() as jest.MockedFunction<typeof db.query>;
(db.query as any) = mockDbQuery;

jest.mock("../db/connection", () => ({
  query: jest.fn(),
  pool: {
    getConnection: jest.fn(),
  },
}));

interface MockConnection {
  beginTransaction: jest.Mock;
  commit: jest.Mock;
  rollback: jest.Mock;
  release: jest.Mock;
  query: jest.Mock;
}

const mockUser = {
  user_id: 1,
  user_name: "Test User",
  user_email: "test@example.com",
  password: "$2a$10$someHashedPasswordString",
  born_at: "1990-01-01T00:00:00.000Z",
  created_at: "2023-01-01T00:00:00.000Z",
  updated_at: "2023-01-01T00:00:00.000Z",
  user_active: 1,
  u_phone_number: "1234567890",
  user_areacode: 12345,
  user_role: "user",
  driver_license_number: "DL12345",
  driver_license_expiry: "2025-12-31",
  profile_picture: "uploads/profiles/user1.jpg",
  user_iban: "DE89370400440532013000",
};

jest.mock("../middlewares/authToken", () => ({
  verifyAuthTokenMiddleware: jest.fn(
    (req: Request, res: Response, next: NextFunction) => {
      (req as any).user = mockUser;
      next();
    }
  ),
}));

describe("Car API Endpoints", () => {
  let mockConnection: any;

  beforeEach(() => {
    mockConnection = {
      beginTransaction: jest.fn().mockResolvedValue(undefined as never),
      commit: jest.fn().mockResolvedValue(undefined as never),
      rollback: jest.fn().mockResolvedValue(undefined as never),
      release: jest.fn().mockResolvedValue(undefined as never),
      query: jest.fn(),
    } as MockConnection;

    (db.pool.getConnection as jest.Mock).mockResolvedValue(
      mockConnection as never
    );
  });

  afterEach(() => {
    jest.clearAllMocks();
  });

  describe("carsHandler", () => {
    it("should fetch all cars successfully", async () => {
      const mockCars = [
        [
          [
            {
              car_id: 1,
              car_price: "25000",
              car_active: 1,
              location_id: 1,
              car_description: "A reliable sedan for daily commute",
              car_type: "sedan",
              seats: 5,
              number_of_doors: 4,
              insurance_id: 1,
              car_model: "Corolla",
              car_regnumber: "ABC123",
              price_per_hour: 10,
              price_per_day: 50,
              car_condition: "excellent",
              mileage: 15000,
              car_year: 2022,
              fuel_type: "petrol",
              transmission_type: "automatic",
              car_brand: "Toyota",
            },
            {
              car_id: 2,
              car_price: "30000",
              car_active: 1,
              location_id: 2,
              car_description: "Compact and fuel-efficient hatchback",
              car_type: "hatchback",
              seats: 5,
              number_of_doors: 5,
              insurance_id: 2,
              car_model: "Civic",
              car_regnumber: "XYZ789",
              price_per_hour: 12,
              price_per_day: 60,
              car_condition: "good",
              mileage: 20000,
              car_year: 2021,
              fuel_type: "hybrid",
              transmission_type: "CVT",
              car_brand: "Honda",
            },
          ],
          null,
        ],
        null,
      ];

      const mockResponse = [[mockCars, null], null];

      (db.query as jest.Mock).mockImplementationOnce(() =>
        Promise.resolve([mockCars, null])
      );

      const response = await request(app).get("/api/cars");

      expect(response.status).toBe(200);
      console.log(response.body);

      expect(Array.isArray(response.body)).toBe(true);

      expect(JSON.stringify(response.body)).toContain("Toyota");
      expect(JSON.stringify(response.body)).toContain("Honda");

      expect(db.query).toHaveBeenCalledWith("SELECT * FROM car");
    });

    it("should handle errors when fetching cars", async () => {
      const error = new Error("Database error");
      (db.query as jest.Mock).mockRejectedValueOnce(error as never);

      const response = await request(app).get("/api/cars");

      expect(response.status).toBe(500);
      expect(response.body).toEqual({ error: "Failed to fetch cars" });
    });
  });

  describe("carHandler", () => {
    it("should fetch a specific car by ID", async () => {
      const mockCar = [
        {
          car_id: 1,
          car_price: "25000",
          car_active: 1,
          location_id: 1,
          car_description: "A reliable sedan for daily commute",
          car_type: "sedan",
          seats: 5,
          number_of_doors: 4,
          insurance_id: 1,
          car_model: "Corolla",
          car_regnumber: "ABC123",
          price_per_hour: 10,
          price_per_day: 50,
          car_condition: "excellent",
          mileage: 15000,
          car_year: 2022,
          fuel_type: "petrol",
          transmission_type: "automatic",
          car_brand: "Toyota",
        },
      ];

      const mockAvailability = [
        {
          car_id: 1,
          available_from: "2023-01-01T00:00:00.000Z",
          available_to: "2025-12-31T00:00:00.000Z",
        },
      ];

      const mockImages = [
        {
          image_url: "uploads/cars/car1.jpg",
        },
        {
          image_url: "uploads/cars/car2.jpg",
        },
      ];

      const mockLocation = {
        location_id: 1,
        location: "New York",
        zip_code: 10001,
      };

      (db.query as jest.Mock)
        .mockImplementationOnce(() => Promise.resolve(mockCar))
        .mockImplementationOnce(() => Promise.resolve(mockAvailability))
        .mockImplementationOnce(() => Promise.resolve(mockImages));

      jest.mock("../endpoints/api/location", () => ({
        getLocationByParam: jest.fn().mockResolvedValue(mockLocation as never),
      }));

      const response = await request(app).get("/api/car").query({ id: "1" });

      expect(response.status).toBe(200);
      expect(db.query).toHaveBeenCalledWith(
        "SELECT * FROM car WHERE car_id = ?",
        ["1"]
      );
    });

    it("should return 404 when car ID is not provided", async () => {
      const response = await request(app).get("/api/car");

      expect(response.status).toBe(404);
      expect(response.body).toEqual({ error: "Car not found!" });
    });
  });

  describe("getCarImage", () => {
    it("should fetch a car image successfully", async () => {
      const mockImageRow = [
        [
          {
            image_id: 1,
            car_id: 1,
            image_url: "/path/to/image.jpg",
            uploaded_at: "2023-01-01T00:00:00.000Z",
          },
        ],
      ];

      (db.query as jest.Mock).mockImplementationOnce(() =>
        Promise.resolve(mockImageRow)
      );

      jest.mock("fs", () => ({
        existsSync: jest.fn().mockReturnValue(true),
      }));

      jest.mock("path", () => ({
        resolve: jest.fn().mockReturnValue("/full/path/to/image.jpg"),
      }));

      const sendFileMock = jest.fn();
      const resMock = {
        sendFile: sendFileMock,
        status: jest.fn().mockReturnThis(),
        json: jest.fn(),
      };

      await request(app).get("/api/getCarImage").query({ car_id: "1" });

      expect(db.query).toHaveBeenCalledWith(
        "SELECT image_url FROM car_images WHERE car_id = ? LIMIT 1",
        ["1"]
      );
    });

    it("should return 400 when car_id is not provided", async () => {
      const response = await request(app).get("/api/getCarImage");

      expect(response.status).toBe(400);
      expect(response.body).toEqual({ error: "car_id is required" });
    });
  });

  describe("rentCar", () => {
    it("should return 400 when required fields are missing", async () => {
      const incompleteData = {
        car_id: 1,
      };

      const response = await request(app)
        .post("/api/rent")
        .send(incompleteData);

      expect(response.status).toBe(400);
      expect(response.body.error).toContain("Missing required fields");
    });

    it("should return 400 when user profile is incomplete", async () => {
      const originalUser = { ...mockUser };
      (mockUser as any).driver_license_number = null;

      const rentalData = {
        car_id: 1,
        start_date: "2025-05-01",
        end_date: "2025-05-05",
        pickup_location: "New York",
        payment_method: "credit_card",
      };

      const response = await request(app).post("/api/rent").send(rentalData);

      expect(response.status).toBe(400);
      expect(response.body.error).toContain("User profile is incomplete");

      Object.assign(mockUser, originalUser);
    });

    it("should return 400 when car is not available", async () => {
      const rentalData = {
        car_id: 1,
        start_date: "2025-05-01",
        end_date: "2025-05-05",
        pickup_location: "New York",
        payment_method: "credit_card",
      };

      mockConnection.query
        .mockImplementationOnce(() => Promise.resolve([[]]))
        .mockImplementationOnce(() => Promise.resolve([]));

      const response = await request(app).post("/api/rent").send(rentalData);

      expect(response.status).toBe(400);
      expect(response.body.error).toBe("Car is not available for rent");
      expect(mockConnection.rollback).toHaveBeenCalled();
    });
  });

  describe("editCar", () => {
    it("should successfully edit a car", async () => {
      const updateData = {
        car_id: 1,
        car_price: "20000",
        car_description: "Updated description",
        car_type: "sedan",
      };

      (db.query as jest.Mock)
        .mockImplementationOnce(() =>
          Promise.resolve([
            {
              car_id: 1,
              user_id: 1,
            },
          ])
        )
        .mockImplementationOnce(() => Promise.resolve([]))
        .mockImplementationOnce(() => Promise.resolve({ affectedRows: 1 }))
        .mockImplementationOnce(() =>
          Promise.resolve([
            {
              car_id: 1,
              car_price: "20000",
              car_active: 1,
              location_id: 1,
              car_description: "Updated description",
              car_type: "sedan",
              seats: 5,
              number_of_doors: 4,
              insurance_id: 1,
              car_model: "Corolla",
              car_regnumber: "ABC123",
              price_per_hour: 10,
              price_per_day: 50,
              car_condition: "excellent",
              mileage: 15000,
              car_year: 2022,
              fuel_type: "petrol",
              transmission_type: "automatic",
              car_brand: "Toyota",
            },
          ])
        );

      const response = await request(app).put("/api/car/edit").send(updateData);

      expect(response.status).toBe(200);
      expect(response.body.message).toBe("Car updated successfully");
      expect(db.query).toHaveBeenCalledWith(
        expect.stringContaining("UPDATE car"),
        expect.any(Array)
      );
    });

    it("should return 403 when user doesn't own the car", async () => {
      const updateData = {
        car_id: 1,
        car_price: "20000",
      };

      (db.query as jest.Mock).mockImplementationOnce(() => Promise.resolve([]));

      const response = await request(app).put("/api/car/edit").send(updateData);

      expect(response.status).toBe(403);
      expect(response.body.error).toContain("don't have permission");
    });

    it("should return 400 when car has active bookings", async () => {
      const updateData = {
        car_id: 1,
        car_price: "20000",
      };

      (db.query as jest.Mock)
        .mockImplementationOnce(() =>
          Promise.resolve([
            [
              {
                car_id: 1,
                user_id: 1,
              },
            ],
          ])
        )
        .mockImplementationOnce(() =>
          Promise.resolve([
            [
              {
                orders_id: 1,
                user_id: 2,
                car_id: 1,
                start_date: "2025-04-01T00:00:00.000Z",
                end_date: "2025-04-05T00:00:00.000Z",
                rental_status: "confirmed",
                location_id: 1,
                payment_status: "paid",
                discount_code: "SPRING2025",
                extended_rental: 0,
              },
            ],
          ])
        );

      const response = await request(app).put("/api/car/edit").send(updateData);

      expect(response.status).toBe(400);
      expect(response.body.error).toContain(
        "Cannot edit car with active bookings"
      );
    });

    it("should return 400 when invalid car type is provided", async () => {
      const updateData = {
        car_id: 1,
        car_type: "invalid_type",
      };

      (db.query as jest.Mock)
        .mockImplementationOnce(() =>
          Promise.resolve([
            [
              {
                car_id: 1,
                user_id: 1,
              },
            ],
            null,
          ])
        )
        .mockImplementationOnce(() => Promise.resolve([]));

      const response = await request(app).put("/api/car/edit").send(updateData);

      expect(response.status).toBe(400);
      expect(response.body.error).toBe("Invalid car type");
    });
  });
});
