export interface PayPalOrder {
  id: string;
  status: string;
  links: Array<{
    href: string;
    rel: string;
    method: string;
  }>;
}

export interface PaymentOrder {
  id: number;
  order_ref: string;
  payment_ref: string | null;
  user_id: number;
  car_id: number;
  start_date: Date;
  end_date: Date;
  amount: number;
  currency: string;
  payment_method:
    | "credit_card"
    | "paypal"
    | "bank_transfer"
    | "cash"
    | "bitcoin";
  status: "pending" | "paid" | "failed" | "refunded" | "partially_paid";
  created_at: Date;
}

export interface CreateOrderRequest {
  car_id: number;
  start_date: string;
  end_date: string;
  amount: number;
  currency?: string;
}

export interface CaptureOrderRequest {
  orderID: string;
  car_id: number;
}
