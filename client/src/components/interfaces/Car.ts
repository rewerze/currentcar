import {
  CarCondition,
  CarType,
  FuelType,
  TransmissionType,
} from "../enums/Car";

export interface CarInfo {
  image: string;
  images?: string;
  car_id: number;
  car_price: string;
  car_active: boolean;
  car_description: string;
  car_type: CarType;
  seats: number;
  number_of_doors: number;
  insurance_id: number;
  car_model: string;
  car_regnumber: string;
  price_per_hour: number;
  price_per_day: number;
  car_condition: CarCondition;
  mileage: number;
  car_year: number;
  fuel_type: FuelType;
  transmission_type: TransmissionType;
  car_brand: string;
  available_to: Date;
  car_owner?: number;
  extras?: string;
  depo?: string;
  location_id: string;
}
