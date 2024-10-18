using EFSolution.Models;

namespace EFSolution.Data
{
    public class Seeder
    {
        // Seed method
        public static void Seed(FoodAppContext context)
        {
            // Check if the database has been seeded
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(new List<Dish>
                {
                    new Dish { DishName = "Potatoes with sauce", Price = 10.0m },
                    new Dish { DishName = "Rice and beef", Price = 20.0m },
                    new Dish { DishName = "Spagetti and sauce", Price = 30.0m },
                });

                context.SaveChanges(); // Save changes to the database
            }
        }
    }
}
