-- Insert into Cook table
INSERT INTO Cook (Rating, CprNumber, PhoneNumber, Adress, Name)
VALUES 
    (4, '123456-7790', '12345678', 'HansensGade 1', 'Noah Hansen'),
    (4.5, '123456-7891', '65486543', 'Mågevej 23', 'Helle Marie');

-- Insert into Dish table
INSERT INTO Dish (CookId, Price, EndTime, StartTime, DishName, Quantity)
VALUES 
    (1, 150.00, '20:00:00', '18:00:00', 'GrillMix', 5),
    (2, 10.00, '13:00:00', '09:00:00', 'Romkugle', 10),
    (2, 90.00, '20:00:00', '18:00:00', 'Pizza', 3);

-- Insert into Customer table
INSERT INTO Customer (Name, Adress, PhoneNumber, PaymentOption)
VALUES 
    ('Jens Jensen', 'Vejenvej 77', '87654321', 'Kort'),
    ('Lars Larsen', 'Bøgevej 13', '12345678', 'Mobile-Pay');

-- Insert into Order table
INSERT INTO [Order] (CustomerId, OrderDate, TotalAmount)
VALUES 
    (1, '2024-09-18', 260.00);

-- Insert into OrderDetail table
INSERT INTO OrderDetail (Price, Quantity, DishId, OrderId)
VALUES 
    (150.00, 1, 1, 1),
    (150.00, 2, 2, 1),
    (90.00, 1, 3, 1);

-- Insert into Cyclist table
INSERT INTO Cyclist (OrderId, CprNumber, PhoneNumber, BikeType)
VALUES 
    (1, '123456-7891', '23456789', 'e-Mountain Bike');

-- Insert trips with TripDate
INSERT INTO Trip (CyclistId, PickupAdress, DeliveryAdress, DeliveryTime, PickupTime, TripDate)
VALUES 
    (1, 'Mågevej 23', 'Bøgevej 13', '19:00:00', '18:30:00', '2024-09-19'),
    (1, 'HansensGade 1', 'Vejenvej 77', '19:00:00', '18:30:00', '2024-08-03'),
    (1, 'Nyvej 3', 'Stormgade 21', '18:00:00', '17:30:00', '2024-09-10'),
    (1, 'Havnegade 5', 'Markvej 7', '17:30:00', '17:00:00', '2024-08-15');


-- Insert into Trip table
/*INSERT INTO Trip (CyclistId, PickupAdress, DeliveryAdress, DeliveryTime, PickupTime)
VALUES 
    (1, 'Mågevej 23', 'Bøgevej 13', '19:00:00', '18:30:00'),
    (1, 'HansensGade 1', 'Vejenvej 77', '19:00:00', '18:30:00');*/
