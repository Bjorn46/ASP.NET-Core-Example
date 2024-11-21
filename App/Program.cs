
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using Assignment2.DatabaseOperations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Assignment2.Services;
using Assignment2.Services.Interfaces;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using MongoDB.Driver;

namespace Assignment2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Host to use serilog (Reads from appsettings.json)
            builder.Host.UseSerilog((ctx, lc) =>
            {
                lc.ReadFrom.Configuration(ctx.Configuration) // Reads configuration from appsettings.json
                  .Enrich.With(new EmailEnricher(new HttpContextAccessor())) // Custom email enricher
                  .Enrich.With(new HttpMethodEnricher(new HttpContextAccessor())); // Custom http method enricher
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Assignment2 API",
                    Version = "v1",
                    Description = "Food Delivery API with Authentication"
                });

                // Define the security scheme
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });
            // Assignment B
            builder.Services.AddScoped<IAvailableDishService2B, AvailableDishService2B>();
            builder.Services.AddScoped<ICookService, CookService>();
            builder.Services.AddScoped<ICyclistService, CyclistSerivce>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<ITripService, TripService>();
            
            // Assignment C
            builder.Services.AddScoped<IAvailableDishService2C, AvailableDishService2C>();

            // Logging service
            builder.Services.AddScoped<ILogService, LogService>();

            // Register custom serilog enricher
            builder.Services.AddHttpContextAccessor();

            // connectionstring is not in user secrets for easy access between group members.
            var conn = builder.Configuration.GetConnectionString("database");
            builder.Services.AddDbContext<Assignment2Context>(options =>
            {
                options.UseSqlServer(conn);
            });

            // Confgiuring MongoDB connection
            var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDatabase");
            var mongoClient = new MongoClient(mongoConnectionString);
            var mongoDatabase = mongoClient.GetDatabase("myNewDB"); // Replace "myNewDB" with your actual database name

            // Register mongo database as singleton
            builder.Services.AddSingleton(mongoDatabase);

            // Add Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;

                // User settings
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<Assignment2Context>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();


            // Add Authentication and JWT configuration
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });


            var app = builder.Build();

            // Seed the database after building the app
            using (var scope = app.Services.CreateScope()) // creating scope, ensuring services are disposed afterwards 
            {
                var services = scope.ServiceProvider; // provides access to our specific service - in this case our database context
                var context = services.GetRequiredService<Assignment2Context>();
                context.Database.Migrate(); // Applies pending database migrations 

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await DatabaseSeeding.Seed(context, userManager, roleManager); // Finally seeding the database with data
            }


            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // Run the app and ensure Serilog flushes logs on shutdown
            try
            {
                app.Run();
            }
            finally
            {
                Log.CloseAndFlush(); // Ensures logs are flushed on shutdown
            }
        }
    }
}
