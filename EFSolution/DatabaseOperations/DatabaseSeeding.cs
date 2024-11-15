using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.DatabaseOperations
{
    public static class DatabaseSeeding
    {
        public static async Task Seed(Assignment2Context context)
        {
            if (!await context.Cooks.AnyAsync())
            {
                await context.Cooks.AddRangeAsync(
                    new Cook { Address = "Finlandsgade 17, 8200 Aarhus N", PhoneNumber = "+45 71555080", CookId = "010100-4201", Name = "Noahs", HasPassedFoodSafetyCourse = true},
                    new Cook { Address = "Finlandsgade 18, 8200 Aarhus N", PhoneNumber = "+45 71555081", CookId = "010100-4202", Name = "Helle", HasPassedFoodSafetyCourse = true},
                    new Cook { Address = "Finlandsgade 19, 8200 Aarhus N", PhoneNumber = "+45 71555082", CookId = "010100-4203", Name = "Mads" , HasPassedFoodSafetyCourse = true }
                );
            }
            await context.SaveChangesAsync();

            if (!await context.AvailableDishes.AnyAsync())
            {
                await context.AvailableDishes.AddRangeAsync(
                    new AvailableDish { DishId = 1, Name = "Pasta",    Price = 30, Currency = "DKK", Quantity = 3,  AvailableFrom = DateTime.Parse("2024-09-09 11:30"), AvailableTo = DateTime.Parse("2024-09-09 12:30"), CookId = "010100-4201" },
                    new AvailableDish { DishId = 2, Name = "Romkugle", Price = 3,  Currency = "DKK", Quantity = 10, AvailableFrom = DateTime.Parse("2024-09-09 08:00"), AvailableTo = DateTime.Parse("2024-09-09 12:30"), CookId = "010100-4201" },
                    new AvailableDish { DishId = 3, Name = "Lemonade", Price = 10, Currency = "DKK", Quantity = 5,  AvailableFrom = DateTime.Parse("2024-09-09 11:30"), AvailableTo = DateTime.Parse("2024-09-09 12:30"), CookId = "010100-4202" }
                );
            }
            await context.SaveChangesAsync();

            if (!await context.PaymentOptions.AnyAsync())
            {
                await context.PaymentOptions.AddAsync(new PaymentOption { OptionId = 0, PaymentType = "Mobile Pay" });
            }
            await context.SaveChangesAsync();

            if (!await context.Customers.AnyAsync())
            {
                await context.Customers.AddAsync(new Customer { CustomerId = 0, Name = "Ashley Brown", Address = "Dummy Street 101", PhoneNumber = "+4512345678", PaymentOption = 0 });
            }
            await context.SaveChangesAsync();

            if (!await context.Bikes.AnyAsync())
            {
                await context.Bikes.AddAsync(new Bike { BikeId = 0, BikeType = "Normal Bike" });
            }
            await context.SaveChangesAsync();

            if (!await context.Cyclists.AnyAsync())
            {
                await context.Cyclists.AddAsync(new Cyclist { CyclistId = 0, Name = "Cyclist A", PhoneNumber = "+4512345678", HourlyRate = 10.0m, BikeId = 0 });
            }
            await context.SaveChangesAsync();

            if (!await context.Trips.AnyAsync())
            {
                await context.Trips.AddRangeAsync(
                    new Trip { TripId = 0, CyclistId = 0, CompletionTime = TimeOnly.Parse("01:30:00") },
                    new Trip { TripId = 1, CyclistId = 0, CompletionTime = TimeOnly.Parse("00:30:00") },
                    new Trip { TripId = 2, CyclistId = 0, CompletionTime = TimeOnly.Parse("01:30:00") },
                    new Trip { TripId = 3, CyclistId = 0, CompletionTime = TimeOnly.Parse("00:30:00") }
                );

            }
            await context.SaveChangesAsync();

            if (!await context.Deliveries.AnyAsync())
            {
                await context.Deliveries.AddRangeAsync(
                    new Delivery { Id = 0, CustomerId = 0, Trip_ID = 1, DeliveryTime = DateTime.Parse("2024-09-09 08:40") },
                    new Delivery { Id = 1, CustomerId = 0, Trip_ID = 0, DeliveryTime = DateTime.Parse("2024-09-09 08:42") },
                    new Delivery { Id = 2, CustomerId = 0, Trip_ID = 2, DeliveryTime = DateTime.Parse("2024-09-09 08:40") },
                    new Delivery { Id = 3, CustomerId = 0, Trip_ID = 3, DeliveryTime = DateTime.Parse("2024-09-09 08:42") }
                );
            }
            await context.SaveChangesAsync();

            if (!await context.DishOrders.AnyAsync())
            {
                await context.DishOrders.AddRangeAsync(
                    new DishOrder { OrderId = 1,  Delivery = 1, DishId = 3, OrderDate = DateTime.Parse("2024-09-09 08:00"), Quantity = 2 },
                    new DishOrder { OrderId = 2,  Delivery = 1, DishId = 2, OrderDate = DateTime.Parse("2024-09-09 08:02"), Quantity = 4 },
                    new DishOrder { OrderId = 3,  Delivery = 1, DishId = 1, OrderDate = DateTime.Parse("2024-09-09 08:04"), Quantity = 2 },
                    new DishOrder { OrderId = 4,  Delivery = 0, DishId = 3, OrderDate = DateTime.Parse("2024-09-09 08:00"), Quantity = 1 },
                    new DishOrder { OrderId = 5,  Delivery = 2, DishId = 3, OrderDate = DateTime.Parse("2024-08-09 08:00"), Quantity = 2 },
                    new DishOrder { OrderId = 6,  Delivery = 2, DishId = 2, OrderDate = DateTime.Parse("2024-08-09 08:02"), Quantity = 4 },
                    new DishOrder { OrderId = 7,  Delivery = 2, DishId = 1, OrderDate = DateTime.Parse("2024-08-09 08:04"), Quantity = 2 },
                    new DishOrder { OrderId = 8,  Delivery = 3, DishId = 3, OrderDate = DateTime.Parse("2024-08-09 08:02"), Quantity = 1 },
                    new DishOrder { OrderId = 9,  Delivery = 0, DishId = 1, OrderDate = DateTime.Parse("2024-09-09 08:08"), Quantity = 2 },
                    new DishOrder { OrderId = 10, Delivery = 3, DishId = 1, OrderDate = DateTime.Parse("2024-09-09 08:06"), Quantity = 2 }
                );
            }
            await context.SaveChangesAsync();

            if (!await context.Reviews.AnyAsync())
            {
                await context.Reviews.AddRangeAsync(
                    new Review { ReviewId = 0, DeliveryRating = null, FoodRating = 4, Comments = null, OrderId = 1 },
                    new Review { ReviewId = 1, DeliveryRating = null, FoodRating = 6, Comments = null, OrderId = 1 },
                    new Review { ReviewId = 2, DeliveryRating = null, FoodRating = 4, Comments = null, OrderId = 2 }
                );
            }

            await context.SaveChangesAsync();
        }



    }
}
