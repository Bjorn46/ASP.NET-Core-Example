using Microsoft.EntityFrameworkCore;
using EFSolution.Data;
namespace EFSolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var conn = builder.Configuration.GetConnectionString("FoodAppDatabase");
            builder.Services.AddDbContext<FoodAppContext>(options =>
            {
                options.UseSqlServer(conn);
            });
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Seed the database
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FoodAppContext>();
                context.Database.Migrate(); // Ensure database is up to date
                Seeder.Seed(context); // Call the Seeder method to seed the database
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

        }

    }
}
