using EFSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EFSolution.Data
{
    public class FoodAppContext : DbContext
    {
        public FoodAppContext(DbContextOptions<FoodAppContext> options) : base(options)
        {
        }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Cyclist> Cyclists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set;}
        public DbSet<Trip> Trips { get; set; }
    }
}
