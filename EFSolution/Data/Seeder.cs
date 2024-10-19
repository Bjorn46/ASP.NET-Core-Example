using EFSolution.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFSolution.Data
{
    public class Seeder
    {
        // Seed method
        public static void Seed(FoodAppContext context)
        {
            if (!context.Cooks.Any())  // Seed cooks if none exist
            {
                var cooks = new Cook[]
                {
                    new Cook { Name = "John Doe", Rating = 5, CprNumber = "123456-7890", PhoneNumber = "12345678", Adress = "123 Main St" },
                    new Cook { Name = "Jane Smith", Rating = 4, CprNumber = "987654-3210", PhoneNumber = "87654321", Adress = "456 Oak Ave" }
                };
                context.Cooks.AddRange(cooks);
                context.SaveChanges();
            }

            // Seed Customers
            if (!context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer { Name = "Alice Johnson", Adress = "789 Pine Rd", PhoneNumber = "55512345", PaymentOption = "Credit Card" },
                    new Customer { Name = "Bob Brown", Adress = "321 Cedar Blvd", PhoneNumber = "55567890", PaymentOption = "PayPal" }
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            // Seed Cyclists
            if (!context.Cyclists.Any())
            {
                var cyclists = new List<Cyclist>
                {
                    new Cyclist { CprNumber = "456789-1234", PhoneNumber = "44455566", BikeType = "Mountain Bike" },
                    new Cyclist { CprNumber = "654321-9876", PhoneNumber = "77788899", BikeType = "Road Bike" }
                };
                context.Cyclists.AddRange(cyclists);
                context.SaveChanges();
            }

            // Seed Dishes
            if (!context.Dishes.Any())
            {
                var dishes = new Dish[]
                {
                    new Dish { CookId = 1, DishName =  "Potatoes with sauce", Price = 10.0m, Quantity = 50, StartTime = new TimeOnly(12,00), EndTime = new TimeOnly(14,30) },
                    new Dish { CookId = 1, DishName = "Rice and beef", Price = 20.0m, Quantity = 30, StartTime = new TimeOnly(13,00), EndTime = new TimeOnly(15,00) },
                    new Dish { CookId = 2,  DishName = "Spaghetti and sauce", Price = 30.0m, Quantity = 20, StartTime = new TimeOnly(11,00), EndTime = new TimeOnly(13,00) }
                };
                context.Dishes.AddRange(dishes);
                context.SaveChanges();
            }

            // Seed Orders
            if (!context.Orders.Any())
            {
                var orders = new List<Order>
                {
                    new Order { CustomerId = 1, OrderDate = DateOnly.FromDateTime(DateTime.Now), TotalAmount = 100.00m },
                    new Order { CustomerId = 2, OrderDate = DateOnly.FromDateTime(DateTime.Now), TotalAmount = 50.00m }
                };
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }

            //// Seed OrderDetails
            //if (!context.OrderDetails.Any())
            //{
            //    var orderDetails = new List<OrderDetail>
            //    {
            //        new OrderDetail { OrderId = 1, DishId = 1, Price = 10.0m, Quantity = 5 },
            //        new OrderDetail { OrderId = 2, DishId = 2, Price = 20.0m, Quantity = 2 }
            //    };
            //    context.OrderDetails.AddRange(orderDetails);
            //    context.SaveChanges();
            //}

            // Seed Trips
            if (!context.Trips.Any())
            {
                var trips = new List<Trip>
                {
                    new Trip { CyclistId = 1, PickupAdress = "Restaurant A", DeliveryAdress = "Customer A", PickupTime = new TimeOnly(10, 30), DeliveryTime = new TimeOnly(11, 00), TripDate = DateOnly.FromDateTime(DateTime.Now) },
                    new Trip { CyclistId = 2, PickupAdress = "Restaurant B", DeliveryAdress = "Customer B", PickupTime = new TimeOnly(12, 00), DeliveryTime = new TimeOnly(12, 30), TripDate = DateOnly.FromDateTime(DateTime.Now) }
                };
                context.Trips.AddRange(trips);
                context.SaveChanges();
            }
        }
    }
}
