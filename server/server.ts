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

app.post("/api/auth/register", [limiter], registerHandler);
app.post("/api/auth/login", [limiter], loginHandler);
app.post("/api/auth/logout", [verifyAuthTokenMiddleware], logoutHandler);

app.get("/api/auth/verify", verifyHandler);

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
