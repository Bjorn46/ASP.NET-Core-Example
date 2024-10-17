-- Cook Table
CREATE TABLE Cook(
    CookId INT IDENTITY(1,1),
    Rating INT,
    CprNumber NVARCHAR(20),
    PhoneNumber NVARCHAR(20),
    Adress NVARCHAR(100),
    Name NVARCHAR(50),
    PRIMARY KEY (CookId)
);


-- Customer Table
CREATE TABLE Customer(
    CustomerId INT IDENTITY(1,1),
    Name NVARCHAR(50),
    Adress NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    PaymentOption NVARCHAR(50),
    PRIMARY KEY (CustomerId)
);

-- Dish Table
CREATE TABLE Dish(
    DishId INT IDENTITY(1,1),
    CookId INT,
    Price DECIMAL(10, 2),
    EndTime TIME,
    StartTime TIME,
    DishName NVARCHAR(50),
    Quantity INT,
    PRIMARY KEY (DishId),
    CONSTRAINT FK_DishCookId FOREIGN KEY (CookId) REFERENCES Cook(CookId)
);

-- Order Table (identifier instead of keyword)
CREATE TABLE [Order](
    OrderId INT IDENTITY(1,1),
    CustomerId INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    PRIMARY KEY (OrderId),
    CONSTRAINT FK_OrderCustomerId FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);


-- Cyclist Table
CREATE TABLE Cyclist(
    CyclistId INT IDENTITY(1,1),
    OrderId INT,
    CprNumber NVARCHAR(20),
    PhoneNumber NVARCHAR(20),
    BikeType NVARCHAR(20),
    PRIMARY KEY (CyclistId),
    CONSTRAINT FK_OrderId FOREIGN KEY (OrderId) REFERENCES [Order](OrderId)
);
-- OrderDetail Table
CREATE TABLE OrderDetail(
    OrderDetailId INT IDENTITY(1,1),
    Price DECIMAL(10, 2),
    Quantity INT,
    DishId INT,
    OrderId INT,
    PRIMARY KEY (OrderDetailId),
    CONSTRAINT FK_OrderDetailDishId FOREIGN KEY (DishId) REFERENCES Dish(DishId),
    CONSTRAINT FK_OrderDetailOrderId FOREIGN KEY (OrderId) REFERENCES [Order](OrderId)
);

-- Trip Table
CREATE TABLE Trip(
    TripId INT IDENTITY(1,1),
    CyclistId INT,
    PickupAdress NVARCHAR(100),
    DeliveryAdress NVARCHAR(100),
    DeliveryTime TIME,
    PickupTime TIME,
    TripDate DATE,
    PRIMARY KEY (TripId),
    CONSTRAINT FK_TripCyclistId FOREIGN KEY (CyclistId) REFERENCES Cyclist(CyclistId)
);
