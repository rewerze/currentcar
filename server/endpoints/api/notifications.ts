import { Request, Response } from "express";
import db from "../../db/connection";

interface AuthenticatedRequest extends Request {
  user?: any;
}

export interface Notification {
  notification_id: string;
  user_id: string;
  message: string;
  status: "read" | "unread";
  created_at: Date;
}

export const readNotification = async (
  req: AuthenticatedRequest,
  res: Response
): Promise<void> => {
  const notificationId = req.params.notificationId;
  const id = req.user.user_id;

  try {
    const notification = await db.query<Notification[]>(
      "SELECT * FROM notifications WHERE notification_id = ? AND user_id = ?",
      [notificationId, id]
    );

    if (notification.length == 0) {
      res.status(401).json({ error: "Notification isn't owned by user" });
      return;
    }

    await db.query(
      'UPDATE notifications SET status = "read" WHERE notification_id = ?',
      [notificationId]
    );

    res.json({ success: true });
  } catch (error) {
    res.status(500).json({ error: "Failed to mark notification as read" });
  }
};

export const getNotification = async (
  req: AuthenticatedRequest,
  res: Response
): Promise<void> => {
  const userId = req.user.user_id;

  try {
    const notifications = await db.query(
      "SELECT * FROM notifications WHERE user_id = ? ORDER BY created_at DESC",
      [userId]
    );

    res.json(notifications);
  } catch (error) {
    res.status(500).json({ error: "Failed to fetch notifications" });
  }
};
