import db from "../../db/connection";
import { Car } from "../../interfaces/Car";
import { Request, Response } from "express";

export const getMostPopularCars = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const rows = await db.query(
      `SELECT car.*, COUNT(comment.comment_id) AS rating_count
         FROM car
         LEFT JOIN comment ON car.car_id = comment.car_id
         GROUP BY car.car_id
         ORDER BY rating_count DESC
         LIMIT 3`
    );
    res.json(rows);
  } catch (error) {
    console.error("Error fetching most popular cars:", error);
    res.status(500).json({ error: "Failed to fetch popular cars" });
  }
};

export const getRandomReviews = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const reviews = await db.query(
      `SELECT user_reviews.review_message, user_reviews.review_rating, user_reviews.review_date,
                user.user_name, user.profile_picture
         FROM user_reviews
         JOIN user ON user_reviews.reviewer_user_id = user.user_id
         ORDER BY RAND()
         LIMIT 3`
    );
    res.json(reviews);
  } catch (error) {
    console.error("Error fetching random reviews:", error);
    res.status(500).json({ error: "Failed to fetch random reviews" });
  }
};
