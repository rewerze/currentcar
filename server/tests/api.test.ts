import request from "supertest";
import { verifyAuthTokenMiddleware } from "../middlewares/authToken";
import db, { IDBConnection } from "../db/connection";
import { jest } from "@jest/globals";
import { NextFunction } from "express";
import { describe, afterEach, it, expect } from "@jest/globals";
import { app } from "../server";
import { Review } from "../interfaces/Review";

jest.mock("../db/connection", () => ({
  query: jest.fn(),
}));

jest.mock("../middlewares/authToken", () => ({
  verifyAuthTokenMiddleware: jest.fn((req, res, next: NextFunction) => next()),
}));

describe("API Endpoints", () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  it("should fetch comments for a specific car", async () => {
    const mockComments = [
      {
        comment_id: 1,
        comment_message: "Nice car!",
        comment_star: 5,
        rating_category: "Performance",
        comment_date: new Date("2024-04-10T10:00:00Z").toISOString(),
        user_name: "John Doe",
        profile_picture: "http://example.com/profile.jpg",
        comment_flagged: false,
      },
    ];

    (db.query as jest.MockedFunction<typeof db.query>).mockResolvedValueOnce(
      mockComments
    );

    const response = await request(app).get("/api/comments").query({
      carId: "1",
    });

    const expectedQuery =
      "SELECT c.comment_id, c.comment_message, c.comment_star, c.rating_category, c.comment_date, u.user_name, u.profile_picture, c.comment_flagged FROM comment c JOIN user u ON c.user_id = u.user_id WHERE c.car_id = ? ORDER BY c.comment_date DESC";

    const actualQuery = (
      db.query as jest.MockedFunction<typeof db.query>
    ).mock.calls[0][0]
      .replace(/\s+/g, " ")
      .trim();

    expect(response.status).toBe(200);
    expect(response.body).toEqual(mockComments);

    expect(actualQuery).toBe(expectedQuery);
    expect(db.query).toHaveBeenCalledWith(
      `SELECT c.comment_id, c.comment_message, c.comment_star, c.rating_category, c.comment_date, 
                    u.user_name, u.profile_picture, c.comment_flagged
             FROM comment c
             JOIN user u ON c.user_id = u.user_id
             WHERE c.car_id = ? 
             ORDER BY c.comment_date DESC`,
      ["1"]
    );
  });
});
