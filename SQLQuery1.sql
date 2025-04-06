CREATE DATABASE CoffeShop

CREATE TABLE Coffee (
    id INTEGER PRIMARY KEY,
    coffee_name TEXT NOT NULL,
    origin_country TEXT NOT NULL,
    coffee_type TEXT,
    description TEXT,
    quantity_grams INTEGER,
    cost_price DECIMAL(10, 2)
);

INSERT INTO Coffee (id,coffee_name, origin_country, coffee_type, description, quantity_grams, cost_price)
VALUES 
(1,'coffee_name01', '������', '�������', 'DESC01', 1000, 20.00),
(2,'coffee_name02', '���������', '�������', 'DESC02', 1500, 15.00),
(3,'coffee_name03', '�����', '�����', 'DESC03', 1200, 30.00)

