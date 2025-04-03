import { NextFunction, Request, RequestHandler, Response } from "express";

import jwt from "jsonwebtoken";
import { AuthenticatedRequest } from "../interfaces/User";
export const verifyAuthTokenMiddleware: RequestHandler = async (
  req: Request,
  res: Response,
  next: NextFunction
): Promise<void> => {
  const token =
    req.cookies?.auth_token || req.headers.authorization?.split(" ")[1];

  console.log(token);

  if (!token) {
    res.status(403).json({ message: "Access denied. No token provided." });
    return;
  }

  try {
    const decoded = jwt.verify(token, process.env.SECRET_KEY as string);
    (req as AuthenticatedRequest).user = decoded as any;
    next();
  } catch (error) {
    res.status(401).json({ message: "Invalid or expired token." });
    return;
  }
};
