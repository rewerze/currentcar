import { NextFunction, Request, RequestHandler, Response } from "express";

import jwt from "jsonwebtoken";
import { AuthenticatedRequest } from "../interfaces/User";
export const verifyAdmin: RequestHandler = async (
  req: Request,
  res: Response,
  next: NextFunction
): Promise<void> => {
  const user_id = (req as AuthenticatedRequest).user.user_id;

  console.log(user_id);

  if (!user_id) {
    res.status(403).json({ message: "Access denied. No user_id provided." });
    return;
  }

  try {
    const role = (req as AuthenticatedRequest).user.user_role;
    console.log(role);
    if (role != "admin") {
      res.status(403).json({ message: "User isn't administrator." });
      return;
    }
    next();
  } catch (error) {
    res.status(401).json({ message: "Invalid or expired token." });
    return;
  }
};
