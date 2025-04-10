import { Request, Response } from "express";
import db from "../../db/connection";
import { AuthenticatedRequest } from "../../interfaces/User";
import { RowDataPacket } from "mysql2";

export const getComments = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const { carId } = req.query;
    if (!carId) {
      res.status(400).json({ error: "Missing carId parameter" });
      return;
    }

    const comments = await db.query(
      `SELECT c.comment_id, c.comment_message, c.comment_star, c.rating_category, c.comment_date, 
                    u.user_name, u.profile_picture, c.comment_flagged
             FROM comment c
             JOIN user u ON c.user_id = u.user_id
             WHERE c.car_id = ? 
             ORDER BY c.comment_date DESC`,
      [carId]
    );

    res.json(comments);
  } catch (error) {
    console.error("Error fetching comments:", error);
    res.status(500).json({ error: "Internal server error" });
  }
};

export const postComment = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const { carId, message, stars, ratingCategory } = req.body;
    const userId = (req as AuthenticatedRequest).user?.user_id;

    if (!userId) {
      res.status(401).json({ error: "Unauthorized" });
      return;
    }

    if (!carId || !message || !stars || !ratingCategory) {
      res.status(400).json({ error: "Missing required fields" });
      return;
    }

    const result = await db.query<any>(
      `INSERT INTO comment (user_id, car_id, comment_message, comment_star, rating_category, comment_date)
             VALUES (?, ?, ?, ?, ?, NOW())`,
      [userId, carId, message, stars, ratingCategory]
    );

    console.log(result);

    const newCommentId = (result as RowDataPacket).insertId;

    const [newComment] = await db.query<any>(
      `SELECT c.comment_id, c.comment_message, c.comment_star, c.rating_category, c.comment_date, 
                    u.user_name, u.profile_picture
             FROM comment c
             JOIN user u ON c.user_id = u.user_id
             WHERE c.comment_id = ?`,
      [newCommentId]
    );

    res.status(201).json(newComment);
  } catch (error) {
    console.error("Error posting comment:", error);
    res.status(500).json({ error: "Internal server error" });
  }
};
