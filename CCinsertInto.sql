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

-- Insert data for 14 popular cars
INSERT INTO `car` (`car_price`, `car_active`, `car_description`, `car_type`, `seats`, `number_of_doors`, `insurance_id`, `car_model`, `car_regnumber`, `price_per_hour`, `price_per_day`, `car_condition`, `mileage`, `car_year`, `fuel_type`, `transmission_type`, `car_brand`) VALUES
('32000', 1, 'Reliable family sedan with excellent safety features', 'sedan', 5, 4, 1, 'Accord', 'W-AB-1234', 25, 125, 'excellent', 35000, 2022, 'hybrid', 'automatic', 'Honda'),
('35000', 1, 'Spacious SUV perfect for family trips and outdoor adventures', 'suv', 7, 5, 2, 'RAV4', 'M-CD-5678', 35, 175, 'excellent', 28000, 2021, 'hybrid', 'automatic', 'Toyota'),
('28500', 1, 'Compact hatchback with great city handling and fuel economy', 'hatchback', 5, 5, 3, 'Golf', 'B-EF-9012', 20, 100, 'good', 42000, 2020, 'petrol', 'manual', 'Volkswagen'),
('68000', 1, 'Luxury electric sedan with cutting-edge technology', 'sedan', 5, 4, 4, 'Model 3', 'K-GH-3456', 60, 300, 'excellent', 15000, 2022, 'electric', 'automatic', 'Tesla'),
('50000', 1, 'Sporty coupe with powerful engine and dynamic handling', 'coupe', 4, 2, 5, 'Mustang', 'F-IJ-7890', 45, 225, 'excellent', 20000, 2021, 'petrol', 'manual', 'Ford'),
('45000', 1, 'Premium crossover SUV with elegant design and comfort', 'suv', 5, 5, 6, 'CX-5', 'S-KL-1234', 40, 200, 'excellent', 25000, 2022, 'petrol', 'automatic', 'Mazda'),
('38000', 1, 'Robust pickup truck for heavy duty tasks and adventures', 'pickup', 5, 4, 7, 'F-150', 'L-MN-5678', 40, 200, 'good', 45000, 2020, 'petrol', 'automatic', 'Ford'),
('42000', 1, 'Versatile mid-size SUV with off-road capabilities', 'suv', 5, 5, 8, 'Wrangler', 'F-OP-9012', 45, 225, 'excellent', 32000, 2021, 'petrol', 'manual', 'Jeep'),
('55000', 1, 'Luxury sedan with premium features and smooth ride', 'sedan', 5, 4, 9, 'E-Class', 'S-QR-3456', 50, 250, 'excellent', 25000, 2022, 'diesel', 'automatic', 'Mercedes-Benz'),
('33000', 1, 'Reliable compact SUV with excellent fuel efficiency', 'suv', 5, 5, 10, 'CR-V', 'B-ST-7890', 30, 150, 'good', 35000, 2021, 'hybrid', 'automatic', 'Honda'),
('26000', 1, 'Economical compact sedan with modern safety features', 'sedan', 5, 4, 11, 'Civic', 'W-UV-1234', 20, 100, 'good', 40000, 2020, 'petrol', 'automatic', 'Honda'),
('75000', 1, 'Premium electric SUV with long range and performance', 'suv', 5, 5, 12, 'Model Y', 'M-WX-5678', 65, 325, 'excellent', 18000, 2022, 'electric', 'automatic', 'Tesla'),
('34000', 1, 'Stylish compact SUV with distinctive design', 'suv', 5, 5, 13, 'Sportage', 'B-YZ-9012', 30, 150, 'good', 30000, 2021, 'petrol', 'automatic', 'Kia'),
('65000', 1, 'Premium luxury SUV with cutting-edge technology and comfort', 'suv', 7, 5, 14, 'X5', 'K-CD-7890', 60, 300, 'excellent', 22000, 2022, 'hybrid', 'automatic', 'BMW');

-- Insert data into car_images table (at least 2 images per car)
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
(14, '2023-03-01 00:00:00', '2027-12-31 23:59:59');

-- Insert data into car_extras table
INSERT INTO `car_extras` (`car_id`, `extra_name`, `extra_price`) VALUES
(1, 'baby seat', 10.00),
(1, 'GPS navigation', 5.00),
(2, 'baby seat', 10.00),
(2, 'roof rack', 15.00),
(3, 'baby seat', 10.00),
(3, 'GPS navigation', 5.00),
(4, 'baby seat', 15.00),
(4, 'premium charging cable', 10.00),
(5, 'baby seat', 10.00),
(5, 'performance package', 25.00),
(6, 'baby seat', 10.00),
(6, 'roof rack', 15.00),
(7, 'baby seat', 15.00),
(7, 'towing package', 30.00),
(8, 'baby seat', 10.00),
(8, 'off-road package', 35.00),
(9, 'baby seat', 15.00),
(9, 'premium sound system', 20.00),
(10, 'baby seat', 15.00),
(10, 'roof rack', 15.00),
(11, 'baby seat', 10.00),
(11, 'GPS navigation', 5.00),
(12, 'baby seat', 15.00),
(12, 'premium charging cable', 10.00),
(13, 'baby seat', 10.00),
(13, 'roof rack', 15.00),
(14, 'baby seat', 15.00),
(14, 'premium sound system', 20.00);

-- Insert data into car_user table (who owns/manages which cars)
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
INSERT INTO `orders` (`user_id`, `car_id`, `start_date`, `end_date`, `rental_status`, `location_id`, `payment_status`, `discount_code`, `extended_rental`) VALUES
(1, 2, '2023-03-10 10:00:00', '2023-03-12 10:00:00', 'completed', 1, 'paid', 'SPRING10', 0),
(2, 4, '2023-03-15 09:00:00', '2023-03-16 09:00:00', 'completed', 2, 'paid', '', 0),
(4, 6, '2023-03-20 11:00:00', '2023-03-25 11:00:00', 'completed', 3, 'paid', 'WELCOME15', 0),
(5, 8, '2023-04-05 14:00:00', '2023-04-07 14:00:00', 'completed', 4, 'paid', '', 0),
(6, 10, '2023-04-10 12:00:00', '2023-04-15 12:00:00', 'completed', 5, 'paid', 'LOYALTY20', 0),
(7, 12, '2023-04-20 15:00:00', '2023-04-22 15:00:00', 'completed', 6, 'paid', '', 0),
(8, 14, '2023-05-01 09:30:00', '2023-05-05 09:30:00', 'completed', 7, 'paid', '', 0),
(12, 1, '2023-06-01 08:00:00', '2023-06-03 08:00:00', 'completed', 11, 'paid', 'SUMMER15', 0),
(13, 3, '2023-06-05 11:30:00', '2023-06-10 11:30:00', 'completed', 12, 'paid', '', 0),
(14, 5, '2023-06-15 13:00:00', '2023-06-17 13:00:00', 'completed', 13, 'paid', '', 0),
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
(20, 19, 1375.00, 110.00, 'credit_card', 'paid', '2023-08-05 13:45:00', 'Syntagma Square 9, Athens, Greece');

-- Insert data into comment table
INSERT INTO `comment` (`user_id`, `car_id`, `comment_message`, `comment_star`, `comment_date`, `rating_category`, `comment_flagged`) VALUES 
-- Honda Accord (car_id: 1)
(1, 1, 'Smooth ride and excellent fuel economy. The hybrid system works flawlessly.', 5, '2023-03-10 14:20:00', 'performance', 0),
(2, 1, 'Great family sedan with plenty of legroom. My kids loved the spacious back seats.', 4, '2023-04-05 09:45:00', 'comfort', 0),
(3, 1, 'The infotainment system is a bit confusing to use at first but works well once you get used to it.', 3, '2023-05-12 16:30:00', 'features', 0),

-- Toyota RAV4 (car_id: 2)
(1, 2, 'Great SUV for our family trip to the Alps. Plenty of space and very comfortable.', 5, '2023-03-13 15:30:00', 'comfort', 0),
(5, 2, 'The hybrid system provides excellent fuel economy even when driving in the city.', 5, '2023-04-18 10:20:00', 'efficiency', 0),
(6, 2, 'Good handling for an SUV, but the lane-keeping assist is too aggressive.', 4, '2023-05-25 14:10:00', 'performance', 0),
(7, 2, 'Plenty of cargo space. We fit all our camping gear with room to spare.', 5, '2023-07-03 09:00:00', 'utility', 0),

-- Volkswagen Golf (car_id: 3)
(8, 3, 'Fun to drive with responsive handling. Perfect for city driving.', 4, '2023-03-15 16:45:00', 'performance', 0),
(9, 3, 'Manual transmission is smooth but city traffic made it tiring after a while.', 3, '2023-04-22 11:30:00', 'comfort', 0),
(10, 3, 'Great fuel economy and compact size makes parking a breeze.', 5, '2023-06-05 13:25:00', 'efficiency', 0),
(11, 3, 'The interior feels premium for its class. Well-built with quality materials.', 4, '2023-07-18 15:40:00', 'quality', 0),

-- Tesla Model 3 (car_id: 4)
(12, 4, 'Amazing acceleration and handling. Feels like driving a sports car.', 5, '2023-03-18 10:15:00', 'performance', 0),
(13, 4, 'The minimalist interior takes some getting used to but works well.', 4, '2023-04-26 14:30:00', 'design', 0),
(14, 4, 'Autopilot feature made my highway commute much less stressful.', 5, '2023-06-10 09:20:00', 'technology', 0),
(10, 4, 'Range anxiety wasn\'t an issue. Plenty of charging stations on our route.', 4, '2023-07-22 11:45:00', 'range', 0),

-- Ford Mustang (car_id: 5)
(1, 5, 'Incredible power and engine sound. A true American muscle car experience.', 5, '2023-03-20 13:40:00', 'performance', 0),
(13, 5, 'Fuel economy is poor but that\'s expected with this much power.', 2, '2023-07-28 14:10:00', 'efficiency', 0),

-- Mazda CX-5 (car_id: 6)
(3, 6, 'Premium feel without the premium price. Interior quality is exceptional.', 5, '2023-03-22 11:25:00', 'quality', 0),
(2, 6, 'Handles like a sedan despite being an SUV. Very impressed with the driving dynamics.', 5, '2023-05-08 13:45:00', 'performance', 0),

-- Ford F-150 (car_id: 7)
(11, 7, 'Fuel economy is what you\'d expect from a full-size truck - not great.', 2, '2023-06-25 13:40:00', 'efficiency', 0),
(12, 7, 'The bed size and features are perfect for my construction business.', 5, '2023-08-07 11:05:00', 'utility', 0),

-- Jeep Wrangler (car_id: 8)
(9, 8, 'Took it off-road and it performed flawlessly. A true off-road beast.', 5, '2023-03-28 10:10:00', 'performance', 0),
(13, 8, 'Highway driving is noisy and ride is rough, but that\'s part of the Jeep experience.', 3, '2023-05-15 15:30:00', 'comfort', 0),
(1, 8, 'Removing the doors and roof was fun for summer driving.', 5, '2023-06-30 14:25:00', 'features', 0),

-- Mercedes-Benz E-Class (car_id: 9)
(10, 9, 'Luxurious interior with exceptional build quality. Every detail is perfect.', 5, '2023-03-30 13:20:00', 'quality', 0),
(14, 9, 'Smooth and quiet ride even on rough roads. Perfect for long trips.', 5, '2023-05-18 11:40:00', 'comfort', 0),
(8, 9, 'Excellent diesel engine with surprising efficiency for its size.', 4, '2023-08-15 10:30:00', 'efficiency', 0),

-- Honda CR-V (car_id: 10)
(3, 10, 'Perfect family SUV with excellent safety features.', 5, '2023-04-02 15:45:00', 'safety', 0),
(10, 10, 'The hybrid system is smooth and provides great fuel economy.', 5, '2023-05-22 12:20:00', 'efficiency', 0),
(2, 10, 'Cargo space is excellent. Easily fits all our luggage for family trips.', 4, '2023-07-10 09:35:00', 'utility', 0),
(7, 10, 'Handling is good but not as sporty as some competitors.', 3, '2023-08-20 14:50:00', 'performance', 0),

-- Honda Civic (car_id: 11)
(10, 11, 'Excellent daily driver with good fuel economy.', 4, '2023-04-05 10:30:00', 'efficiency', 0),
(11, 11, 'The interior feels more upscale than previous generations.', 4, '2023-05-25 16:15:00', 'quality', 0),
(12, 11, 'Safety features like adaptive cruise control work great.', 5, '2023-07-12 11:25:00', 'safety', 0),
(13, 11, 'A bit noisy on the highway, but comfortable for daily commuting.', 3, '2023-08-23 13:40:00', 'comfort', 0),

-- Tesla Model Y (car_id: 12)
(14, 12, 'Incredible performance for an SUV. Acceleration is mind-blowing.', 5, '2023-04-08 14:10:00', 'performance', 0),
(4, 12, 'The minimalist interior is both beautiful and functional.', 5, '2023-05-30 10:45:00', 'design', 0),
(6, 12, 'Autopilot made our long road trip much less tiring.', 5, '2023-07-15 15:30:00', 'technology', 0),
(7, 12, 'Some build quality issues with panel gaps, but nothing major.', 3, '2023-08-27 11:15:00', 'quality', 0),

-- Kia Sportage (car_id: 13)
(8, 13, 'Great value for money. Lots of features for the price.', 4, '2023-04-12 09:25:00', 'value', 0),
(9, 13, 'The new design is eye-catching and stands out from other SUVs.', 5, '2023-06-02 13:50:00', 'design', 0),
(5, 13, 'Comfortable ride but handling could be more responsive.', 3, '2023-07-18 10:35:00', 'performance', 0),

-- BMW X5 (car_id: 14)
(2, 14, 'Drives like a sports car despite its size. Incredible handling.', 5, '2023-04-15 11:40:00', 'performance', 0),
(13, 14, 'Luxurious interior with exceptional comfort for all passengers.', 5, '2023-06-05 14:30:00', 'comfort', 0),
(4, 14, 'The hybrid system provides good efficiency for a large SUV.', 4, '2023-07-22 09:15:00', 'efficiency', 0),
(14, 14, 'Technology features are comprehensive but the interface has a learning curve.', 4, '2023-09-02 12:45:00', 'technology', 0);

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
(5, 6, 'Excellent renter, car returned in perfect condition in Lisbon.', 5, '2023-09-16 11:30:00'),
(6, 5, 'Very smooth rental process in Madrid, would rent again.', 5, '2023-09-16 12:00:00'),
(7, 8, 'Good communication but returned car late to our London office.', 3, '2023-07-04 11:00:00'),
(8, 7, "Car had some issues that weren't mentioned in the Rome listing.", 2, '2023-07-04 11:30:00'),
(9, 7, "Perfect rental experience in Stockholm, highly recommended.", 5, '2023-07-11 15:00:00'),
(1, 9, 'Car was clean and in great condition for our Copenhagen trip.', 5, '2023-07-11 15:30:00');

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