export interface RentHistory {
    orders_id: number;
    car_id: number;
    car_brand: string;
    car_model: string;
    start_date: string;
    end_date: string;
    rental_status: string;
    payment_status: string;
    amount: number;
}