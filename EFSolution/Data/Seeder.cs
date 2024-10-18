using EFSolution.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFSolution.Data
{
    public class Seeder
    {
        // Seed method
        public static void Seed(FoodAppContext context)
        {
            // Seed Cooks
            if (!context.Cooks.Any())
            {
                context.Cooks.AddRange(new List<Cook>
                {
                    new Cook { Name = "John Doe", Rating = 5, CprNumber = "123456-7890", PhoneNumber = "12345678", Adress = "123 Main St" },
                    new Cook { Name = "Jane Smith", Rating = 4, CprNumber = "987654-3210", PhoneNumber = "87654321", Adress = "456 Oak Ave" }
                });
                context.SaveChanges();
            }

            // Seed Customers
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(new List<Customer>
                {
                    new Customer { Name = "Alice Johnson", Adress = "789 Pine Rd", PhoneNumber = "55512345", PaymentOption = "Credit Card" },
                    new Customer { Name = "Bob Brown", Adress = "321 Cedar Blvd", PhoneNumber = "55567890", PaymentOption = "PayPal" }
                });
                context.SaveChanges();
            }

            // Seed Cyclists
            if (!context.Cyclists.Any())
            {
                context.Cyclists.AddRange(new List<Cyclist>
                {
                    new Cyclist { CprNumber = "456789-1234", PhoneNumber = "44455566", BikeType = "Mountain Bike" },
                    new Cyclist { CprNumber = "654321-9876", PhoneNumber = "77788899", BikeType = "Road Bike" }
                });
                context.SaveChanges();
            }

            // Seed Dishes
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish { DishName = "Potatoes with sauce", Price = 10.0m, Quantity = 50 },
                    new Dish { DishName = "Rice and beef", Price = 20.0m, Quantity = 30 },
                    new Dish { DishName = "Spaghetti and sauce", Price = 30.0m, Quantity = 20 }
                });
                context.SaveChanges();
            }

            // Seed Orders
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(new List<Order>
                {
                    new Order { CustomerId = 1, OrderDate = DateOnly.FromDateTime(DateTime.Now), TotalAmount = 100.00m },
                    new Order { CustomerId = 2, OrderDate = DateOnly.FromDateTime(DateTime.Now), TotalAmount = 50.00m }
                });
                context.SaveChanges();
            }

            // Seed OrderDetails
            if (!context.OrderDetails.Any())
            {
                context.OrderDetails.AddRange(new List<OrderDetail>
                {
                    new OrderDetail { OrderId = 1, DishId = 1, Price = 10.0m, Quantity = 5 },
                    new OrderDetail { OrderId = 2, DishId = 2, Price = 20.0m, Quantity = 2 }
                });
                context.SaveChanges();
            }

            // Seed Trips
            if (!context.Trips.Any())
            {
                context.Trips.AddRange(new List<Trip>
                {
                    new Trip { CyclistId = 1, PickupAdress = "Restaurant A", DeliveryAdress = "Customer A", PickupTime = new TimeOnly(10, 30), DeliveryTime = new TimeOnly(11, 00), TripDate = DateOnly.FromDateTime(DateTime.Now) },
                    new Trip { CyclistId = 2, PickupAdress = "Restaurant B", DeliveryAdress = "Customer B", PickupTime = new TimeOnly(12, 00), DeliveryTime = new TimeOnly(12, 30), TripDate = DateOnly.FromDateTime(DateTime.Now) }
                });
                context.SaveChanges();
            }
        }
    }
}
