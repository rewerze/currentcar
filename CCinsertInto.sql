-- Insert data into insurance table first as it's referenced by car table
INSERT INTO `insurance` (`insurance_provider`, `coverage_details`, `insurance_fee`, `duration`) VALUES
('Allianz', 'Full coverage with €500 deductible', 1200.00, 365),
('AXA', 'Liability only coverage', 800.00, 365),
('Generali', 'Comprehensive coverage with roadside assistance', 1500.00, 365),
('Zurich', 'Basic coverage with €1000 deductible', 950.00, 365),
('UNIQA', 'Premium coverage with zero deductible', 1800.00, 365),
('Groupama', 'Standard coverage with rental reimbursement', 1100.00, 365),
('Aegon', 'Full coverage with glass protection', 1350.00, 365),
('HDI', 'Military discount comprehensive coverage', 1000.00, 365),
('Ergo', 'Business rental coverage', 1250.00, 365),
('Aviva', 'Family plan with multiple driver coverage', 1150.00, 365),
('Vienna Insurance', 'Premium coverage with accident forgiveness', 1650.00, 365),
('Axa Winterthur', 'Superior coverage with personal item protection', 1750.00, 365),
('Baloise', 'Senior driver special coverage', 1050.00, 365),
('Direct Line', 'Digital-first comprehensive coverage', 1300.00, 365),
('Mapfre', 'Budget friendly basic coverage', 750.00, 365),
('Helvetia', 'Credit union member special coverage', 900.00, 365),
('Admiral', 'UK special coverage package', 1000.00, 365),
('PZU', 'Premium coverage with pet injury protection', 1400.00, 365),
('Talanx', 'Premium regional coverage', 1250.00, 365),
('RSA', 'Northeastern Europe special coverage', 1150.00, 365);

-- Insert data into user table
INSERT INTO `user` (`user_email`, `user_name`, `password`, `born_at`, `created_at`, `updated_at`, `user_active`, `u_phone_number`, `user_areacode`, `user_role`, `driver_license_number`, `driver_license_expiry`, `profile_picture`) VALUES
('jan.kowalski@email.com', 'Jan Kowalski', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1985-05-15 00:00:00', '2023-01-01 10:00:00', '2023-01-01 10:00:00', 1, '+48 555-123-456', 48, 'user', 'PL123456789', '2027-05-15', 'profile1.jpg'),
('emma.mueller@email.com', 'Emma Müller', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1990-08-22 00:00:00', '2023-01-02 11:30:00', '2023-01-02 11:30:00', 1, '+49 555-234-567', 49, 'user', 'DE987654321', '2028-08-22', 'profile2.jpg'),
('admin@carrent.eu', 'Admin User', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1980-03-10 00:00:00', '2023-01-03 09:15:00', '2023-01-03 09:15:00', 1, '+32 555-345-678', 32, 'admin', 'BE567891234', '2026-03-10', 'admin.jpg'),
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
('sophie.martin@email.com', 'Sophie Martin', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1991-05-10 00:00:00', '2023-01-15 16:40:00', '2023-01-15 16:40:00', 1, '+33 555-567-543', 33, 'user', 'FR258147369', '2028-05-10', 'profile14.jpg'),
('rafael.santos@email.com', 'Rafael Santos', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1988-09-22 00:00:00', '2023-01-16 09:50:00', '2023-01-16 09:50:00', 1, '+351 555-678-432', 351, 'user', 'PT654987321', '2027-09-22', 'profile15.jpg'),
('katarzyna.nowak@email.com', 'Katarzyna Nowak', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1985-11-30 00:00:00', '2023-01-17 10:55:00', '2023-01-17 10:55:00', 1, '+48 555-789-321', 48, 'user', 'PL987321654', '2025-11-30', 'profile16.jpg'),
('viktor.kovacs@email.com', 'Viktor Kovács', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1994-02-14 00:00:00', '2023-01-18 11:10:00', '2023-01-18 11:10:00', 1, '+36 555-890-210', 36, 'user', 'HU321789654', '2028-02-14', 'profile17.jpg'),
('pierre.dubois@email.com', 'Pierre Dubois', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1983-04-05 00:00:00', '2023-01-19 12:15:00', '2023-01-19 12:15:00', 1, '+33 555-901-098', 33, 'user', 'FR654123789', '2026-04-05', 'profile18.jpg'),
('elena.popescu@email.com', 'Elena Popescu', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1990-07-12 00:00:00', '2023-01-20 13:20:00', '2023-01-20 13:20:00', 1, '+40 555-012-987', 40, 'user', 'RO789456123', '2027-07-12', 'profile19.jpg'),
('dimitris.papadopoulos@email.com', 'Dimitris Papadopoulos', '$2a$10$Ks9hzUMJHnZ5o3NpNPm5dujjrB6X.u3Yc6pQzQYoVjHg4Ln.N5nYO', '1987-12-25 00:00:00', '2023-01-21 14:25:00', '2023-01-21 14:25:00', 1, '+30 555-123-876', 30, 'user', 'GR123789456', '2026-12-25', 'profile20.jpg');

-- Insert data into car table
INSERT INTO `car` (`car_price`, `car_active`, `car_description`, `car_type`, `seats`, `number_of_doors`, `insurance_id`, `car_model`, `car_regnumber`, `price_per_hour`, `price_per_day`, `car_condition`, `mileage`, `car_year`, `fuel_type`, `transmission_type`, `car_brand`) VALUES
('28000', 1, 'Reliable family sedan with excellent fuel economy', 'sedan', 5, 4, 1, 'Insignia', 'W-AB-1234', 25, 125, 'excellent', 35000, 2020, 'diesel', 'automatic', 'Opel'),
('32000', 1, 'Spacious SUV perfect for family trips', 'suv', 7, 5, 2, 'Kodiaq', 'M-CD-5678', 35, 175, 'excellent', 28000, 2021, 'diesel', 'automatic', 'Škoda'),
('24500', 1, 'Compact hatchback with great city handling', 'hatchback', 5, 5, 3, 'Golf', 'B-EF-9012', 20, 100, 'good', 42000, 2019, 'petrol', 'manual', 'Volkswagen'),
('65000', 1, 'Luxury convertible for special occasions', 'convertible', 4, 2, 4, 'A5', 'K-GH-3456', 60, 300, 'excellent', 15000, 2022, 'petrol', 'automatic', 'Audi'),
('45000', 1, 'Sporty coupe with powerful engine', 'coupe', 4, 2, 5, 'M4', 'F-IJ-7890', 45, 225, 'excellent', 20000, 2021, 'petrol', 'manual', 'BMW'),
('26000', 1, 'Practical wagon with ample cargo space', 'wagon', 5, 5, 6, 'V60', 'S-KL-1234', 30, 150, 'good', 38000, 2020, 'diesel', 'automatic', 'Volvo'),
('35000', 1, 'Robust pickup truck for heavy duty tasks', 'pickup', 5, 4, 7, 'Ranger', 'L-MN-5678', 40, 200, 'good', 45000, 2019, 'diesel', 'automatic', 'Ford'),
('32000', 1, 'Spacious minivan for large families', 'minivan', 8, 4, 8, 'Espace', 'F-OP-9012', 35, 175, 'excellent', 32000, 2020, 'diesel', 'automatic', 'Renault'),
('42000', 1, 'Luxury sedan with premium features', 'sedan', 5, 4, 9, 'E-Class', 'S-QR-3456', 50, 250, 'excellent', 25000, 2021, 'diesel', 'automatic', 'Mercedes-Benz'),
('38000', 1, 'Mid-size SUV with off-road capabilities', 'suv', 5, 5, 10, 'Tucson', 'B-ST-7890', 40, 200, 'good', 35000, 2020, 'hybrid', 'automatic', 'Hyundai'),
('22000', 1, 'Economical compact sedan', 'sedan', 5, 4, 11, 'Corolla', 'W-UV-1234', 20, 100, 'good', 40000, 2019, 'hybrid', 'automatic', 'Toyota'),
('55000', 1, 'High-performance electric sedan', 'sedan', 5, 4, 12, 'Model 3', 'M-WX-5678', 55, 275, 'excellent', 18000, 2022, 'electric', 'automatic', 'Tesla'),
('30000', 1, 'Compact SUV with good fuel efficiency', 'suv', 5, 5, 13, 'Qashqai', 'B-YZ-9012', 30, 150, 'good', 30000, 2020, 'petrol', 'manual', 'Nissan'),
('27000', 1, 'Versatile hatchback with spacious interior', 'hatchback', 5, 5, 14, 'Leon', 'E-AB-3456', 25, 125, 'good', 35000, 2019, 'petrol', 'manual', 'SEAT'),
('85000', 1, 'Premium luxury SUV with cutting-edge technology', 'suv', 7, 5, 15, 'Q7', 'K-CD-7890', 70, 350, 'excellent', 12000, 2022, 'hybrid', 'automatic', 'Audi'),
('20000', 1, 'Budget-friendly compact car', 'sedan', 5, 4, 16, 'Tipo', 'I-EF-1234', 20, 100, 'good', 45000, 2018, 'petrol', 'manual', 'Fiat'),
('38000', 1, 'Mid-size pickup with excellent towing capacity', 'pickup', 5, 4, 17, 'Hilux', 'F-GH-5678', 40, 200, 'good', 38000, 2020, 'diesel', 'manual', 'Toyota'),
('29000', 1, 'Practical crossover SUV for daily use', 'suv', 5, 5, 18, 'Captur', 'F-IJ-9012', 30, 150, 'good', 40000, 2019, 'petrol', 'automatic', 'Renault'),
('60000', 1, 'Luxury coupe with sporty handling', 'coupe', 4, 2, 19, '4 Series', 'M-KL-3456', 55, 275, 'excellent', 22000, 2021, 'petrol', 'automatic', 'BMW'),
('34000', 1, 'Comfortable mid-size sedan with advanced safety features', 'sedan', 5, 4, 20, 'Passat', 'B-MN-7890', 30, 150, 'excellent', 28000, 2020, 'diesel', 'automatic', 'Volkswagen');

-- Insert data into car_images table
INSERT INTO `car_images` (`car_id`, `image_url`, `uploaded_at`) VALUES
(1, 'cars/insignia1.jpg', '2023-01-01 10:15:00'),
(1, 'cars/insignia2.jpg', '2023-01-01 10:16:00'),
(1, 'cars/insignia3.jpg', '2023-01-01 10:17:00'),
(2, 'cars/kodiaq1.jpg', '2023-01-02 11:00:00'),
(2, 'cars/kodiaq2.jpg', '2023-01-02 11:01:00'),
(3, 'cars/golf1.jpg', '2023-01-03 12:30:00'),
(3, 'cars/golf2.jpg', '2023-01-03 12:31:00'),
(4, 'cars/audi_a5_1.jpg', '2023-01-04 13:15:00'),
(4, 'cars/audi_a5_2.jpg', '2023-01-04 13:16:00'),
(5, 'cars/bmw_m4_1.jpg', '2023-01-05 14:00:00'),
(5, 'cars/bmw_m4_2.jpg', '2023-01-05 14:01:00'),
(6, 'cars/volvo_v60_1.jpg', '2023-01-06 15:30:00'),
(7, 'cars/ranger1.jpg', '2023-01-07 16:00:00'),
(8, 'cars/espace1.jpg', '2023-01-08 10:30:00'),
(9, 'cars/eclass1.jpg', '2023-01-09 11:15:00'),
(10, 'cars/tucson1.jpg', '2023-01-10 12:45:00'),
(11, 'cars/corolla1.jpg', '2023-01-11 13:30:00'),
(12, 'cars/model3_1.jpg', '2023-01-12 14:15:00'),
(13, 'cars/qashqai1.jpg', '2023-01-13 15:00:00'),
(14, 'cars/leon1.jpg', '2023-01-14 16:30:00'),
(15, 'cars/q7_1.jpg', '2023-01-15 10:00:00'),
(16, 'cars/tipo1.jpg', '2023-01-16 11:45:00'),
(17, 'cars/hilux1.jpg', '2023-01-17 12:30:00'),
(18, 'cars/captur1.jpg', '2023-01-18 13:15:00'),
(19, 'cars/4series1.jpg', '2023-01-19 14:00:00'),
(20, 'cars/passat1.jpg', '2023-01-20 15:30:00');

-- Insert data into car_availability table
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
(14, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(15, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(16, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(17, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(18, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(19, '2023-03-01 00:00:00', '2027-12-31 23:59:59'),
(20, '2023-03-01 00:00:00', '2027-12-31 23:59:59');

-- Insert data into car_extras table
INSERT INTO `car_extras` (`car_id`, `extra_name`, `extra_price`) VALUES
(1, 'baby seat', 10.00),
(2, 'baby seat', 10.00),
(3, 'baby seat', 10.00),
(4, 'baby seat', 15.00),
(5, 'baby seat', 10.00),
(6, 'baby seat', 10.00),
(7, 'baby seat', 15.00),
(8, 'baby seat', 10.00),
(9, 'baby seat', 15.00),
(10, 'baby seat', 15.00),
(11, 'baby seat', 10.00),
(12, 'baby seat', 15.00),
(13, 'baby seat', 10.00),
(14, 'baby seat', 10.00),
(15, 'baby seat', 15.00),
(16, 'baby seat', 10.00),
(17, 'baby seat', 15.00),
(18, 'baby seat', 10.00),
(19, 'baby seat', 15.00),
(20, 'baby seat', 10.00);

-- Insert data into car_user table (who owns/manages which cars)
INSERT INTO `car_user` (`car_id`, `user_id`) VALUES
(1, 3),  -- Admin manages several cars
(2, 3),
(3, 3),
(4, 3),
(5, 3),
(6, 5),  -- Some users also manage cars
(7, 7),
(8, 9),
(9, 11),
(10, 13),
(11, 15),
(12, 17),
(13, 19),
(14, 3),
(15, 3),
(16, 4),
(17, 6),
(18, 8),
(19, 10),
(20, 12);

-- Insert data into location table
INSERT INTO `location` (`pickup_location`, `dropoff_location`, `longitude`, `latitude`) VALUES
('Kurfürstendamm 23, Berlin, Germany', 'Kurfürstendamm 23, Berlin, Germany', 13, 52),
('Champs-Élysées 45, Paris, France', 'Champs-Élysées 45, Paris, France', 2, 48),
('Via Veneto 12, Rome, Italy', 'Via Veneto 12, Rome, Italy', 12, 41),
('Gran Vía 35, Madrid, Spain', 'Gran Vía 35, Madrid, Spain', -3, 40),
('Oxford Street 78, London, UK', 'Oxford Street 78, London, UK', 0, 51),
('Ringstrasse 15, Vienna, Austria', 'Ringstrasse 15, Vienna, Austria', 16, 48),
('Dam Square 4, Amsterdam, Netherlands', 'Dam Square 4, Amsterdam, Netherlands', 4, 52),
('Nyhavn 19, Copenhagen, Denmark', 'Nyhavn 19, Copenhagen, Denmark', 12, 55),
('Andrássy út 66, Budapest, Hungary', 'Andrássy út 66, Budapest, Hungary', 19, 47),
('Rue du Rhône 42, Geneva, Switzerland', 'Rue du Rhône 42, Geneva, Switzerland', 6, 46),
('Kurfürstendamm 23, Berlin, Germany', 'Kurfürstendamm 23, Berlin, Germany', 13, 52),
('Champs-Élysées 45, Paris, France', 'Champs-Élysées 45, Paris, France', 2, 48),
('Via Veneto 12, Rome, Italy', 'Via Veneto 12, Rome, Italy', 12, 41),
('Gran Vía 35, Madrid, Spain', 'Gran Vía 35, Madrid, Spain', -3, 40),
('Oxford Street 78, London, UK', 'Oxford Street 78, London, UK', 0, 51),
('Ringstrasse 15, Vienna, Austria', 'Ringstrasse 15, Vienna, Austria', 16, 48),
('Dam Square 4, Amsterdam, Netherlands', 'Dam Square 4, Amsterdam, Netherlands', 4, 52),
('Nyhavn 19, Copenhagen, Denmark', 'Nyhavn 19, Copenhagen, Denmark', 12, 55),
('Andrássy út 66, Budapest, Hungary', 'Andrássy út 66, Budapest, Hungary', 19, 47),
('Rue du Rhône 42, Geneva, Switzerland', 'Rue du Rhône 42, Geneva, Switzerland', 6, 46),
('Krakowskie Przedmieście 5, Warsaw, Poland', 'Krakowskie Przedmieście 5, Warsaw, Poland', 21, 52),
('Avenida da Liberdade 10, Lisbon, Portugal', 'Avenida da Liberdade 10, Lisbon, Portugal', -9, 38),
('Königsallee 28, Düsseldorf, Germany', 'Königsallee 28, Düsseldorf, Germany', 6, 51),
('Passeig de Gràcia 43, Barcelona, Spain', 'Passeig de Gràcia 43, Barcelona, Spain', 2, 41),
('Avenue Louise 54, Brussels, Belgium', 'Avenue Louise 54, Brussels, Belgium', 4, 50),
('Bahnhofstrasse 25, Zurich, Switzerland', 'Bahnhofstrasse 25, Zurich, Switzerland', 8, 47),
('Vaci utca 18, Budapest, Hungary', 'Vaci utca 18, Budapest, Hungary', 19, 47),
('Corso Buenos Aires 36, Milan, Italy', 'Corso Buenos Aires 36, Milan, Italy', 9, 45),
('Vasagatan 15, Stockholm, Sweden', 'Vasagatan 15, Stockholm, Sweden', 18, 59),
('Ermou Street 44, Athens, Greece', 'Ermou Street 44, Athens, Greece', 23, 37);

-- Insert data into orders table
-- Making sure to use only user_ids that exist in the user table (1-20)
INSERT INTO `orders` (`user_id`, `car_id`, `start_date`, `end_date`, `rental_status`, `location_id`, `payment_status`, `discount_code`, `extended_rental`) VALUES
(1, 2, '2023-03-10 10:00:00', '2023-03-12 10:00:00', 'completed', 1, 'paid', 'SPRING10', 0),
(2, 4, '2023-03-15 09:00:00', '2023-03-16 09:00:00', 'completed', 2, 'paid', '', 0),
(4, 6, '2023-03-20 11:00:00', '2023-03-25 11:00:00', 'completed', 3, 'paid', 'WELCOME15', 0),
(5, 8, '2023-04-05 14:00:00', '2023-04-07 14:00:00', 'completed', 4, 'paid', '', 0),
(6, 10, '2023-04-10 12:00:00', '2023-04-15 12:00:00', 'completed', 5, 'paid', 'LOYALTY20', 0),
(7, 12, '2023-04-20 15:00:00', '2023-04-22 15:00:00', 'completed', 6, 'paid', '', 0),
(8, 14, '2023-05-01 09:30:00', '2023-05-05 09:30:00', 'completed', 7, 'paid', '', 0),
(9, 16, '2023-05-10 13:00:00', '2023-05-11 13:00:00', 'completed', 8, 'paid', 'WEEKEND10', 0),
(10, 18, '2023-05-15 10:00:00', '2023-05-20 10:00:00', 'completed', 9, 'paid', '', 0),
(11, 20, '2023-05-25 14:30:00', '2023-05-30 14:30:00', 'completed', 10, 'paid', '', 0),
(12, 1, '2023-06-01 08:00:00', '2023-06-03 08:00:00', 'completed', 11, 'paid', 'SUMMER15', 0),
(13, 3, '2023-06-05 11:30:00', '2023-06-10 11:30:00', 'completed', 12, 'paid', '', 0),
(14, 5, '2023-06-15 13:00:00', '2023-06-17 13:00:00', 'completed', 13, 'paid', '', 0),
(15, 7, '2023-06-20 09:00:00', '2023-06-25 09:00:00', 'completed', 14, 'paid', 'ROAD10', 0),
(16, 9, '2023-07-01 12:00:00', '2023-07-03 12:00:00', 'completed', 15, 'paid', '', 0),
(17, 11, '2023-07-05 15:30:00', '2023-07-10 15:30:00', 'completed', 16, 'paid', '', 0),
(18, 13, '2023-07-15 10:00:00', '2023-07-16 10:00:00', 'completed', 17, 'paid', 'DAY20', 0),
(19, 15, '2023-07-20 14:00:00', '2023-07-25 14:00:00', 'completed', 18, 'paid', '', 0),
(20, 17, '2023-08-01 11:00:00', '2023-08-03 11:00:00', 'completed', 19, 'paid', '', 0),
(1, 19, '2023-08-05 13:30:00', '2023-08-10 13:30:00', 'completed', 20, 'paid', 'AUGUST15', 0),
(2, 2, '2023-08-15 09:00:00', '2023-08-17 09:00:00', 'completed', 1, 'paid', '', 0),
(3, 4, '2023-08-20 12:00:00', '2023-08-25 12:00:00', 'completed', 2, 'paid', '', 0),
(4, 6, '2023-09-01 14:30:00', '2023-09-03 14:30:00', 'completed', 3, 'paid', 'FALL10', 0),
(5, 8, '2023-09-10 10:00:00', '2023-09-15 10:00:00', 'completed', 4, 'paid', '', 0),
(1, 3, '2023-10-05 09:00:00', '2023-10-06 09:00:00', 'confirmed', 5, 'paid', '', 0),
(2, 5, '2023-10-10 13:00:00', '2023-10-15 13:00:00', 'confirmed', 6, 'paid', 'OCT20', 0),
(6, 7, '2023-10-20 11:30:00', '2023-10-22 11:30:00', 'confirmed', 7, 'paid', '', 0),
(4, 9, '2023-11-01 10:00:00', '2023-11-05 10:00:00', 'pending', 8, 'pending', '', 0),
(5, 11, '2023-11-10 14:00:00', '2023-11-12 14:00:00', 'pending', 9, 'pending', 'NOV15', 0),
(6, 13, '2023-11-15 12:30:00', '2023-11-20 12:30:00', 'pending', 10, 'pending', '', 0);

-- Insert data into invoice table
INSERT INTO `invoice` (`orders_id`, `insurance_id`, `payment_amount`, `tax_amount`, `payment_method`, `payment_status`, `payment_date`, `invoice_address`) VALUES
(1, 2, 350.00, 28.00, 'credit_card', 'paid', '2023-03-10 10:15:00', 'ul. Nowy Świat 12, Warsaw, Poland'),
(2, 4, 300.00, 24.00, 'paypal', 'paid', '2023-03-15 09:15:00', 'Friedrichstraße 123, Berlin, Germany'),
(3, 6, 750.00, 60.00, 'credit_card', 'paid', '2023-03-20 11:15:00', 'Rue de Rivoli 45, Paris, France'),
(4, 8, 350.00, 28.00, 'bank_transfer', 'paid', '2023-04-05 14:15:00', 'Via del Corso 37, Rome, Italy'),
(5, 10, 1000.00, 80.00, 'credit_card', 'paid', '2023-04-10 12:15:00', 'Calle de Alcalá 25, Madrid, Spain'),
(6, 12, 550.00, 44.00, 'paypal', 'paid', '2023-04-20 15:15:00', 'Regent Street 55, London, UK'),
(7, 14, 600.00, 48.00, 'credit_card', 'paid', '2023-05-01 09:45:00', 'Kärntner Straße 28, Vienna, Austria'),
(8, 16, 100.00, 8.00, 'bank_transfer', 'paid', '2023-05-10 13:15:00', 'Kalverstraat 12, Amsterdam, Netherlands'),
(9, 18, 750.00, 60.00, 'credit_card', 'paid', '2023-05-15 10:15:00', 'Strøget 34, Copenhagen, Denmark'),
(10, 20, 750.00, 60.00, 'paypal', 'paid', '2023-05-25 14:45:00', 'Váci utca 45, Budapest, Hungary'),
(11, 1, 250.00, 20.00, 'credit_card', 'paid', '2023-06-01 08:15:00', 'Marszałkowska 78, Warsaw, Poland'),
(12, 3, 500.00, 40.00, 'bank_transfer', 'paid', '2023-06-05 11:45:00', 'Rua Augusta 67, Lisbon, Portugal'),
(13, 5, 450.00, 36.00, 'credit_card', 'paid', '2023-06-15 13:15:00', 'Schadowstraße 42, Düsseldorf, Germany'),
(14, 7, 1000.00, 80.00, 'paypal', 'paid', '2023-06-20 09:15:00', 'Las Ramblas 56, Barcelona, Spain'),
(15, 9, 500.00, 40.00, 'credit_card', 'paid', '2023-07-01 12:15:00', 'Rue Neuve 23, Brussels, Belgium'),
(16, 11, 1250.00, 100.00, 'bank_transfer', 'paid', '2023-07-05 15:45:00', 'Paradeplatz 8, Zurich, Switzerland'),
(17, 13, 100.00, 8.00, 'credit_card', 'paid', '2023-07-15 10:15:00', 'Raday utca 15, Budapest, Hungary'),
(18, 15, 1250.00, 100.00, 'paypal', 'paid', '2023-07-20 14:15:00', 'Via Montenapoleone 22, Milan, Italy'),
(19, 17, 400.00, 32.00, 'credit_card', 'paid', '2023-08-01 11:15:00', 'Drottninggatan 31, Stockholm, Sweden'),
(20, 19, 1375.00, 110.00, 'credit_card', 'paid', '2023-08-05 13:45:00', 'Syntagma Square 9, Athens, Greece'),
(21, 2, 350.00, 28.00, 'paypal', 'paid', '2023-08-15 09:15:00', 'Unter den Linden 17, Berlin, Germany'),
(22, 4, 1250.00, 100.00, 'bank_transfer', 'paid', '2023-08-20 12:15:00', 'Boulevard Saint-Germain 89, Paris, France'),
(23, 6, 300.00, 24.00, 'credit_card', 'paid', '2023-09-01 14:45:00', 'Piazza Navona 11, Rome, Italy'),
(24, 8, 750.00, 60.00, 'paypal', 'paid', '2023-09-10 10:15:00', 'Puerta del Sol 4, Madrid, Spain'),
(25, 1, 125.00, 10.00, 'credit_card', 'paid', '2023-10-05 09:15:00', 'Piccadilly 76, London, UK'),
(26, 5, 1125.00, 90.00, 'bank_transfer', 'paid', '2023-10-10 13:15:00', 'Graben 16, Vienna, Austria'),
(27, 7, 400.00, 32.00, 'credit_card', 'paid', '2023-10-20 11:45:00', 'Leidsestraat 27, Amsterdam, Netherlands'),
(28, 9, 1250.00, 100.00, 'pending', 'pending', '2023-11-01 10:15:00', 'Kongens Nytorv 8, Copenhagen, Denmark'),
(29, 11, 200.00, 16.00, 'pending', 'pending', '2023-11-10 14:15:00', 'Erzsébet körút 39, Budapest, Hungary'),
(30, 13, 750.00, 60.00, 'pending', 'pending', '2023-11-15 12:45:00', 'Rue du Mont-Blanc 18, Geneva, Switzerland');

-- Insert data into comment table
INSERT INTO `comment` (`user_id`, `car_id`, `comment_message`, `comment_star`, `comment_date`, `rating_category`, `comment_flagged`) VALUES
(1, 2, 'Great SUV for our family trip to the Alps. Plenty of space and very comfortable.', 5, '2023-03-13 15:30:00', 'comfort', 0),
(2, 4, 'Beautiful convertible, perfect for driving along the French Riviera.', 5, '2023-03-17 14:00:00', 'value_for_money', 0),
(4, 6, 'The Volvo handled all terrain wonderfully, great for our tour through Scandinavia.', 4, '2023-03-26 16:45:00', 'performance', 0),
(5, 8, 'Spacious minivan, perfect for transporting our large group around Madrid.', 5, '2023-04-08 10:30:00', 'comfort', 0),
(6, 10, 'The Tucson was comfortable but used more fuel than expected in city driving.', 3, '2023-04-16 11:15:00', 'fuel_efficiency', 0),
(7, 12, 'The Tesla was amazing! So fast and zero fuel costs for our trip across Germany.', 5, '2023-04-23 09:00:00', 'performance', 0),
(8, 14, 'The SEAT Leon was economical and fun to drive in the narrow streets of Barcelona.', 4, '2023-05-06 13:30:00', 'fuel_efficiency', 0),
(9, 16, 'The Fiat Tipo was basic but reliable and economical for our Italian road trip.', 3, '2023-05-12 15:45:00', 'value_for_money', 0),
(10, 18, 'The Renault Captur was comfortable for our journey through France but acceleration was a bit sluggish.', 3, '2023-05-21 14:00:00', 'performance', 0),
(11, 20, 'The Passat was extremely fuel efficient and comfortable for our business trip.', 5, '2023-05-31 10:30:00', 'fuel_efficiency', 0),
(12, 1, 'The Opel Insignia was a solid, reliable sedan with good comfort for long journeys.', 4, '2023-06-04 12:15:00', 'comfort', 0),
(13, 3, 'The Golf had excellent handling and was fun to drive through the Black Forest.', 4, '2023-06-11 14:30:00', 'performance', 0),
(14, 5, 'The BMW M4 was a blast! Great power and handling on the Autobahn.', 5, '2023-06-18 16:45:00', 'performance', 0),
(15, 7, 'The Ford Ranger had great towing capacity for our camping equipment.', 4, '2023-06-26 11:00:00', 'performance', 0),
(16, 9, 'The Mercedes E-Class was luxurious but expensive to rent for our business trip.', 4, '2023-07-04 09:15:00', 'value_for_money', 0),
(17, 11, 'The Toyota Corolla was economical but a bit cramped for taller passengers.', 3, '2023-07-11 13:30:00', 'comfort', 0),
(18, 13, 'The Nissan Qashqai had excellent safety features and was comfortable to drive through Portugal.', 5, '2023-07-17 15:45:00', 'safety', 0),
(19, 15, 'The Audi Q7 was a premium experience but came with a premium price.', 4, '2023-07-26 14:00:00', 'value_for_money', 0),
(20, 17, 'The Toyota Hilux was rugged and reliable, perfect for our countryside exploration.', 4, '2023-08-04 10:30:00', 'performance', 0),
(1, 19, 'The BMW 4 Series had excellent handling on Swiss mountain roads.', 5, '2023-08-11 12:15:00', 'performance', 0),
(2, 2, 'Second time renting the Kodiaq, still a great family vehicle for exploring Eastern Europe.', 5, '2023-08-18 14:30:00', 'comfort', 0),
(3, 4, 'The Audi A5 convertible was a joy to drive along the Mediterranean coast.', 5, '2023-08-26 16:45:00', 'performance', 0),
(4, 6, 'The Volvo V60 all-wheel-drive system was perfect for the mountain roads in the Alps.', 4, '2023-09-04 11:00:00', 'safety', 0),
(5, 8, 'The Renault Espace was spacious but could use better fuel efficiency in urban Paris.', 3, '2023-09-16 09:15:00', 'fuel_efficiency', 0);

-- Insert data into user_reviews table (users reviewing other users)
INSERT INTO `user_reviews` (`reviewer_user_id`, `reviewee_user_id`, `review_message`, `review_rating`, `review_date`) VALUES
(1, 11, 'Great communication and car was returned in excellent condition.', 5, '2023-06-04 14:30:00'),
(11, 1, 'Very friendly and professional renter, would rent to again.', 5, '2023-06-04 15:00:00'),
(2, 12, 'Returned the car clean and with a full tank.', 5, '2023-07-04 11:45:00'),
(12, 2, 'Easy pickup and drop-off process in Berlin, very satisfied.', 5, '2023-07-04 12:15:00'),
(3, 13, 'Good communication throughout the rental period in Rome.', 4, '2023-08-26 18:00:00'),
(13, 3, 'Car was as described, no issues with the rental in Paris.', 4, '2023-08-26 18:30:00'),
(4, 14, 'Car was returned with less fuel than agreed upon in Barcelona.', 3, '2023-09-04 13:30:00'),
(14, 4, 'Some confusion about pickup location in Vienna, but otherwise ok.', 3, '2023-09-04 14:00:00'),
(5, 15, 'Excellent renter, car returned in perfect condition in Lisbon.', 5, '2023-09-16 11:30:00'),
(15, 5, 'Very smooth rental process in Madrid, would rent again.', 5, '2023-09-16 12:00:00'),
(6, 16, 'Good communication but returned car late to our London office.', 3, '2023-07-04 11:00:00'),
(16, 6, "Car had some issues that weren't mentioned in the Rome listing.", 2, '2023-07-04 11:30:00'),
(7, 17, "Perfect rental experience in Stockholm, highly recommended.", 5, '2023-07-11 15:00:00'),
(17, 7, 'Car was clean and in great condition for our Copenhagen trip.', 5, '2023-07-11 15:30:00'),
(8, 18, 'Respectful and responsible renter in Amsterdam.', 4, '2023-07-17 17:15:00'),
(18, 8, 'Good value for the price in Budapest, would rent again.', 4, '2023-07-17 17:45:00'),
(9, 19, 'Returned car late without communication to our Milan office.', 2, '2023-07-26 16:30:00'),
(19, 9, 'Car in Zurich had fewer features than advertised.', 3, '2023-07-26 17:00:00'),
(10, 20, 'Great renter in Brussels, followed all guidelines.', 5, '2023-08-04 13:00:00'),
(20, 10, 'Seamless rental process and great car condition in Athens.', 5, '2023-08-04 13:30:00');

-- Insert data into notifications table
-- Ensuring all user_ids exist in the user table
INSERT INTO `notifications` (`user_id`, `message`, `status`, `created_at`) VALUES
(1, 'Your rental of Škoda Kodiaq in Berlin has been confirmed.', 'read', '2023-03-09 14:30:00'),
(2, 'Your rental of Audi A5 in Paris has been confirmed.', 'read', '2023-03-14 16:45:00'),
(4, 'Your rental of Volvo V60 in Rome has been confirmed.', 'read', '2023-03-19 12:00:00'),
(5, 'Your rental of Renault Espace in Madrid has been confirmed.', 'read', '2023-04-04 15:30:00'),
(6, 'Your rental of Hyundai Tucson in London has been confirmed.', 'read', '2023-04-09 11:15:00'),
(7, 'Your rental of Tesla Model 3 in Vienna has been confirmed.', 'read', '2023-04-19 14:00:00'),
(8, 'Your rental of SEAT Leon in Amsterdam has been confirmed.', 'read', '2023-04-30 10:30:00'),
(9, 'Your rental of Fiat Tipo in Copenhagen has been confirmed.', 'read', '2023-05-09 13:45:00'),
(10, 'Your rental of Renault Captur in Budapest has been confirmed.', 'read', '2023-05-14 15:00:00'),
(11, 'Your rental of Volkswagen Passat in Geneva has been confirmed.', 'read', '2023-05-24 16:15:00'),
(12, 'Your rental of Opel Insignia in Warsaw has been confirmed.', 'read', '2023-05-31 09:30:00'),
(13, 'Your rental of Volkswagen Golf in Lisbon has been confirmed.', 'read', '2023-06-04 11:45:00'),
(14, 'Your rental of BMW M4 in Düsseldorf has been confirmed.', 'read', '2023-06-14 14:00:00'),
(15, 'Your rental of Ford Ranger in Barcelona has been confirmed.', 'read', '2023-06-19 10:15:00'),
(16, 'Your rental of Mercedes-Benz E-Class in Brussels has been confirmed.', 'read', '2023-06-30 13:30:00'),
(17, 'Your rental of Toyota Corolla in Zurich has been confirmed.', 'read', '2023-07-04 15:45:00'),
(18, 'Your rental of Nissan Qashqai in Budapest has been confirmed.', 'read', '2023-07-14 17:00:00'),
(19, 'Your rental of Audi Q7 in Milan has been confirmed.', 'read', '2023-07-19 10:30:00'),
(20, 'Your rental of Toyota Hilux in Stockholm has been confirmed.', 'read', '2023-07-31 12:45:00'),
(1, 'Your rental of BMW 4 Series in Athens has been confirmed.', 'read', '2023-08-04 15:00:00'),
(2, 'Your rental of Škoda Kodiaq in Berlin has been confirmed.', 'read', '2023-08-14 17:15:00'),
(3, 'Your rental of Audi A5 in Paris has been confirmed.', 'read', '2023-08-19 10:45:00'),
(4, 'Your rental of Volvo V60 in Rome has been confirmed.', 'read', '2023-08-31 13:00:00'),
(5, 'Your rental of Renault Espace in Madrid has been confirmed.', 'read', '2023-09-09 15:15:00'),
(1, 'Your upcoming rental of Volkswagen Golf in London is tomorrow.', 'unread', '2023-10-04 09:00:00'),
(2, 'Your upcoming rental of BMW M4 in Vienna is tomorrow.', 'unread', '2023-10-09 09:00:00'),
(6, 'Your upcoming rental of Ford Ranger in Amsterdam is tomorrow.', 'unread', '2023-10-19 09:00:00'),
(4, 'Please complete your profile for better car recommendations across Europe.', 'unread', '2023-10-25 14:30:00'),
(5, 'Special autumn weekend discount available for your next rental in any European city.', 'unread', '2023-10-28 10:15:00');