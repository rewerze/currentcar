CREATE TABLE IF NOT EXISTS `user` (
    `user_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `user_email` varchar(50) NOT NULL,
    `user_name` varchar(35) NOT NULL,
    `password` varchar(70) NOT NULL,
    `created_at` datetime NOT NULL,
    `updated_at` datetime NOT NULL,
    `user_active` bool NOT NULL DEFAULT '1',
    `u_phone_number` varchar(20) NOT NULL,
    `user_areacode` int NOT NULL,
    `user_role` enum('admin', 'user') NOT NULL DEFAULT 'user',
    `driver_license_number` varchar(40) NOT NULL,
    `driver_license_expiry` date NOT NULL,
    `profile_picture` varchar(255) NOT NULL,
    PRIMARY KEY (`user_id`)
);

CREATE TABLE IF NOT EXISTS `car_user` (
    `car_id` int NOT NULL,
    `user_id` int NOT NULL
);

CREATE TABLE IF NOT EXISTS `car` (
    `car_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `car_price` varchar(255) NOT NULL,
    `car_active` bool NOT NULL DEFAULT '1',
    `car_description` varchar(250) NOT NULL,
    `car_type` enum('sedan', 'suv', 'hatchback', 'convertible', 'coupe', 'wagon', 'pickup', 'minivan') NOT NULL,
    `seats` int NOT NULL,
    `number_of_doors` int NOT NULL,
    `insurance_id` int NOT NULL,
    `car_model` varchar(70) NOT NULL,
    `car_regnumber` varchar(20) NOT NULL UNIQUE,
    `price_per_hour` INT NOT NULL,
    `price_per_day` INT NOT NULL,
    `car_condition` enum('new', 'excellent', 'good', 'fair', 'poor') NOT NULL,
    `mileage` int NOT NULL,
    `car_year` int NOT NULL,
    `fuel_type` enum('petrol', 'diesel', 'electric', 'hybrid', 'gas') NOT NULL,
    `transmission_type` enum('automatic', 'manual', 'semi-automatic', 'CVT') NOT NULL,
    `car_brand` varchar(20) NOT NULL,
    PRIMARY KEY (`car_id`)
);

CREATE TABLE IF NOT EXISTS `car_images` (
    `image_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `car_id` int NOT NULL,
    `image_url` varchar(255) NOT NULL,
    `uploaded_at` datetime NOT NULL,
    PRIMARY KEY (`image_id`)
);

CREATE TABLE IF NOT EXISTS `car_availability` (
    `car_id` int NOT NULL,
    `available_from` datetime NOT NULL,
    `available_to` datetime NOT NULL,
    PRIMARY KEY (`car_id`, `available_from`)
);

CREATE TABLE IF NOT EXISTS `car_extras` (
    `extra_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `car_id` int NOT NULL,
    `extra_name` enum('baby seat', '') NOT NULL,
    `extra_price` decimal(10,2) NOT NULL,
    PRIMARY KEY (`extra_id`)
);

CREATE TABLE IF NOT EXISTS `user_reviews` (
    `review_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `reviewer_user_id` int NOT NULL,
    `reviewee_user_id` int NOT NULL,
    `review_message` varchar(500) NOT NULL,
    `review_rating` int NOT NULL,
    `review_date` datetime NOT NULL,
    PRIMARY KEY (`review_id`)
);

CREATE TABLE IF NOT EXISTS `comment` (
    `comment_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `user_id` int NOT NULL,
    `car_id` int NOT NULL,
    `comment_message` varchar(500) NOT NULL,
    `comment_star` int NOT NULL,
    `comment_date` datetime NOT NULL,
    `rating_category` enum('comfort', 'performance', 'fuel_efficiency', 'safety', 'value_for_money') NOT NULL,
    `comment_flagged` bool NOT NULL DEFAULT false,
    PRIMARY KEY (`comment_id`)
);

CREATE TABLE IF NOT EXISTS `transactions` (
    `transaction_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `orders_id` int NOT NULL,
    `transaction_amount` decimal(10,2) NOT NULL,
    `transaction_date` datetime NOT NULL,
    `payment_method` enum('credit_card', 'paypal', 'bank_transfer', 'cash') NOT NULL,
    `payment_status` enum('pending', 'completed', 'failed', 'refunded') NOT NULL,
    PRIMARY KEY (`transaction_id`)
);

CREATE TABLE IF NOT EXISTS `location` (
    `location_id` int AUTO_INCREMENT NOT NULL,
    `pickup_location` varchar(250) NOT NULL,
    `dropoff_location` varchar(250) NOT NULL,
    `longitude` int NOT NULL,
    `latitude` int NOT NULL,
    PRIMARY KEY (`location_id`)
);

CREATE TABLE IF NOT EXISTS `orders` (
    `orders_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `user_id` int NOT NULL,
    `car_id` int NOT NULL,
    `start_date` datetime NOT NULL,
    `end_date` datetime NOT NULL,
    `rental_status` enum('pending', 'confirmed', 'completed', 'cancelled', 'extended') NOT NULL,
    `location_id` int NOT NULL,
    `payment_status` enum('pending', 'paid', 'failed', 'refunded', 'partially_paid') NOT NULL,
    `discount_code` varchar(50) NOT NULL,
    `extended_rental` bool NOT NULL DEFAULT false,
    PRIMARY KEY (`orders_id`)
);

CREATE TABLE IF NOT EXISTS `insurance` (
    `insurance_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `insurance_provider` varchar(100) NOT NULL,
    `coverage_details` text NOT NULL,
    `insurance_fee` decimal(10,2) NOT NULL,
    `duration` int NOT NULL,
    PRIMARY KEY (`insurance_id`)
);

CREATE TABLE IF NOT EXISTS `invoice` (
    `invoice_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `orders_id` int NOT NULL,
    `insurance_id` int NOT NULL, 
    `invoice_address` varchar(255) NOT NULL,
    `invoice_payment` decimal(10,2) NOT NULL,
    `tax_amount` decimal(10,2) NOT NULL, 
    `payment_method` enum('credit_card', 'paypal', 'bank_transfer', 'cash', 'bitcoin') NOT NULL,
    `invoice_status` enum('pending', 'paid', 'failed', 'refunded') NOT NULL,
    PRIMARY KEY (`invoice_id`)
);

CREATE TABLE IF NOT EXISTS `notifications` (
    `notification_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `user_id` int NOT NULL,
    `message` varchar(500) NOT NULL,
    `status` enum('unread', 'read') NOT NULL,
    `created_at` datetime NOT NULL,
    PRIMARY KEY (`notification_id`)
);

ALTER TABLE `user` ADD `born_at` DATETIME NOT NULL AFTER `password`;

ALTER TABLE car_user ADD FOREIGN KEY (`car_id`) REFERENCES `car`(`car_id`);
ALTER TABLE car_user ADD FOREIGN KEY (`user_id`) REFERENCES `user`(`user_id`);
ALTER TABLE orders ADD FOREIGN KEY (`user_id`) REFERENCES `user`(`user_id`);
ALTER TABLE orders ADD FOREIGN KEY (`car_id`) REFERENCES `car`(`car_id`);
ALTER TABLE orders ADD FOREIGN KEY (`location_id`) REFERENCES `location`(`location_id`);
ALTER TABLE invoice ADD FOREIGN KEY (`orders_id`) REFERENCES `orders`(`orders_id`);
ALTER TABLE `comment` ADD FOREIGN KEY (`user_id`) REFERENCES `user`(`user_id`);
ALTER TABLE `comment` ADD FOREIGN KEY (`car_id`) REFERENCES `car`(`car_id`);
ALTER TABLE notifications ADD FOREIGN KEY (`user_id`) REFERENCES `user`(`user_id`);
ALTER TABLE car_images ADD FOREIGN KEY (`car_id`) REFERENCES `car`(`car_id`);
ALTER TABLE car_availability ADD FOREIGN KEY (`car_id`) REFERENCES `car`(`car_id`);
ALTER TABLE car_extras ADD FOREIGN KEY (`car_id`) REFERENCES `car`(`car_id`);
ALTER TABLE user_reviews ADD FOREIGN KEY (`reviewer_user_id`) REFERENCES `user`(`user_id`);
ALTER TABLE user_reviews ADD FOREIGN KEY (`reviewee_user_id`) REFERENCES `user`(`user_id`);
ALTER TABLE transactions ADD FOREIGN KEY (`orders_id`) REFERENCES `orders`(`orders_id`);
ALTER TABLE invoice ADD FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`);
ALTER TABLE car ADD FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`);