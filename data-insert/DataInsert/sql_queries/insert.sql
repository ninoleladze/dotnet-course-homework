INSERT INTO city (name) VALUES
('Tbilisi'),
('Kutaisi'),
('Batumi');

INSERT INTO street (name, city_id) VALUES
('Rustaveli Avenue', 1),
('Agmashenebeli Avenue', 1),
('Chavchavadze Avenue', 2),
('Ninoshvili Street', 2),
('Khimshiashvili Street', 3);

INSERT INTO supermarket (name, street_id, house_number) VALUES
('Carrefour', 1, '12'),
('Goodwill', 1, '5A'),
('Nikora', 2, '34'),
('Spar', 2, '7'),
('Fresco', 3, '21'),
('Magniti', 4, '9B'),
('Europroduct', 5, '16');

INSERT INTO person (name, surname, birth_date) VALUES
('Nino', 'Beridze', '1990-05-12'),
('Giorgi', 'Kapanadze', '1985-11-23'),
('Ana', 'Chikviladze', '1992-02-15'),
('Levan', 'Tsereteli', '1988-07-30'),
('Mariam', 'Gogoladze', '1995-09-04'),
('David', 'Lomidze', '1979-12-19'),
('Tamar', 'Abashidze', '2000-01-10'),
('Irakli', 'Meskhi', '1993-06-25'),
('Ketevan', 'Japaridze', '1998-03-17'),
('Sandro', 'Kvaratskhelia', '1991-08-08');

INSERT INTO contact_type (name) VALUES
('Phone'),
('Email');

INSERT INTO person_contact (person_id, contact_type_id, contact_value) VALUES
(1, 1, '+995 555 10 10 01'),
(1, 2, 'nino.beridze@example.com'),
(2, 1, '+995 555 10 10 02'),
(2, 2, 'giorgi.kapanadze@example.com'),
(3, 1, '+995 555 10 10 03'),
(3, 2, 'ana.chikviladze@example.com'),
(4, 1, '+995 555 10 10 04'),
(4, 2, 'levan.tsereteli@example.com'),
(5, 1, '+995 555 10 10 05'),
(5, 2, 'mariam.gogoladze@example.com'),
(6, 1, '+995 555 10 10 06'),
(6, 2, 'david.lomidze@example.com'),
(7, 1, '+995 555 10 10 07'),
(7, 2, 'tamar.abashidze@example.com'),
(8, 1, '+995 555 10 10 08'),
(8, 2, 'irakli.meskhi@example.com'),
(9, 1, '+995 555 10 10 09'),
(9, 2, 'ketevan.japaridze@example.com'),
(10, 1, '+995 555 10 10 10'),
(10, 2, 'sandro.kvaratskhelia@example.com');

INSERT INTO customer (person_id, card_number, discount) VALUES
(1, 1000000001, 0.05),
(2, 1000000002, 0.10),
(3, 1000000003, 0.00),
(4, 1000000004, 0.15),
(5, 1000000005, 0.05),
(6, 1000000006, 0.20),
(7, 1000000007, 0.00),
(8, 1000000008, 0.10),
(9, 1000000009, 0.05),
(10, 1000000010, 0.00);

INSERT INTO product_category (name) VALUES
('Dairy'),
('Beverages'),
('Bakery');

INSERT INTO product_title (title, product_category_id) VALUES
('Milk', 1),
('Cheese', 1),
('Yogurt', 1),
('Butter', 1),
('Water', 2),
('Juice', 2),
('Soda', 2),
('Bread', 3),
('Croissant', 3),
('Bagel', 3);

INSERT INTO manufacturer (name) VALUES
('Sante'),
('Coca-Cola'),
('Nestle'),
('LocalBakery');

INSERT INTO product (product_title_id, manufacturer_id, price, comment) VALUES
(1, 1, 3.20, 'Fresh 1L'),
(1, 3, 3.50, NULL),
(2, 1, 12.90, 'Sulguni'),
(2, 3, 14.50, NULL),
(3, 1, 2.10, 'Natural'),
(3, 3, 2.40, 'Strawberry'),
(4, 1, 5.60, NULL),
(4, 3, 6.10, '82% fat'),
(5, 2, 1.20, '0.5L'),
(5, 3, 1.50, 'Sparkling'),
(6, 2, 4.80, 'Orange'),
(6, 3, 5.20, 'Apple'),
(7, 2, 2.30, NULL),
(7, 3, 2.60, NULL),
(8, 4, 1.80, 'White'),
(8, 3, 2.00, NULL),
(9, 4, 2.50, 'Butter croissant'),
(9, 1, 2.70, NULL),
(10, 4, 1.90, NULL),
(10, 1, 2.00, 'Sesame');

INSERT INTO customer_order (operation_time, supermarket_id, customer_id) VALUES
('2026-01-05 10:15:00', 1, 1),
('2026-01-06 11:00:00', 2, 2),
('2026-01-07 09:30:00', 3, NULL),
('2026-01-08 14:45:00', 4, 3),
('2026-01-09 16:20:00', 5, NULL),
('2026-01-10 12:10:00', 6, 4),
('2026-01-11 18:05:00', 7, 5),
('2026-01-12 08:40:00', 1, NULL),
('2026-01-13 19:55:00', 2, 6),
('2026-01-14 20:30:00', 3, 7),
('2026-01-15 09:00:00', 4, NULL),
('2026-01-16 10:25:00', 5, 8),
('2026-01-17 11:50:00', 6, 9),
('2026-01-18 13:15:00', 7, 10),
('2026-01-19 15:40:00', 1, NULL),
('2026-01-20 17:05:00', 2, 1),
('2026-01-21 18:30:00', 3, 2),
('2026-01-22 09:20:00', 4, NULL),
('2026-01-23 10:45:00', 5, 3),
('2026-01-24 12:00:00', 6, 4);

INSERT INTO order_details (customer_order_id, product_id, price, price_with_discount, product_amount) VALUES
(1, 1, 3.20, 3.04, 2),
(2, 2, 3.50, 3.15, 1),
(3, 3, 12.90, 12.90, 1),
(4, 4, 14.50, 14.50, 1),
(5, 5, 2.10, 2.10, 3),
(6, 6, 2.40, 2.04, 4),
(7, 7, 5.60, 5.32, 1),
(8, 8, 6.10, 6.10, 2),
(9, 9, 1.20, 0.96, 6),
(10, 10, 1.50, 1.50, 2),
(11, 11, 4.80, 4.80, 1),
(12, 12, 5.20, 4.68, 1),
(13, 13, 2.30, 2.19, 3),
(14, 14, 2.60, 2.60, 2),
(15, 15, 1.80, 1.80, 5),
(16, 16, 2.00, 1.90, 2),
(17, 17, 2.50, 2.25, 1),
(18, 18, 2.70, 2.70, 1),
(19, 19, 1.90, 1.90, 4),
(20, 20, 2.00, 1.70, 2);
