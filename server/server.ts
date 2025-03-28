import express, { NextFunction, Request, Response } from "express";
import rateLimit from "express-rate-limit";
import dotenv from "dotenv";
dotenv.config();
import cookieParser from "cookie-parser";
import cors from "cors";
import { registerHandler } from "./endpoints/api/register";
import { verifyHandler } from "./endpoints/api/verify";
import { loginHandler } from "./endpoints/api/login";
import { verifyAuthTokenMiddleware } from "./middlewares/authToken";
import { logoutHandler } from "./endpoints/api/logout";
import { resetPasswordHandler } from "./endpoints/api/reset-password";
import { carsHandler } from "./endpoints/api/cars";
import { carsSearchHandler } from "./endpoints/api/carsSearch";
import { carHandler, getCars } from "./endpoints/api/getCar";
import {
  getNotification,
  readNotification,
} from "./endpoints/api/notifications";
import { editProfile, uploadProfilePicture } from "./endpoints/api/profile";
import path from "path";

const app = express();
const port = process.env.PORT || 3000;

app.use(
  cors({
    origin: [
      "http://localhost:5173",
      "https://beniary.com",
      "http://127.0.0.1:5173",
    ],
    credentials: true,
  })
);
app.use(express.json());
app.use(cookieParser());

const limiter = rateLimit({
  windowMs: 15 * 60 * 1000,
  max: 30,
  message: {
    error: "Too many requests, please try again later.",
  },
  standardHeaders: true,
  legacyHeaders: false,
});

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.use(
  "/uploads/profile-pictures",
  express.static(path.join(__dirname, "endpoints/uploads/profile-pictures"))
);

app.post("/api/auth/register", [limiter], registerHandler);
app.post("/api/auth/login", [limiter], loginHandler);
app.post("/api/auth/logout", [verifyAuthTokenMiddleware], logoutHandler);
app.post(
  "/api/auth/reset-password",
  [limiter, verifyAuthTokenMiddleware],
  resetPasswordHandler
);
app.get("/api/cars", carsHandler);
app.get("/api/cars/search", carsSearchHandler);
app.get("/api/car", carHandler);
app.get("/api/getCars", [verifyAuthTokenMiddleware], getCars);

app.get("/api/auth/verify", verifyHandler);

app.get("/api/notifications", [verifyAuthTokenMiddleware], getNotification);

app.put(
  "/api/notifications/:notificationId/read",
  [verifyAuthTokenMiddleware],
  readNotification
);

app.put("/api/profile/edit", [verifyAuthTokenMiddleware, limiter], editProfile);

app.post(
  "/api/upload-profile-picture",
  [verifyAuthTokenMiddleware, limiter],
  uploadProfilePicture
);

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
