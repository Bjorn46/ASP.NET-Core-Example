
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using Assignment2.Services.Assignment2BServices;
using Assignment2.Services.Assignment2CServices;
using Assignment2.DatabaseOperations; 

namespace Assignment2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Assignment B
            builder.Services.AddScoped<IAvailableDishService2B, AvailableDishService2B>();
            builder.Services.AddScoped<ICookService, CookService>();
            builder.Services.AddScoped<ICyclistService, CyclistSerivce>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<ITripService, TripService>();
            
            // Assignment C
            builder.Services.AddScoped<IAvailableDishService2C, AvailableDishService2C>();

            // connectionstring is not in user secrets for easy access between group members.
            var conn = builder.Configuration.GetConnectionString("database");
            builder.Services.AddDbContext<Assignment2Context>(options =>
            {
                options.UseSqlServer(conn);
            });

            var app = builder.Build();

            // Seed the database after building the app
            using (var scope = app.Services.CreateScope()) // creating scope, ensuring services are disposed afterwards 
            {
                var services = scope.ServiceProvider; // provides access to our specific service - in this case our database context
                var context = services.GetRequiredService<Assignment2Context>();
                context.Database.Migrate(); // Applies pending database migrations 

                await DatabaseSeeding.Seed(context); // Finally seeding the database with data
            }

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
