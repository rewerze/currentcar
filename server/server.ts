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
import {
  carsHandler,
  deleteCar,
  editCar,
  getCarImage,
  rentCar,
} from "./endpoints/api/cars";
import { carsSearchHandler } from "./endpoints/api/carsSearch";
import {
  carHandler,
  getCars,
  getRentedCars,
  getRentHistory,
} from "./endpoints/api/getCar";
import { multerErrorHandler, upload } from "./middlewares/upload";
import { validateCarUpload } from "./middlewares/validators";
import cron from "node-cron";
import morgan from "morgan";
import {
  getNotification,
  readNotification,
} from "./endpoints/api/notifications";
import {
  deleteProfile,
  editProfile,
  uploadProfilePicture,
} from "./endpoints/api/profile";
import path from "path";
import multer from "multer";
import { uploadCar } from "./endpoints/api/carUpload";
import { getComments, postComment } from "./endpoints/api/comments";
import db from "./db/connection";
import { RowDataPacket } from "mysql2";
import { getMostPopularCars, getRandomReviews } from "./endpoints/api/mainPage";
import { captureOrder, CreatePayment } from "./endpoints/api/payment";
import { getDepos } from "./endpoints/api/depos";
import { getLocationById } from "./endpoints/api/location";
import { getInvoice } from "./endpoints/api/invoice";

export const app = express();
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

if (process.env.NODE_ENV !== "production") {
  app.use(morgan("dev"));
}

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
  "/api/uploads/profile-pictures",
  express.static(path.join(__dirname, "endpoints/uploads/profile-pictures"))
);

app.use("/api/uploads", express.static(path.join(__dirname, "uploads/cars")));

app.use(((err: Error, req: Request, res: Response, next: NextFunction) => {
  if (err instanceof multer.MulterError) {
    if (err.code === "LIMIT_FILE_SIZE") {
      return res
        .status(400)
        .json({ message: "File is too large. Maximum size is 5MB." });
    }
    if (err.code === "LIMIT_FILE_COUNT") {
      return res
        .status(400)
        .json({ message: "Too many files. Maximum is 10 files." });
    }
  }

  console.error(err.stack);
  res.status(500).json({
    message: "Something went wrong!",
    error: process.env.NODE_ENV === "production" ? {} : err.message,
  });
}) as express.ErrorRequestHandler);

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
app.put("/api/car/edit", [verifyAuthTokenMiddleware, limiter], editCar);

app.post(
  "/api/upload-profile-picture",
  [verifyAuthTokenMiddleware, limiter],
  uploadProfilePicture
);

app.post(
  "/api/upload",
  upload.any(),
  validateCarUpload,
  verifyAuthTokenMiddleware,
  uploadCar
);

app.get("/api/randomReviews", getRandomReviews);
app.get("/api/popularCars", getMostPopularCars);

app.get("/api/getDepos", getDepos);
app.get("/api/getLocationById", verifyAuthTokenMiddleware, getLocationById);

app.get("/api/getCarImage", getCarImage);

app.get("/api/comments", getComments);
app.post("/api/comments", verifyAuthTokenMiddleware, postComment);

app.post("/api/rent", verifyAuthTokenMiddleware, rentCar);

app.get("/api/invoice/:orderId", verifyAuthTokenMiddleware, getInvoice);

app.post("/api/deleteCar", verifyAuthTokenMiddleware, deleteCar);
app.post("/api/deleteProfile", verifyAuthTokenMiddleware, deleteProfile);
app.get("/api/getRentedCars", verifyAuthTokenMiddleware, getRentedCars);
app.get("/api/getRentHistory", verifyAuthTokenMiddleware, getRentHistory);

app.post("/api/paypal/create-order", verifyAuthTokenMiddleware, CreatePayment);
app.post("/api/paypal/capture-order", verifyAuthTokenMiddleware, captureOrder);

app.use((req: Request, res: Response) => {
  res.status(404).json({ message: "Route not found" });
});

app.use(multerErrorHandler);

if (process.env.NODE_ENV !== "test") {
  cron.schedule("*/30 * * * *", async () => {
    console.log("Checking for expired cars...");
    await updateExpiredOrders();
    await deactivateExpiredAvailability();
  });
}

export const updateExpiredOrders = async () => {
  try {
    const result = await db.query<RowDataPacket>(`
          UPDATE car
          SET car_active = 1
          WHERE car_id IN (
              SELECT car_id FROM orders 
              WHERE end_date < NOW() AND (rental_status = 'completed' OR rental_status = 'confirmed')
          )
      `);
    console.log(
      `Reactivated ${(result as RowDataPacket).affectedRows
      } cars after rental expiry.`
    );
  } catch (error) {
    console.error("Error updating expired orders:", error);
  }
};

export const deactivateExpiredAvailability = async () => {
  try {
    const result = await db.query<RowDataPacket>(`
          UPDATE car
          SET car_active = 0
          WHERE car_id IN (
              SELECT car_id FROM car_availability 
              WHERE available_to < NOW()
          )
      `);
    console.log(
      `Deactivated ${(result as RowDataPacket).affectedRows
      } cars due to availability expiration.`
    );
  } catch (error) {
    console.error("Error deactivating expired availability:", error);
  }
};
if (process.env.NODE_ENV !== "test") {
  app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
  });
}
