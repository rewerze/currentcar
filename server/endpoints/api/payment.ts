import axios from "axios";
import { Request, Response } from "express";
import { v4 as uuidv4 } from "uuid";
import {
  CaptureOrderRequest,
  CreateOrderRequest,
  PayPalOrder,
} from "../../interfaces/Payment";
import { AuthenticatedRequest } from "../../interfaces/User";
import { Car } from "../../interfaces/Car";
import db from "../../db/connection";
import { RowDataPacket } from "mysql2";

const PAYPAL_CLIENT_ID = process.env.PAYPAL_CLIENT_ID;
const PAYPAL_CLIENT_SECRET = process.env.PAYPAL_CLIENT_SECRET;
const PAYPAL_API =
  process.env.NODE_ENV === "production"
    ? "https://api-m.paypal.com"
    : "https://api-m.sandbox.paypal.com";
const FRONTEND_URL = process.env.FRONTEND_URL || "http://localhost:5173";

async function generateAccessToken(): Promise<string> {
  try {
    const auth = Buffer.from(
      `${PAYPAL_CLIENT_ID}:${PAYPAL_CLIENT_SECRET}`
    ).toString("base64");
    const response = await axios.post(
      `${PAYPAL_API}/v1/oauth2/token`,
      "grant_type=client_credentials",
      {
        headers: {
          Authorization: `Basic ${auth}`,
          "Content-Type": "application/x-www-form-urlencoded",
        },
      }
    );
    return (response.data as { access_token: string }).access_token;
  } catch (error) {
    console.error("Failed to generate PayPal access token:", error);
    throw new Error("Failed to generate PayPal access token");
  }
}

function calculateTotalAmount(
  car: Car,
  fromDate: string,
  toDate: string
): number {
  if (!car) return 0;

  const startDate = new Date(fromDate);
  const endDate = new Date(toDate);
  const diffTime = Math.abs(endDate.getTime() - startDate.getTime());
  const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

  if (diffDays < 1) {
    const diffHours = Math.ceil(diffTime / (1000 * 60 * 60));
    return diffHours * car.price_per_hour;
  }

  return diffDays * car.price_per_day;
}

export const CreatePayment = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    if (!(req as AuthenticatedRequest).user) {
      res.status(401).json({ error: "User not authenticated" });
      return;
    }

    const user = (req as AuthenticatedRequest).user;

    if (
      ![
        user?.driver_license_expiry != null &&
          user?.driver_license_number != null,
        user?.user_email != null && Number(user?.u_phone_number) !== 0,
        user?.born_at != null &&
          new Date().getFullYear() - new Date(user?.born_at).getFullYear() >=
            17,
      ].every(Boolean)
    ) {
      res.status(400).json({
        error: `User profile is incomplete or invalid for car rental`,
      });
      return;
    }

    const {
      car_id,
      start_date,
      end_date,
      currency = "USD",
    }: CreateOrderRequest = req.body;

    if (!car_id || !start_date || !end_date) {
      res.status(400).json({ error: "Missing required fields" });
      return;
    }

    const cars = await db.query<Car>("SELECT * FROM car WHERE car_id = ?", [
      car_id,
    ]);

    if (!cars || cars.length === 0) {
      res.status(404).json({ error: "Car not found" });
      return;
    }

    const car = cars[0];

    if (!car.car_active) {
      res.status(400).json({ error: "Car is not available for rent" });
      return;
    }

    const amount = calculateTotalAmount(car, start_date, end_date);

    await db.query(`
          CREATE TABLE IF NOT EXISTS payment_orders (
            id INT AUTO_INCREMENT PRIMARY KEY,
            order_ref VARCHAR(36) NOT NULL,
            payment_ref VARCHAR(255),
            user_id INT NOT NULL,
            car_id INT NOT NULL,
            start_date DATE NOT NULL,
            end_date DATE NOT NULL,
            amount DECIMAL(10, 2) NOT NULL,
            currency VARCHAR(3) NOT NULL DEFAULT 'USD',
            payment_method VARCHAR(20) NOT NULL,
            status VARCHAR(20) NOT NULL,
            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
            FOREIGN KEY (user_id) REFERENCES user(user_id),
            FOREIGN KEY (car_id) REFERENCES car(car_id)
          );
        `);

    const orderRef = uuidv4();
    await db.query(
      "INSERT INTO payment_orders (order_ref, user_id, car_id, start_date, end_date, amount, currency, payment_method, status) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
      [
        orderRef,
        (req as AuthenticatedRequest).user.user_id,
        car_id,
        start_date,
        end_date,
        amount,
        currency,
        "paypal",
        "pending",
      ]
    );

    const accessToken = await generateAccessToken();

    const response = await axios.post<PayPalOrder>(
      `${PAYPAL_API}/v2/checkout/orders`,
      {
        intent: "CAPTURE",
        purchase_units: [
          {
            reference_id: orderRef,
            description: `Car rental: ${car.car_brand} ${car.car_model}`,
            amount: {
              currency_code: currency,
              value: amount.toString(),
            },
          },
        ],
        application_context: {
          return_url: `${FRONTEND_URL}/status/${car_id}`,
          cancel_url: `${FRONTEND_URL}/status/${car_id}?canceled=true`,
        },
      },
      {
        headers: {
          Authorization: `Bearer ${accessToken}`,
          "Content-Type": "application/json",
        },
      }
    );

    await db.query(
      "UPDATE payment_orders SET payment_ref = ? WHERE order_ref = ?",
      [response.data.id, orderRef]
    );

    res.json(response.data);
  } catch (error) {
    console.error("Error creating PayPal order:", error);
    res.status(500).json({ error: "Failed to create PayPal order" });
  }
};

export const captureOrder = async (
  req: Request,
  res: Response
): Promise<void> => {
  try {
    const { orderID, car_id }: CaptureOrderRequest = req.body;

    if (!(req as AuthenticatedRequest).user) {
      res.status(401).json({ error: "User not authenticated" });
      return;
    }

    const orders = await db.query<any>(
      "SELECT * FROM payment_orders WHERE payment_ref = ? AND car_id = ?",
      [orderID, car_id]
    );

    if (!orders || orders.length === 0) {
      res.status(404).json({ error: "Order not found" });
      return;
    }

    const order = orders[0];

    const accessToken = await generateAccessToken();

    const response = await axios.post(
      `${PAYPAL_API}/v2/checkout/orders/${orderID}/capture`,
      undefined,
      {
        headers: {
          Authorization: `Bearer ${accessToken}`,
          "Content-Type": "application/json",
        },
      }
    );

    if ((response.data as { status: string }).status === "COMPLETED") {
      await db.query(
        "UPDATE payment_orders SET status = ? WHERE payment_ref = ?",
        ["paid", orderID]
      );

      const locationResult = await db.query<any>(
        "SELECT location_id FROM location LIMIT 1"
      );
      const locationId =
        locationResult.length > 0 ? locationResult[0].location_id : 1;

      await db.query(
        "INSERT INTO orders (user_id, car_id, start_date, end_date, rental_status, location_id, payment_status, discount_code, extended_rental) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
        [
          (req as AuthenticatedRequest).user.user_id,
          car_id,
          order.start_date,
          order.end_date,
          "confirmed",
          locationId,
          "paid",
          "",
          false,
        ]
      );

      const orderResult = await db.query<any>(
        "SELECT LAST_INSERT_ID() as orderId"
      );
      const orderId = orderResult[0].orderId;

      await db.query(
        "INSERT INTO invoice (orders_id, insurance_id, payment_amount, tax_amount, payment_method, payment_status, payment_date, invoice_address) VALUES (?, ?, ?, ?, ?, ?, NOW(), ?)",
        [
          orderId,
          1,
          order.amount,
          order.amount * 0.27,
          "paypal",
          "paid",
          "Default Address",
        ]
      );

      await db.query("UPDATE car SET car_active = 0 WHERE car_id = ?", [
        car_id,
      ]);

      await db.query(
        "INSERT INTO notifications (user_id, message, status, created_at) VALUES (?, ?, ?, NOW())",
        [
          (req as AuthenticatedRequest).user.user_id,
          `Your car rental for ${new Date(
            order.start_date
          ).toLocaleDateString()} to ${new Date(
            order.end_date
          ).toLocaleDateString()} has been confirmed. Invoice can be accessed <a href="${
            process.env.FRONTEND_URL
          }/invoice/${orderId}">here</a>`,
          "unread",
        ]
      );

      
    const [queryResult] = await db.query<RowDataPacket[]>(
      `SELECT * FROM car_user WHERE car_id = ?`,
      [car_id]
    );

    const [carDetails]: any = await db.query(
      `SELECT c.*, i.insurance_fee, i.insurance_id
       FROM car c
       JOIN insurance i ON c.insurance_id = i.insurance_id
       WHERE c.car_id = ?`,
      [car_id]
    );

    console.log(queryResult)

      await db.query(
        `INSERT INTO notifications (
          user_id,
          message,
          status,
          created_at
        ) VALUES (?, ?, 'unread', NOW())`,
        [
          ((queryResult as RowDataPacket).user_id || (queryResult as RowDataPacket[])[0].user_id),
          `Your car has been successfully rented out to a customer. The rental is for a ${(carDetails.car_brand || carDetails[0].car_brand)} ${(carDetails.car_model || carDetails[0].car_model)}.`,
        ]
      );

      res.json({
        success: true,
        startDate: order.start_date,
        endDate: order.end_date,
      });
    } else {
      await db.query(
        "UPDATE payment_orders SET status = ? WHERE payment_ref = ?",
        ["failed", orderID]
      );

      res.status(400).json({ error: "Payment not completed" });
    }
  } catch (error) {
    console.error((error as { response: { data: string } }).response?.data);
    console.error("Error capturing PayPal payment:", error);
    res.status(500).json({ error: "Failed to capture PayPal payment" });
  }
};
