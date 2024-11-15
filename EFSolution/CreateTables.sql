-- Check if the database exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Assignment1')
BEGIN
    -- Create the database
    CREATE DATABASE Assignment1;
END;

-- Switch to the newly created database
USE Assignment1;

CREATE TABLE Cook (
    cook_id VARCHAR(100) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    address VARCHAR(200) NOT NULL,
	CPR VARCHAR(10) NOT NULL
);

CREATE TABLE Payment_Options (
    option_id INT PRIMARY KEY,
    payment_type VARCHAR(50) NOT NULL
);

CREATE TABLE Bikes (
    bike_id INT PRIMARY KEY,
    bike_type VARCHAR(50) NOT NULL
);

CREATE TABLE Customer (
    customer_id INT PRIMARY KEY,
    name VARCHAR(100),
    address VARCHAR(200) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    payment_option INT NOT NULL,
    FOREIGN KEY (payment_option) REFERENCES Payment_Options(option_id)
);

CREATE TABLE Cyclist (
    cyclist_id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    Hourly_Rate DECIMAL(10, 2),
    bike_id INT NOT NULL,
    FOREIGN KEY (bike_id) REFERENCES Bikes(bike_id)
);

CREATE TABLE Available_Dishes (
    dish_id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    currency VARCHAR(3) NOT NULL,
    quantity INT NOT NULL,
    available_from DATETIME NOT NULL,
    available_to DATETIME NOT NULL,
    cook_id VARCHAR(100) NOT NULL,
    FOREIGN KEY (cook_id) REFERENCES Cook(cook_id)
);

CREATE TABLE Trip (
    trip_id INT PRIMARY KEY,
    cyclist_id INT NOT NULL,
    completion_time TIME,
    FOREIGN KEY (cyclist_id) REFERENCES Cyclist(cyclist_id)
);

CREATE TABLE Delivery (
    id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    trip_id INT,
    DeliveryTime DATETIME,
    FOREIGN KEY (customer_id) REFERENCES Customer(customer_id),
    FOREIGN KEY (trip_id) REFERENCES Trip(trip_id)
);

CREATE TABLE DishOrder (
    order_id INT PRIMARY KEY,
    delivery INT NOT NULL,
    dish_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    quantity INT NOT NULL,
    FOREIGN KEY (delivery) REFERENCES Delivery(id),
    FOREIGN KEY (dish_id) REFERENCES Available_Dishes(dish_id)
);
CREATE TABLE Review (
    review_id INT PRIMARY KEY,
    delivery_rating INT,
    food_rating INT,
    comments TEXT,
    order_id INT NOT NULL,
    FOREIGN KEY (order_id) REFERENCES DishOrder(order_id)
);
