using Assignment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.DatabaseOperations
{
    public static class DatabaseSeeding
    {

        private static async Task<ApplicationUser> CreateUser(UserManager<ApplicationUser> userManager, string name, string userName, string email, string password, string role)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                Name = name
            };

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, role);
            return user;
        }

        private static async Task<ApplicationUser> GetOrCreateUser(UserManager<ApplicationUser> userManager, string name, string username, string email,string password, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null) 
                return await CreateUser(userManager, name, username, email, password, role);
            else return await userManager.FindByEmailAsync(email); 
        }

        public static async Task Seed(Assignment2Context context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Cook"));
                await roleManager.CreateAsync(new IdentityRole("Cyclist"));
                await roleManager.CreateAsync(new IdentityRole("Manager"));
            }


            _ = await GetOrCreateUser(userManager, "Admin User", "admin@example.com", "admin@example.com", "Admin123!", "Admin");
            _ = await GetOrCreateUser(userManager, "Manager User", "manager@example.com", "manager@example.com", "Manager123!", "Manager");

            if (!await context.Cooks.AnyAsync())
            {
                ApplicationUser helleUser = await GetOrCreateUser(userManager, "helle", "helle@example.com", "helle@example.com", "Cook123!", "Cook");
                ApplicationUser noahUser = await GetOrCreateUser(userManager, "noah", "noah@example.com", "noah@example.com", "Cook123!", "Cook");
                ApplicationUser madsUser = await GetOrCreateUser(userManager, "mads", "mads@example.com", "mads@example.com", "Cook123!", "Cook");


                await context.Cooks.AddRangeAsync(
                    new Cook { Address = "Finlandsgade 17, 8200 Aarhus N", PhoneNumber = "+45 71555080", CookId = "010100-4201", Name = "Noahs", HasPassedFoodSafetyCourse = true, UserId = noahUser.Id},
                    new Cook { Address = "Finlandsgade 18, 8200 Aarhus N", PhoneNumber = "+45 71555081", CookId = "010100-4202", Name = "Helle", HasPassedFoodSafetyCourse = true, UserId = helleUser.Id},
                    new Cook { Address = "Finlandsgade 19, 8200 Aarhus N", PhoneNumber = "+45 71555082", CookId = "010100-4203", Name = "Mads" , HasPassedFoodSafetyCourse = true, UserId = madsUser.Id }
                );
            }
            await context.SaveChangesAsync();

            if (!await context.AvailableDishes.AnyAsync())
            {
                await context.AvailableDishes.AddRangeAsync(
                    new AvailableDish { DishId = 1, Name = "Pasta",    Price = 30, Currency = "DKK", Quantity = 3,  AvailableFrom = DateTime.Parse("2024-09-09 11:30"), AvailableTo = DateTime.Parse("2024-09-10 12:30"), CookId = "010100-4201" },
                    new AvailableDish { DishId = 2, Name = "Romkugle", Price = 3,  Currency = "DKK", Quantity = 10, AvailableFrom = DateTime.Parse("2024-09-09 08:00"), AvailableTo = DateTime.Parse("2024-09-10 12:30"), CookId = "010100-4201" },
                    new AvailableDish { DishId = 3, Name = "Lemonade", Price = 10, Currency = "DKK", Quantity = 5,  AvailableFrom = DateTime.Parse("2024-09-09 11:30"), AvailableTo = DateTime.Parse("2024-09-10 12:30"), CookId = "010100-4202" }
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
                var cyclistAUser = await GetOrCreateUser(userManager, "CyclistA", "CyclistA@example.com", "CyclistA@example.com", "Cyclist123!", "Cyclist");
                var cyclistBUser = await GetOrCreateUser(userManager, "CyclistB", "CyclistB@example.com", "CyclistB@example.com", "Cyclist123!", "Cyclist");

                await context.Cyclists.AddAsync(new Cyclist { CyclistId = 0, Name = "Cyclist A", PhoneNumber = "+4512345678", HourlyRate = 10.0m, BikeId = 0, UserId = cyclistAUser.Id });
                await context.Cyclists.AddAsync(new Cyclist { CyclistId = 1, Name = "Cyclist B", PhoneNumber = "+4512345679", HourlyRate = 20.0m, BikeId = 0, UserId = cyclistBUser.Id });
            }
            await context.SaveChangesAsync();

            if (!await context.Trips.AnyAsync())
            {
                await context.Trips.AddRangeAsync(
                    new Trip { TripId = 0, CyclistId = 0, CompletionTime = TimeOnly.Parse("01:30:00") },
                    new Trip { TripId = 1, CyclistId = 0, CompletionTime = TimeOnly.Parse("00:30:00") },
                    new Trip { TripId = 2, CyclistId = 0, CompletionTime = TimeOnly.Parse("01:30:00") },
                    new Trip { TripId = 3, CyclistId = 0, CompletionTime = TimeOnly.Parse("00:30:00") },
                    new Trip { TripId = 4, CyclistId = 1, CompletionTime = TimeOnly.Parse("01:30:00") },
                    new Trip { TripId = 5, CyclistId = 1, CompletionTime = TimeOnly.Parse("00:30:00") },
                    new Trip { TripId = 6, CyclistId = 1, CompletionTime = TimeOnly.Parse("01:30:00") },
                    new Trip { TripId = 7, CyclistId = 1, CompletionTime = TimeOnly.Parse("00:30:00") }
                );
            }
            await context.SaveChangesAsync();

            if (!await context.Deliveries.AnyAsync())
            {
                await context.Deliveries.AddRangeAsync(
                    new Delivery { Id = 0, CustomerId = 0, Trip_ID = 1, DeliveryTime = DateTime.Parse("2024-09-09 08:40") },
                    new Delivery { Id = 1, CustomerId = 0, Trip_ID = 0, DeliveryTime = DateTime.Parse("2024-09-09 08:42") },
                    new Delivery { Id = 2, CustomerId = 0, Trip_ID = 2, DeliveryTime = DateTime.Parse("2024-09-09 08:40") },
                    new Delivery { Id = 3, CustomerId = 0, Trip_ID = 3, DeliveryTime = DateTime.Parse("2024-09-09 08:42") },
                    new Delivery { Id = 4, CustomerId = 0, Trip_ID = 4, DeliveryTime = DateTime.Parse("2024-09-10 08:40") },
                    new Delivery { Id = 5, CustomerId = 0, Trip_ID = 5, DeliveryTime = DateTime.Parse("2024-09-10 08:42") },
                    new Delivery { Id = 6, CustomerId = 0, Trip_ID = 6, DeliveryTime = DateTime.Parse("2024-09-10 08:40") },
                    new Delivery { Id = 7, CustomerId = 0, Trip_ID = 7, DeliveryTime = DateTime.Parse("2024-09-10 08:42") }
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
                    new DishOrder { OrderId = 10, Delivery = 3, DishId = 1, OrderDate = DateTime.Parse("2024-09-09 08:06"), Quantity = 2 },
                    new DishOrder { OrderId = 11, Delivery = 4, DishId = 3, OrderDate = DateTime.Parse("2024-09-09 08:00"), Quantity = 2 },
                    new DishOrder { OrderId = 12, Delivery = 4, DishId = 2, OrderDate = DateTime.Parse("2024-09-09 08:02"), Quantity = 4 },
                    new DishOrder { OrderId = 13, Delivery = 5, DishId = 1, OrderDate = DateTime.Parse("2024-09-09 08:04"), Quantity = 2 },
                    new DishOrder { OrderId = 14, Delivery = 5, DishId = 3, OrderDate = DateTime.Parse("2024-09-09 08:00"), Quantity = 1 },
                    new DishOrder { OrderId = 15, Delivery = 6, DishId = 3, OrderDate = DateTime.Parse("2024-08-09 08:00"), Quantity = 2 },
                    new DishOrder { OrderId = 16, Delivery = 6, DishId = 2, OrderDate = DateTime.Parse("2024-08-09 08:02"), Quantity = 4 },
                    new DishOrder { OrderId = 17, Delivery = 7, DishId = 1, OrderDate = DateTime.Parse("2024-08-09 08:04"), Quantity = 2 },
                    new DishOrder { OrderId = 18, Delivery = 7, DishId = 3, OrderDate = DateTime.Parse("2024-08-09 08:02"), Quantity = 1 }
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
