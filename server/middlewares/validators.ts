import { check } from "express-validator";

export const validateCarUpload = [
  check("car_brand")
    .notEmpty()
    .withMessage("Brand is required")
    .isLength({ max: 20 })
    .withMessage("Brand must be less than 20 characters"),

  check("car_model")
    .notEmpty()
    .withMessage("Model is required")
    .isLength({ max: 70 })
    .withMessage("Model must be less than 70 characters"),

  check("car_condition")
    .notEmpty()
    .withMessage("Condition is required")
    .isIn(["new", "excellent", "good", "fair", "poor"])
    .withMessage("Invalid condition value"),

  check("car_year")
    .notEmpty()
    .withMessage("Year is required")
    .isInt({ min: 1900, max: new Date().getFullYear() })
    .withMessage("Invalid year"),

  check("car_type")
    .notEmpty()
    .withMessage("Car type is required")
    .isIn([
      "sedan",
      "suv",
      "hatchback",
      "convertible",
      "coupe",
      "wagon",
      "pickup",
      "minivan",
    ])
    .withMessage("Invalid car type"),

  check("fuel_type")
    .notEmpty()
    .withMessage("Fuel type is required")
    .isIn(["petrol", "diesel", "electric", "hybrid", "gas"])
    .withMessage("Invalid fuel type"),

  check("transmission_type")
    .notEmpty()
    .withMessage("Transmission type is required")
    .isIn(["automatic", "manual", "semi-automatic", "CVT"])
    .withMessage("Invalid transmission type"),

  check("car_regnumber")
    .notEmpty()
    .withMessage("Registration number is required")
    .isLength({ max: 20 })
    .withMessage("Registration number must be less than 20 characters"),

  check("seats")
    .notEmpty()
    .withMessage("Number of seats is required")
    .isInt({ min: 1, max: 20 })
    .withMessage("Invalid number of seats"),

  check("number_of_doors")
    .notEmpty()
    .withMessage("Number of doors is required")
    .isInt({ min: 1, max: 10 })
    .withMessage("Invalid number of doors"),

  check("price_per_hour")
    .notEmpty()
    .withMessage("Price per hour is required")
    .isInt({ min: 0 })
    .withMessage("Price per hour must be a positive number"),

  check("price_per_day")
    .notEmpty()
    .withMessage("Price per day is required")
    .isInt({ min: 0 })
    .withMessage("Price per day must be a positive number"),

  check("car_description")
    .notEmpty()
    .withMessage("Description is required")
    .isLength({ max: 250 })
    .withMessage("Description must be less than 250 characters"),

    check('available_to')
    .notEmpty()
    .withMessage("Availability date is required")
    .isDate()
    .withMessage("Available to must be a valid date"),
];
