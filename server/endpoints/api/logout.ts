import { Request, Response } from "express";

export const logoutHandler = async (
  req: Request,
  res: Response
): Promise<void> => {
  res.clearCookie("auth_token");
  res.status(200).send({ message: "Logged out successfully" });
};
