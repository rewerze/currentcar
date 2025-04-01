export interface Car {
    car_id: number;
    car_price: string;
    car_active: boolean;
    car_description: string;
    car_type: 'sedan' | 'suv' | 'hatchback' | 'convertible' | 'coupe' | 'wagon' | 'pickup' | 'minivan';
    seats: number;
    number_of_doors: number;
    insurance_id: number;
    car_model: string;
    car_regnumber: string;
    price_per_hour: number;
    price_per_day: number;
    car_condition: 'new' | 'excellent' | 'good' | 'fair' | 'poor';
    mileage: number;
    car_year: number;
    fuel_type: 'petrol' | 'diesel' | 'electric' | 'hybrid' | 'gas';
    transmission_type: 'automatic' | 'manual' | 'semi-automatic' | 'CVT';
    car_brand: string;
    available_to: string;
    car_owner: number;
}