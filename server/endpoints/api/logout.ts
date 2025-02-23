import { Request, Response } from "express";

interface AuthenticatedRequest extends Request {
  user?: any;
}

export const logoutHandler = async (
  req: AuthenticatedRequest,
  res: Response
): Promise<void> => {
  res.clearCookie("auth_token");
  res.status(200).send({ message: "Logged out successfully" });
};
