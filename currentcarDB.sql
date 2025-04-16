CREATE TABLE IF NOT EXISTS `user` (
    `user_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `user_email` varchar(50) NOT NULL,
    `user_name` varchar(35) NOT NULL,
    `password` varchar(70) NOT NULL,
    `born_at` DATETIME DEFAULT NULL,
    `created_at` datetime NOT NULL,
    `updated_at` datetime NOT NULL,
    `user_active` boolean NOT NULL DEFAULT '1',
    `u_phone_number` varchar(20) DEFAULT NULL,
    `user_areacode` int DEFAULT NULL,
    `user_role` enum('admin', 'user') NOT NULL DEFAULT 'user',
    `driver_license_number` varchar(40) DEFAULT NULL,
    `driver_license_expiry` date DEFAULT null,
    `profile_picture` varchar(255) DEFAULT NULL,
    `user_iban` varchar(255) DEFAULT null,
    PRIMARY KEY (`user_id`)
);

CREATE TABLE IF NOT EXISTS `car_user` (
    `car_id` int NOT NULL,
    `user_id` int NOT NULL
);

CREATE TABLE IF NOT EXISTS `car` (
    `car_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `car_price` varchar(255) NOT NULL,
    `car_active` boolean NOT NULL DEFAULT '1',
    `location_id` int not null DEFAULT 1,
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
    `verified` boolean NOT NULL DEFAULT '0',
    `rented` boolean NOT NULL DEFAULT '0',
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
    `extra_name` text NOT NULL,
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
    `comment_flagged` boolean NOT NULL DEFAULT false,
    PRIMARY KEY (`comment_id`)
);

CREATE TABLE IF NOT EXISTS `invoice` (
    `payment_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `orders_id` int NOT NULL,
    `insurance_id` int NOT NULL, 
    `payment_amount` decimal(10,2) NOT NULL,
    `tax_amount` decimal(10,2) NOT NULL, 
    `payment_method` enum('credit_card', 'paypal', 'bank_transfer', 'cash', 'bitcoin') NOT NULL,
    `payment_status` enum('pending', 'paid', 'failed', 'refunded', 'partially_paid') NOT NULL,
    `payment_date` datetime NOT NULL,
    `invoice_address` varchar(255) NOT NULL,
    PRIMARY KEY (`payment_id`)
);

CREATE TABLE IF NOT EXISTS `location` (
    `location_id` int AUTO_INCREMENT NOT NULL,
    `location` varchar(250) NOT NULL,
    `zip_code` int not null,
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
    `extended_rental` boolean NOT NULL DEFAULT false,
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


CREATE TABLE IF NOT EXISTS `notifications` (
    `notification_id` int AUTO_INCREMENT NOT NULL UNIQUE,
    `user_id` int NOT NULL,
    `message` varchar(500) NOT NULL,
    `status` enum('unread', 'read') NOT NULL,
    `created_at` datetime NOT NULL,
    PRIMARY KEY (`notification_id`)
);

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
          created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
        );

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
ALTER TABLE invoice ADD FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`);
ALTER TABLE car ADD FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`);
ALTER TABLE payment_orders ADD FOREIGN KEY (user_id) REFERENCES `user`(user_id);
ALTER TABLE payment_orders ADD FOREIGN KEY (car_id) REFERENCES `car`(car_id);
ALTER TABLE car ADD FOREIGN KEY (location_id) REFERENCES `location`(location_id);




-- Az insurance táblába való beszúrás először, mivel ezt referálja a car tábla
INSERT INTO `insurance` (`insurance_provider`, `coverage_details`, `insurance_fee`, `duration`) VALUES
('Allianz', 'Teljes körű fedezet 500€ önrésszel', 1200.00, 365),
('AXA', 'Csak felelősségbiztosítás', 800.00, 365),
('Generali', 'Átfogó fedezet útmenti segítségnyújtással', 1500.00, 365),
('Zurich', 'Alapfedezet 1000€ önrésszel', 950.00, 365),
('UNIQA', 'Prémium fedezet nulla önrésszel', 1800.00, 365),
('Groupama', 'Normál fedezet bérautó térítéssel', 1100.00, 365),
('Aegon', 'Teljes körű fedezet üvegvédelemmel', 1350.00, 365),
('HDI', 'Katonai kedvezményes átfogó fedezet', 1000.00, 365),
('Ergo', 'Üzleti bérleti fedezet', 1250.00, 365),
('Aviva', 'Családi csomag több vezető fedezettel', 1150.00, 365),
('Vienna Insurance', 'Prémium fedezet baleset-mentességi garanciával', 1650.00, 365),
('Axa Winterthur', 'Kiemelt fedezet személyes tárgyak védelmével', 1750.00, 365),
('Baloise', 'Idősebb vezetők speciális fedezete', 1050.00, 365),
('Direct Line', 'Digitális-első átfogó fedezet', 1300.00, 365),
('Mapfre', 'Költséghatékony alapfedezet', 750.00, 365),
('Helvetia', 'Hitelszövetkezeti tagok speciális fedezete', 900.00, 365),
('Admiral', 'UK speciális fedezeti csomag', 1000.00, 365),
('PZU', 'Prémium fedezet háziállat sérülési védelemmel', 1400.00, 365),
('Talanx', 'Prémium regionális fedezet', 1250.00, 365),
('RSA', 'Északkelet-európai speciális fedezet', 1150.00, 365);

-- Adatok beszúrása a user táblába
INSERT INTO `user` (`user_email`, `user_name`, `password`, `born_at`, `created_at`, `updated_at`, `user_active`, `u_phone_number`, `user_areacode`, `user_role`, `driver_license_number`, `driver_license_expiry`, `profile_picture`) VALUES
('jan.kowalski@email.com', 'Jan Kowalski', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1985-05-15 00:00:00', '2023-01-01 10:00:00', '2023-01-01 10:00:00', 1, '+48 555-123-456', 48, 'user', 'PL123456789', '2027-05-15', 'profile1.jpg'),
('emma.mueller@email.com', 'Emma Müller', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1990-08-22 00:00:00', '2023-01-02 11:30:00', '2023-01-02 11:30:00', 1, '+49 555-234-567', 49, 'user', 'DE987654321', '2028-08-22', 'profile2.jpg'),
('antoine.dupont@email.com', 'Antoine Dupont', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1988-11-05 00:00:00', '2023-01-04 13:45:00', '2023-01-04 13:45:00', 1, '+33 555-456-789', 33, 'user', 'FR654321987', '2026-11-05', 'profile3.jpg'),
('sofia.rossi@email.com', 'Sofia Rossi', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1992-07-18 00:00:00', '2023-01-05 14:20:00', '2023-01-05 14:20:00', 1, '+39 555-567-890', 39, 'user', 'IT789456123', '2027-07-18', 'profile4.jpg'),
('javier.garcia@email.com', 'Javier García', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1983-09-30 00:00:00', '2023-01-06 10:10:00', '2023-01-06 10:10:00', 1, '+34 555-678-901', 34, 'user', 'ES456789123', '2025-09-30', 'profile5.jpg'),
('anna.andersson@email.com', 'Anna Andersson', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1991-04-12 00:00:00', '2023-01-07 11:05:00', '2023-01-07 11:05:00', 1, '+46 555-789-012', 46, 'user', 'SE321654987', '2026-04-12', 'profile6.jpg'),
('niklas.johansson@email.com', 'Niklas Johansson', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1987-02-25 00:00:00', '2023-01-08 15:30:00', '2023-01-08 15:30:00', 1, '+46 555-890-123', 46, 'user', 'SE159753456', '2027-02-25', 'profile7.jpg'),
('lucia.fernandez@email.com', 'Lucia Fernández', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1989-12-08 00:00:00', '2023-01-09 16:45:00', '2023-01-09 16:45:00', 1, '+34 555-901-234', 34, 'user', 'ES753159852', '2028-12-08', 'profile8.jpg'),
('thomas.schmidt@email.com', 'Thomas Schmidt', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1984-06-20 00:00:00', '2023-01-10 09:30:00', '2023-01-10 09:30:00', 1, '+49 555-012-345', 49, 'user', 'DE852456159', '2025-06-20', 'profile9.jpg'),
('maria.silva@email.com', 'Maria Silva', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1993-10-15 00:00:00', '2023-01-11 10:20:00', '2023-01-11 10:20:00', 1, '+351 555-123-987', 351, 'user', 'PT963852741', '2027-10-15', 'profile10.jpg'),
('anders.nielsen@email.com', 'Anders Nielsen', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1986-03-28 00:00:00', '2023-01-12 13:15:00', '2023-01-12 13:15:00', 1, '+45 555-234-876', 45, 'user', 'DK741852963', '2026-03-28', 'profile11.jpg'),
('elisa.marino@email.com', 'Elisa Marino', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1990-01-05 00:00:00', '2023-01-13 14:25:00', '2023-01-13 14:25:00', 1, '+39 555-345-765', 39, 'user', 'IT369258147', '2025-01-05', 'profile12.jpg'),
('markus.wagner@email.com', 'Markus Wagner', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1982-08-17 00:00:00', '2023-01-14 15:35:00', '2023-01-14 15:35:00', 1, '+43 555-456-654', 43, 'user', 'AT147258369', '2026-08-17', 'profile13.jpg'),
('sophie.martin@email.com', 'Sophie Martin', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1991-05-10 00:00:00', '2023-01-15 16:40:00', '2023-01-15 16:40:00', 1, '+33 555-567-543', 33, 'user', 'FR258147369', '2028-05-10', 'profile14.jpg');

-- Adatok beszúrása a location táblába
INSERT INTO `location` (`location`, `zip_code`) VALUES
('Andrássy út 66, Budapest, Magyarország', 1062),
('Váci utca 18, Budapest, Magyarország', 1052),
('Üllői út 131, Budapest, Magyarország', 1091),
('Árpád fejedelem útja 26-28, Budapest, Magyarország', 1023),
('Nagytétényi út 37-43, Budapest, Magyarország', 1223),
('Bocskai út 77-79, Budaörs, Magyarország', 1113),
('Szentendrei út 24, Pomáz, Magyarország', 2011);

-- 14 népszerű autó adatainak beszúrása
INSERT INTO `car` (`car_price`, `car_active`, `car_description`, `car_type`, `seats`, `number_of_doors`, `insurance_id`, `car_model`, `car_regnumber`, `price_per_hour`, `price_per_day`, `car_condition`, `mileage`, `car_year`, `fuel_type`, `transmission_type`, `car_brand`, `location_id`, `verified`) VALUES
('4000', 1, 'Megbízható családi szedán kiváló biztonsági funkciókkal', 'sedan', 5, 5, 1, 'Accord', 'W-AB-1234', 1800, 4000, 'excellent', 35000, 2022, 'hybrid', 'automatic', 'Honda', 1, 1),
('5000', 1, 'Tágas SUV, tökéletes családi utazásokhoz és szabadtéri kalandokhoz', 'suv', 7, 5, 2, 'RAV4', 'M-CD-5678', 2000, 5000, 'excellent', 28000, 2021, 'hybrid', 'automatic', 'Toyota', 5, 1),
('3000', 1, 'Kompakt ferdehátú kiváló városi kezeléssel és üzemanyag-takarékossággal', 'hatchback', 5, 5, 3, 'Golf', 'B-EF-9012', 1200, 6000, 'good', 42000, 2020, 'petrol', 'manual', 'Volkswagen', 6, 1),
('6000', 1, 'Luxus elektromos szedán élvonalbeli technológiával', 'sedan', 5, 5, 4, 'Model 3', 'K-GH-3456', 1400, 7000, 'excellent', 15000, 2022, 'electric', 'automatic', 'Tesla', 7, 1),
('7000', 1, 'Sportkupé erőteljes motorral és dinamikus kezelhetőséggel', 'coupe', 4, 3, 5, 'Mustang', 'F-IJ-7890', 1700, 6000, 'excellent', 20000, 2021, 'petrol', 'manual', 'Ford', 2, 1),
('5000', 1, 'Prémium crossover SUV elegáns dizájnnal és kényelemmel', 'suv', 5, 5, 6, 'CX-5', 'LEV-CX-504', 1500, 8000, 'excellent', 25000, 2022, 'petrol', 'automatic', 'Mazda', 3, 1),
('8000', 1, 'Robusztus pickup nehéz feladatokhoz és kalandokhoz', 'pickup', 5, 5, 7, 'F-150', 'L-MN-5678', 1400, 9000, 'good', 45000, 2020, 'petrol', 'automatic', 'Ford', 5, 1),
('6000', 1, 'Sokoldalú közepes méretű SUV terepjáró képességekkel', 'suv', 5, 5, 8, 'Wrangler', 'F-OP-9012', 1600, 7000, 'excellent', 32000, 2021, 'petrol', 'manual', 'Jeep', 4, 1),
('8000', 1, 'Luxus szedán prémium funkciókkal és sima vezetési élménnyel', 'sedan', 5, 5, 9, 'E-Class', 'S-QR-3456', 1300, 5000, 'excellent', 25000, 2022, 'diesel', 'automatic', 'Mercedes-Benz', 6, 1),
('4000', 1, 'Megbízható kompakt SUV kiváló üzemanyag-hatékonysággal', 'suv', 5, 5, 10, 'CR-V', 'B-ST-7890', 1500, 4000, 'good', 35000, 2021, 'hybrid', 'automatic', 'Honda', 7, 1),
('5000', 1, 'Gazdaságos kompakt szedán modern biztonsági funkciókkal', 'sedan', 5, 5, 11, 'Civic', 'W-UV-1234', 1350, 5500, 'good', 40000, 2020, 'petrol', 'automatic', 'Honda', 4, 1),
('7000', 1, 'Prémium elektromos SUV nagy hatótávolsággal és teljesítménnyel', 'suv', 5, 5, 12, 'Model Y', 'M-WX-5678', 1490, 6700, 'excellent', 18000, 2022, 'electric', 'automatic', 'Tesla', 6, 1),
('4000', 1, 'Stílusos kompakt SUV egyedi dizájnnal', 'suv', 5, 5, 13, 'Sportage', 'B-YZ-9012', 980, 7300, 'good', 30000, 2021, 'petrol', 'automatic', 'Kia', 1, 1),
('9000', 1, 'Prémium luxus SUV élvonalbeli technológiával és kényelemmel', 'suv', 7, 5, 14, 'X5', 'K-CD-7890', 1400, 6050, 'excellent', 22000, 2022, 'hybrid', 'automatic', 'BMW', 3, 1);

-- Adatok beszúrása a car_images táblába (autónként legalább 2 kép)
INSERT INTO `car_images` (`car_id`, `image_url`, `uploaded_at`) VALUES
(1, 'uploads/cars/honda_accord_1.png', '2023-01-01 10:15:00'),
(1, 'uploads/cars/honda_accord_2.png', '2023-01-01 10:16:00'),
(2, 'uploads/cars/c6de9cb1-227d-46bc-9dd2-00ac53937ed2_0bedffec-ec1f-4bc5-aab7-023033fb0ac5.webp', '2023-01-02 11:00:00'),
(2, 'uploads/cars/c6de9cb1-227d-46bc-9dd2-00ac53937ed2_93d66103-09da-49ee-b31a-bd6e9d1307f1.webp', '2023-01-02 11:01:00'),
(2, 'uploads/cars/c6de9cb1-227d-46bc-9dd2-00ac53937ed2_a6897c2a-976e-4d26-b861-d432f3d9a22e.webp', '2023-01-02 11:02:00'),
(2, 'uploads/cars/c6de9cb1-227d-46bc-9dd2-00ac53937ed2_1c7edcc7-6a81-4461-8a57-5e25e0b5d690.webp', '2023-01-02 11:03:00'),
(3, 'uploads/cars/7-2.jpg', '2023-01-03 12:30:00'),
(3, 'uploads/cars/5-2.jpg', '2023-01-03 12:31:00'),
(3, 'uploads/cars/95-1.jpg', '2023-01-03 12:32:00'),
(3, 'uploads/cars/995-1.jpg', '2023-01-03 12:33:00'),
(4, 'uploads/cars/b194debe-dfce-429e-8432-d6c0f9acdaab_d3cefbd8-c964-4c53-a2ad-7397377b5ad0.webp', '2023-01-04 13:15:00'),
(4, 'uploads/cars/b194debe-dfce-429e-8432-d6c0f9acdaab_148f8dfe-835a-4ec5-a278-4e216755e6c4.webp', '2023-01-04 13:16:00'),
(4, 'uploads/cars/b194debe-dfce-429e-8432-d6c0f9acdaab_5c975207-e051-457c-89c2-36fdfa36d1d5.webp', '2023-01-04 13:17:00'),
(5, 'uploads/cars/b6a8b9ef-19cb-3b5a-9f83-48fbaecedcce.jpg', '2023-01-05 14:00:00'),
(5, 'uploads/cars/1d573aac-4663-3966-ae65-38c38f3db01f.jpg', '2023-01-05 14:01:00'),
(5, 'uploads/cars/2c5198c5-f20f-3f72-887e-ff6433088f16.jpg', '2023-01-05 14:02:00'),
(5, 'uploads/cars/a409496d-f07b-354e-aa8f-a91036d60372.jpg', '2023-01-05 14:02:00'),
(6, 'uploads/cars/mazda-cx-5-2022_3.jpg', '2023-01-06 15:29:00'),
(6, 'uploads/cars/mazda-cx-5-2022.jpg', '2023-01-06 15:30:00'),
(6, 'uploads/cars/mazda-cx-5-2022_2.jpg', '2023-01-06 15:31:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_e5b3f9b2-dc9d-46f8-89ad-2c0046c630d3.webp', '2023-01-07 16:00:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_23461772-e95e-4770-b09d-9afcdaf62895.webp', '2023-01-07 16:01:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_fc59059d-b962-4ccf-af94-efa924da5bf8.webp', '2023-01-07 16:02:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_fd6f4856-b792-4f6e-b43c-eb9b374ee22b.webp', '2023-01-07 16:02:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_d7f06267-874c-473f-b8f3-6dbfe201df84.webp', '2023-01-07 16:02:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_bc4fa6ae-1298-49f9-8f31-3c3fab3d6078.webp', '2023-01-07 16:02:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_410bc329-d132-47a2-97aa-8c46852dcf60.webp', '2023-01-07 16:02:00'),
(7, 'uploads/cars/3b382882-e0b4-4b6a-b6d7-8c07379180e0_7e832567-f0a9-4d34-9edc-ea2150026073.webp', '2023-01-07 16:02:00'),
(8, 'uploads/cars/727c5e8f-37a2-4ea1-8bd9-df4d6a53f1b4_b8716b85-0e49-4194-9534-e1c4bff8b9e4.webp', '2023-01-08 10:30:00'),
(8, 'uploads/cars/727c5e8f-37a2-4ea1-8bd9-df4d6a53f1b4_e17e9ffe-0200-4542-baa6-1d85bc263eab.webp', '2023-01-08 10:31:00'),
(8, 'uploads/cars/727c5e8f-37a2-4ea1-8bd9-df4d6a53f1b4_f9c20b41-67a1-4884-ae47-d9b1a3b4a377.webp', '2023-01-08 10:32:00'),
(9, 'uploads/cars/2021-mercedes-benz-e450-4matic-sedan-101-1604280336.avif', '2023-01-09 11:15:00'),
(9, 'uploads/cars/2021-mercedes-benz-e450-4matic-sedan-102-1604280319.avif', '2023-01-09 11:16:00'),
(9, 'uploads/cars/2021-mercedes-benz-e450-4matic-sedan-104-1604280307.avif', '2023-01-09 11:17:00'),
(10, 'uploads/cars/65b795e9-b713-4a2a-ab42-d498990b51bb_89d0080a-63be-4558-bbc2-c9054956308a.webp', '2023-01-10 12:45:00'),
(10, 'uploads/cars65b795e9-b713-4a2a-ab42-d498990b51bb_832baa80-f84c-4122-b46a-19fbb96c28f9.webp', '2023-01-10 12:46:00'),
(10, 'uploads/cars/65b795e9-b713-4a2a-ab42-d498990b51bb_c3149ab1-fed5-4a4f-95ef-c2c6725875b1.webp', '2023-01-10 12:47:00'),
(11, 'uploads/cars/4fb5a1cf-98f4-48e0-838e-a73377d5573c_f29bda02-5095-455a-bcc1-18b191e47004.webp', '2023-01-11 13:30:00'),
(11, 'uploads/cars/4fb5a1cf-98f4-48e0-838e-a73377d5573c_d388c5ee-33fc-4fde-b66d-460cf95069db.webp', '2023-01-11 13:31:00'),
(11, 'uploads/cars/4fb5a1cf-98f4-48e0-838e-a73377d5573c_1b454a7e-2a4f-472a-ae6c-ff0a7e492c4d.webp', '2023-01-11 13:32:00'),
(12, 'uploads/cars/9bd019ab-c9fb-499b-b251-e47c74ab0ebb_3a9d5530-1ad5-407e-a56f-190593d535f7.webp', '2023-01-12 14:15:00'),
(12, 'uploads/cars/9bd019ab-c9fb-499b-b251-e47c74ab0ebb_f8d3d8f7-428d-4a06-adb4-c15b8fa03f91.webp', '2023-01-12 14:16:00'),
(12, 'uploads/cars/9bd019ab-c9fb-499b-b251-e47c74ab0ebb_275836e3-1dae-4029-b553-460adc9b8c6a.webp', '2023-01-12 14:17:00'),
(13, 'uploads/cars/aa440f64-9daa-46b1-90e0-e686487f6d2b_28adb521-07c2-459e-9fa2-2645ad614cf0.webp', '2023-01-13 15:00:00'),
(13, 'uploads/cars/aa440f64-9daa-46b1-90e0-e686487f6d2b_debdf632-543c-46ea-a8ca-02f6e2b6f720.webp', '2023-01-13 15:01:00'),
(13, 'uploads/cars/aa440f64-9daa-46b1-90e0-e686487f6d2b_a51ae837-54f4-4780-9dc1-c003c84c11df.webp', '2023-01-13 15:02:00'),
(13, 'uploads/cars/aa440f64-9daa-46b1-90e0-e686487f6d2b_8a26942e-605d-469a-ac52-243a5dc795d3.webp', '2023-01-13 15:02:00'),
(13, 'uploads/cars/aa440f64-9daa-46b1-90e0-e686487f6d2b_e4aa8008-aaf3-4141-bab7-c50e7a453e76.webp', '2023-01-13 15:02:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_0aa42987-3a32-48ae-b485-75b11a2bb785.webp', '2023-01-14 16:30:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_e7378c27-ec8d-4d97-9b31-b9d35ed2d9fa.webp', '2023-01-14 16:31:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_db8079e1-d923-475a-8c64-0786c1fcfe7c.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_fe86126f-3073-4902-9849-c1c90ffdd5b3.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_33dabfa7-1648-41d5-936b-68d21e17efda.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_e4909c61-177c-4c89-b21a-596c1819de77.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_9b11ab41-c375-4fc6-b9b9-304c4f7c61f7.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_aacfc259-fe94-48db-b598-83ee05115321.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_6c4e7c78-f802-4800-b396-643812b18d3e.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_b7a8e2ba-fb8f-4939-a1bf-767f55532bb1.webp', '2023-01-14 16:32:00'),
(14, 'uploads/cars/d04504ff-66f5-4aa4-aa94-a209bfcdc01a_096dbf77-906a-4406-b51e-b49fdb892c28.webp', '2023-01-14 16:32:00');

-- Adatok beszúrása a car_availability táblába
INSERT INTO `car_availability` (`car_id`, `available_from`, `available_to`) VALUES
(1, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(2, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(3, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(4, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(5, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(6, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(7, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(8, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(9, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(10, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(11, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(12, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(13, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(14, '2023-03-01 00:00:00', '2027-12-31 23:59:59');

-- Adatok beszúrása a car_extras táblába
INSERT INTO `car_extras` (`car_id`, `extra_name`, `extra_price`) VALUES
(1, 'gyermekülés', 10.00),
(1, 'GPS navigáció', 5.00),
(2, 'gyermekülés', 10.00),
(2, 'tetőcsomagtartó', 15.00),
(3, 'gyermekülés', 10.00),
(3, 'GPS navigáció', 5.00),
(4, 'gyermekülés', 15.00),
(4, 'prémium töltőkábel', 10.00),
(5, 'gyermekülés', 10.00),
(5, 'teljesítmény csomag', 25.00),
(6, 'gyermekülés', 10.00),
(6, 'tetőcsomagtartó', 15.00),
(7, 'gyermekülés', 15.00),
(7, 'vontatási csomag', 30.00),
(8, 'gyermekülés', 10.00),
(8, 'terepjáró csomag', 35.00),
(9, 'gyermekülés', 15.00),
(9, 'prémium hangrendszer', 20.00),
(10, 'gyermekülés', 15.00),
(10, 'tetőcsomagtartó', 15.00),
(11, 'gyermekülés', 10.00),
(11, 'GPS navigáció', 5.00),
(12, 'gyermekülés', 15.00),
(12, 'prémium töltőkábel', 10.00),
(13, 'gyermekülés', 10.00),
(13, 'tetőcsomagtartó', 15.00),
(14, 'gyermekülés', 15.00),
(14, 'prémium hangrendszer', 20.00);

-- Adatok beszúrása a car_user táblába (ki birtokolja/kezeli melyik autókat)
INSERT INTO `car_user` (`car_id`, `user_id`) VALUES
(1, 3), 
(2, 3),
(3, 3),
(4, 3),
(5, 3),
(6, 5),
(7, 5),
(8, 7),
(9, 7),
(10, 9),
(11, 9),
(12, 11),
(13, 11),
(14, 13);


-- Adatok beszúrása az orders táblába
INSERT INTO `orders` (`user_id`, `car_id`, `start_date`, `end_date`, `rental_status`, `location_id`, `payment_status`, `discount_code`, `extended_rental`) VALUES
(1, 2, '2023-03-10 10:00:00', '2023-03-12 10:00:00', 'completed', 1, 'paid', 'SPRING10', 0),
(2, 4, '2023-03-15 09:00:00', '2023-03-16 09:00:00', 'completed', 2, 'paid', '', 0),
(4, 6, '2023-03-20 11:00:00', '2023-03-25 11:00:00', 'completed', 3, 'paid', 'WELCOME15', 0),
(5, 8, '2023-04-05 14:00:00', '2023-04-07 14:00:00', 'completed', 4, 'paid', '', 0),
(6, 10, '2023-04-10 12:00:00', '2023-04-15 12:00:00', 'completed', 5, 'paid', 'LOYALTY20', 0),
(7, 12, '2023-04-20 15:00:00', '2023-04-22 15:00:00', 'completed', 6, 'paid', '', 0),
(8, 14, '2023-05-01 09:30:00', '2023-05-05 09:30:00', 'completed', 7, 'paid', '', 0),
(12, 1, '2023-06-01 08:00:00', '2023-06-03 08:00:00', 'completed', 1, 'paid', 'SUMMER15', 0),
(13, 3, '2023-06-05 11:30:00', '2023-06-10 11:30:00', 'completed', 2, 'paid', '', 0),
(14, 5, '2023-06-15 13:00:00', '2023-06-17 13:00:00', 'completed', 3, 'paid', '', 0),
(2, 2, '2023-08-15 09:00:00', '2023-08-17 09:00:00', 'completed', 4, 'paid', '', 0),
(3, 4, '2023-08-20 12:00:00', '2023-08-25 12:00:00', 'completed', 5, 'paid', '', 0),
(4, 6, '2023-09-01 14:30:00', '2023-09-03 14:30:00', 'completed', 6, 'paid', 'FALL10', 0),
(5, 8, '2023-09-10 10:00:00', '2023-09-15 10:00:00', 'completed', 7, 'paid', '', 0),
(1, 3, '2023-10-05 09:00:00', '2023-10-06 09:00:00', 'confirmed', 2, 'paid', '', 0),
(2, 5, '2023-10-10 13:00:00', '2023-10-15 13:00:00', 'confirmed', 6, 'paid', 'OCT20', 0),
(6, 7, '2023-10-20 11:30:00', '2023-10-22 11:30:00', 'confirmed', 7, 'paid', '', 0),
(4, 9, '2023-11-01 10:00:00', '2023-11-05 10:00:00', 'pending', 3, 'pending', '', 0),
(5, 11, '2023-11-10 14:00:00', '2023-11-12 14:00:00', 'pending', 2, 'pending', 'NOV15', 0),
(6, 13, '2023-11-15 12:30:00', '2023-11-20 12:30:00', 'pending', 1, 'pending', '', 0);

-- Adatok beszúrása az invoice táblába
INSERT INTO `invoice` (`orders_id`, `insurance_id`, `payment_amount`, `tax_amount`, `payment_method`, `payment_status`, `payment_date`, `invoice_address`) VALUES
(1, 2, 350.00, 28.00, 'credit_card', 'paid', '2023-03-10 10:15:00', 'ul. Nowy Świat 12, Varsó, Lengyelország'),
(2, 4, 300.00, 24.00, 'paypal', 'paid', '2023-03-15 09:15:00', 'Friedrichstraße 123, Berlin, Németország'),
(3, 6, 750.00, 60.00, 'credit_card', 'paid', '2023-03-20 11:15:00', 'Rue de Rivoli 45, Párizs, Franciaország'),
(4, 8, 350.00, 28.00, 'bank_transfer', 'paid', '2023-04-05 14:15:00', 'Via del Corso 37, Róma, Olaszország'),
(5, 10, 1000.00, 80.00, 'credit_card', 'paid', '2023-04-10 12:15:00', 'Calle de Alcalá 25, Madrid, Spanyolország'),
(6, 12, 550.00, 44.00, 'paypal', 'paid', '2023-04-20 15:15:00', 'Regent Street 55, London, Egyesült Királyság'),
(7, 14, 600.00, 48.00, 'credit_card', 'paid', '2023-05-01 09:45:00', 'Kärntner Straße 28, Bécs, Ausztria'),
(8, 16, 100.00, 8.00, 'bank_transfer', 'paid', '2023-05-10 13:15:00', 'Kalverstraat 12, Amszterdam, Hollandia'),
(9, 18, 750.00, 60.00, 'credit_card', 'paid', '2023-05-15 10:15:00', 'Strøget 34, Koppenhága, Dánia'),
(10, 20, 750.00, 60.00, 'paypal', 'paid', '2023-05-25 14:45:00', 'Váci utca 45, Budapest, Magyarország'),
(11, 1, 250.00, 20.00, 'credit_card', 'paid', '2023-06-01 08:15:00', 'Marszałkowska 78, Varsó, Lengyelország'),
(12, 3, 500.00, 40.00, 'bank_transfer', 'paid', '2023-06-05 11:45:00', 'Rua Augusta 67, Lisszabon, Portugália'),
(13, 5, 450.00, 36.00, 'credit_card', 'paid', '2023-06-15 13:15:00', 'Schadowstraße 42, Düsseldorf, Németország'),
(14, 7, 1000.00, 80.00, 'paypal', 'paid', '2023-06-20 09:15:00', 'Las Ramblas 56, Barcelona, Spanyolország'),
(15, 9, 500.00, 40.00, 'credit_card', 'paid', '2023-07-01 12:15:00', 'Rue Neuve 23, Brüsszel, Belgium'),
(16, 11, 1250.00, 100.00, 'bank_transfer', 'paid', '2023-07-05 15:45:00', 'Paradeplatz 8, Zürich, Svájc'),
(17, 13, 100.00, 8.00, 'credit_card', 'paid', '2023-07-15 10:15:00', 'Ráday utca 15, Budapest, Magyarország'),
(18, 15, 1250.00, 100.00, 'paypal', 'paid', '2023-07-20 14:15:00', 'Via Montenapoleone 22, Milánó, Olaszország'),
(19, 17, 400.00, 32.00, 'credit_card', 'paid', '2023-08-01 11:15:00', 'Drottninggatan 31, Stockholm, Svédország'),
(20, 19, 1375.00, 110.00, 'credit_card', 'paid', '2023-08-05 13:45:00', 'Szintagma tér 9, Athén, Görögország');

-- Adatok beszúrása a comment táblába
INSERT INTO `comment` (`user_id`, `car_id`, `comment_message`, `comment_star`, `comment_date`, `rating_category`, `comment_flagged`) VALUES 
-- Honda Accord (car_id: 1)
(1, 1, 'Kényelmes vezetési élmény és kiváló üzemanyag-fogyasztás. A hibrid rendszer hibátlanul működik.', 5, '2023-03-10 14:20:00', 'performance', 0),
(2, 1, 'Nagyszerű családi szedán bőséges lábtérrel. A gyerekeim imádták a tágas hátsó üléseket.', 4, '2023-04-05 09:45:00', 'comfort', 0),
(3, 1, 'Az infotainment rendszer eleinte kissé bonyolult használni, de jól működik, ha hozzászoksz.', 3, '2023-05-12 16:30:00', 'safety', 0),

-- Toyota RAV4 (car_id: 2)
(1, 2, 'Remek SUV családi utazásunkhoz az Alpokba. Rengeteg hely és nagyon kényelmes.', 5, '2023-03-13 15:30:00', 'comfort', 0),
(5, 2, 'A hibrid rendszer kiváló üzemanyag-takarékosságot biztosít még városi vezetés során is.', 5, '2023-04-18 10:20:00', 'fuel_efficiency', 0),
(6, 2, 'Jó kezelhetőség egy SUV-hoz képest, de a sávtartó asszisztens túl agresszív.', 4, '2023-05-25 14:10:00', 'performance', 0),
(7, 2, 'Rengeteg csomagtér. Az összes kempingfelszerelésünket befogadta és még maradt is hely.', 5, '2023-07-03 09:00:00', 'fuel_efficiency', 0),

-- Volkswagen Golf (car_id: 3)
(8, 3, 'Élvezet vezetni, jól reagál. Tökéletes városi közlekedéshez.', 4, '2023-03-15 16:45:00', 'performance', 0),
(9, 3, 'A kézi sebességváltó finoman működik, de a városi forgalom egy idő után fárasztóvá tette.', 3, '2023-04-22 11:30:00', 'comfort', 0),
(10, 3, 'Kiváló üzemanyag-takarékosság és a kompakt méret megkönnyíti a parkolást.', 5, '2023-06-05 13:25:00', 'safety', 0),
(11, 3, 'A belső tér prémium érzetet kelt a kategóriájában. Jól megépített, minőségi anyagokkal.', 4, '2023-07-18 15:40:00', 'safety', 0),

-- Tesla Model 3 (car_id: 4)
(12, 4, 'Hihetetlen gyorsulás és kezelhetőség. Olyan, mintha egy sportkocsit vezetnél.', 5, '2023-03-18 10:15:00', 'performance', 0),
(13, 4, 'A minimalista belső térhez szokni kell, de jól működik.', 4, '2023-04-26 14:30:00', 'performance', 0),
(14, 4, 'Az autopilot funkció sokkal kevésbé stresszessé tette az autópályán való ingázásomat.', 5, '2023-06-10 09:20:00', 'comfort', 0),
(10, 4, 'A hatótávolsággal kapcsolatos aggodalom nem volt probléma. Rengeteg töltőállomás volt az útvonalunkon.', 4, '2023-07-22 11:45:00', 'comfort', 0),

-- Ford Mustang (car_id: 5)
(1, 5, 'Hihetetlen teljesítmény és motorhang. Igazi amerikai izomautó élmény.', 5, '2023-03-20 13:40:00', 'performance', 0),
(13, 5, 'Az üzemanyag-fogyasztás gyenge, de ez várható ekkora teljesítménynél.', 2, '2023-07-28 14:10:00', 'fuel_efficiency', 0),

-- Mazda CX-5 (car_id: 6)
(3, 6, 'Prémium érzés prémium ár nélkül. A belső tér minősége kivételes.', 5, '2023-03-22 11:25:00', 'safety', 0),
(2, 6, 'Úgy kezelhető, mint egy szedán, annak ellenére, hogy SUV. Nagyon lenyűgöztek a vezetési dinamikák.', 5, '2023-05-08 13:45:00', 'performance', 0),

-- Ford F-150 (car_id: 7)
(11, 7, 'Az üzemanyag-fogyasztás olyan, mint amit egy teljes méretű teherautótól várnál - nem túl jó.', 2, '2023-06-25 13:40:00', 'fuel_efficiency', 0),
(12, 7, 'A platóméret és a funkciók tökéletesek az építőipari vállalkozásomhoz.', 5, '2023-08-07 11:05:00', 'safety', 0),

-- Jeep Wrangler (car_id: 8)
(9, 8, 'Terepen vezettem és hibátlanul teljesített. Igazi terepjáró szörnyeteg.', 5, '2023-03-28 10:10:00', 'performance', 0),
(13, 8, 'Az autópályán zajos a vezetés és az utazás rázós, de ez része a Jeep élménynek.', 3, '2023-05-15 15:30:00', 'comfort', 0),
(1, 8, 'Az ajtók és a tető leszerelése nagyszerű mulatság volt a nyári vezetéshez.', 5, '2023-06-30 14:25:00', 'value_for_money', 0),

-- Mercedes-Benz E-Class (car_id: 9)
(10, 9, 'Luxus belső tér kivételes építési minőséggel. Minden részlet tökéletes.', 5, '2023-03-30 13:20:00', 'value_for_money', 0),
(14, 9, 'Sima és csendes vezetés még durva utakon is. Tökéletes a hosszú utazásokhoz.', 5, '2023-05-18 11:40:00', 'comfort', 0),
(8, 9, 'Kiváló dízelmotor meglepő hatékonysággal a méretéhez képest.', 4, '2023-08-15 10:30:00', 'fuel_efficiency', 0),

-- Honda CR-V (car_id: 10)
(3, 10, 'Tökéletes családi SUV kiváló biztonsági funkciókkal.', 5, '2023-04-02 15:45:00', 'safety', 0),
(10, 10, 'A hibrid rendszer sima és kiváló üzemanyag-takarékosságot biztosít.', 5, '2023-05-22 12:20:00', 'fuel_efficiency', 0),
(2, 10, 'A csomagtér kiváló. Könnyen befogadja az összes poggyászunkat a családi utazásokhoz.', 4, '2023-07-10 09:35:00', 'performance', 0),
(7, 10, 'A kezelhetőség jó, de nem olyan sportos, mint néhány versenytársé.', 3, '2023-08-20 14:50:00', 'performance', 0),

-- Honda Civic (car_id: 11)
(10, 11, 'Kiváló mindennapi használatra, jó üzemanyag-fogyasztással.', 4, '2023-04-05 10:30:00', 'efficiency', 0),
(11, 11, 'A belső tér elegánsabb, mint a korábbi generációknál.', 4, '2023-05-25 16:15:00', 'quality', 0),
(12, 11, 'Az olyan biztonsági funkciók, mint az adaptív sebességtartó automatika, remekül működnek.', 5, '2023-07-12 11:25:00', 'safety', 0),
(13, 11, 'Autópályán kissé zajos, de kényelmes a napi ingázáshoz.', 3, '2023-08-23 13:40:00', 'comfort', 0),

-- Tesla Model Y (car_id: 12)
(14, 12, 'Hihetetlen teljesítmény egy SUV-tól. A gyorsulás lenyűgöző.', 5, '2023-04-08 14:10:00', 'performance', 0),
(4, 12, 'A minimalista belső tér egyszerre gyönyörű és funkcionális.', 5, '2023-05-30 10:45:00', 'value_for_money', 0),
(6, 12, 'Az autopilot sokkal kevésbé fárasztóvá tette hosszú utazásunkat.', 5, '2023-07-15 15:30:00', 'safety', 0),
(7, 12, 'Néhány minőségi probléma a panelek illesztésénél, de semmi komoly.', 3, '2023-08-27 11:15:00', 'comfort', 0),

-- Kia Sportage (car_id: 13)
(8, 13, 'Remek ár-érték arány. Sok funkció az árhoz képest.', 4, '2023-04-12 09:25:00', 'comfort', 0),
(9, 13, 'Az új dizájn figyelemfelkeltő és kitűnik a többi SUV közül.', 5, '2023-06-02 13:50:00', 'safety', 0),
(5, 13, 'Kényelmes utazás, de a kezelhetőség lehetne jobb is.', 3, '2023-07-18 10:35:00', 'performance', 0),

-- BMW X5 (car_id: 14)
(2, 14, 'Úgy vezethető, mint egy sportkocsi, a mérete ellenére. Hihetetlen kezelhetőség.', 5, '2023-04-15 11:40:00', 'performance', 0),
(13, 14, 'Luxus belső tér kivételes kényelemmel minden utas számára.', 5, '2023-06-05 14:30:00', 'comfort', 0),
(4, 14, 'A hibrid rendszer jó hatékonyságot biztosít egy nagy SUV-hoz képest.', 4, '2023-07-22 09:15:00', 'value_for_money', 0),
(14, 14, 'A technológiai funkciók átfogóak, de a kezelőfelülethez idő kell, míg megszokja az ember.', 4, '2023-09-02 12:45:00', 'safety', 0);

-- Adatok beszúrása a user_reviews táblába (felhasználók értékelései más felhasználókról)
INSERT INTO `user_reviews` (`reviewer_user_id`, `reviewee_user_id`, `review_message`, `review_rating`, `review_date`) VALUES
(1, 11, 'Kiváló kommunikáció és az autót kitűnő állapotban hozta vissza.', 5, '2023-06-04 14:30:00'),
(11, 1, 'Nagyon barátságos és professzionális bérlő, szívesen bérelnék neki újra.', 5, '2023-06-04 15:00:00'),
(2, 12, 'Tisztán és tele tankkal hozta vissza az autót.', 5, '2023-07-04 11:45:00'),
(12, 2, 'Könnyű átvételi és visszaadási folyamat Berlinben, nagyon elégedett vagyok.', 5, '2023-07-04 12:15:00'),
(3, 13, 'Jó kommunikáció a bérlési időszak alatt Rómában.', 4, '2023-08-26 18:00:00'),
(13, 3, 'Az autó a leírtak szerint volt, nem volt probléma a bérléssel Párizsban.', 4, '2023-08-26 18:30:00'),
(4, 14, 'Az autót kevesebb üzemanyaggal hozta vissza, mint megegyeztünk Barcelonában.', 3, '2023-09-04 13:30:00'),
(14, 4, 'Némi félreértés volt az átvételi hellyel kapcsolatban Bécsben, de egyébként rendben volt.', 3, '2023-09-04 14:00:00'),
(5, 6, 'Kiváló bérlő, az autót tökéletes állapotban hozta vissza Lisszabonban.', 5, '2023-09-16 11:30:00'),
(6, 5, 'Nagyon zökkenőmentes bérlési folyamat Madridban, szívesen bérelnék újra.', 5, '2023-09-16 12:00:00'),
(7, 8, 'Jó kommunikáció, de késve hozta vissza az autót a londoni irodánkba.', 3, '2023-07-04 11:00:00'),
(8, 7, "Az autónak voltak olyan problémái, amiket nem említettek a római hirdetésben.", 2, '2023-07-04 11:30:00'),
(9, 7, "Tökéletes bérlési élmény Stockholmban, nagyon ajánlom.", 5, '2023-07-11 15:00:00'),
(1, 9, 'Az autó tiszta és remek állapotban volt a koppenhágai utazásunkhoz.', 5, '2023-07-11 15:30:00');

INSERT INTO `notifications` (`user_id`, `message`, `status`, `created_at`) VALUES
(1, 'A Škoda Kodiaq berlini bérlése visszaigazolásra került.', 'read', '2023-03-09 14:30:00'),
(2, 'Az Audi A5 párizsi bérlése visszaigazolásra került.', 'read', '2023-03-14 16:45:00'),
(4, 'A Volvo V60 római bérlése visszaigazolásra került.', 'read', '2023-03-19 12:00:00'),
(5, 'A Renault Espace madridi bérlése visszaigazolásra került.', 'read', '2023-04-04 15:30:00'),
(6, 'A Hyundai Tucson londoni bérlése visszaigazolásra került.', 'read', '2023-04-09 11:15:00'),
(7, 'A Tesla Model 3 bécsi bérlése visszaigazolásra került.', 'read', '2023-04-19 14:00:00'),
(8, 'A SEAT Leon amszterdami bérlése visszaigazolásra került.', 'read', '2023-04-30 10:30:00'),
(9, 'A Fiat Tipo koppenhágai bérlése visszaigazolásra került.', 'read', '2023-05-09 13:45:00'),
(10, 'A Renault Captur budapesti bérlése visszaigazolásra került.', 'read', '2023-05-14 15:00:00'),
(11, 'A Volkswagen Passat genfi bérlése visszaigazolásra került.', 'read', '2023-05-24 16:15:00'),
(12, 'Az Opel Insignia varsói bérlése visszaigazolásra került.', 'read', '2023-05-31 09:30:00'),
(13, 'A Volkswagen Golf lisszaboni bérlése visszaigazolásra került.', 'read', '2023-06-04 11:45:00'),
(14, 'A BMW M4 düsseldorfi bérlése visszaigazolásra került.', 'read', '2023-06-14 14:00:00'),
(1, 'A BMW 4 Series athéni bérlése visszaigazolásra került.', 'read', '2023-08-04 15:00:00'),
(2, 'A Škoda Kodiaq berlini bérlése visszaigazolásra került.', 'read', '2023-08-14 17:15:00'),
(3, 'Az Audi A5 párizsi bérlése visszaigazolásra került.', 'read', '2023-08-19 10:45:00'),
(4, 'A Volvo V60 római bérlése visszaigazolásra került.', 'read', '2023-08-31 13:00:00'),
(5, 'A Renault Espace madridi bérlése visszaigazolásra került.', 'read', '2023-09-09 15:15:00'),
(1, 'A Volkswagen Golf londoni bérlése holnap esedékes.', 'unread', '2023-10-04 09:00:00'),
(2, 'A BMW M4 bécsi bérlése holnap esedékes.', 'unread', '2023-10-09 09:00:00'),
(6, 'A Ford Ranger amszterdami bérlése holnap esedékes.', 'unread', '2023-10-19 09:00:00'),
(4, 'Kérjük, töltse ki profilját a jobb autóajánlásokért Európa-szerte.', 'unread', '2023-10-25 14:30:00'),
(5, 'Speciális őszi hétvégi kedvezmény elérhető a következő bérlésénél bármely európai városban.', 'unread', '2023-10-28 10:15:00');