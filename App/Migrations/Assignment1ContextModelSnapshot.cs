﻿// <auto-generated />
using System;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment2.Migrations
{
    [DbContext(typeof(Assignment2Context))]
    partial class Assignment1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.AvailableDish", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int")
                        .HasColumnName("dish_id");

                    b.Property<DateTime>("AvailableFrom")
                        .HasColumnType("datetime")
                        .HasColumnName("available_from");

                    b.Property<DateTime>("AvailableTo")
                        .HasColumnType("datetime")
                        .HasColumnName("available_to");

                    b.Property<string>("CookId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("cook_id");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)")
                        .HasColumnName("currency");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("DishId")
                        .HasName("PK__Availabl__9F2B4CF96E6A8AC6");

                    b.HasIndex("CookId");

                    b.ToTable("Available_Dishes", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.Bike", b =>
                {
                    b.Property<int>("BikeId")
                        .HasColumnType("int")
                        .HasColumnName("bike_id");

                    b.Property<string>("BikeType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("bike_type");

                    b.HasKey("BikeId")
                        .HasName("PK__Bikes__AD5B3CB77A0FA3B8");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("Assignment2.Models.Cook", b =>
                {
                    b.Property<string>("CookId")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("cook_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<bool>("HasPassedFoodSafetyCourse")
                        .HasColumnType("bit")
                        .HasColumnName("HasPassedFoodSafetyCourse");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CookId")
                        .HasName("PK__Cook__664AC19E3651D655");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Cook", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("PaymentOption")
                        .HasColumnType("int")
                        .HasColumnName("payment_option");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__CD65CB85F990168A");

                    b.HasIndex("PaymentOption");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.Cyclist", b =>
                {
                    b.Property<int>("CyclistId")
                        .HasColumnType("int")
                        .HasColumnName("cyclist_id");

                    b.Property<int>("BikeId")
                        .HasColumnType("int")
                        .HasColumnName("bike_id");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnName("Hourly_Rate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CyclistId")
                        .HasName("PK__Cyclist__0132811BF5C58F21");

                    b.HasIndex("BikeId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Cyclist", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("DeliveryTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Trip_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Trip_ID");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.DishOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("Delivery")
                        .HasColumnType("int")
                        .HasColumnName("delivery");

                    b.Property<int>("DishId")
                        .HasColumnType("int")
                        .HasColumnName("dish_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime")
                        .HasColumnName("order_date");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderId")
                        .HasName("PK__DishOrde__4659622977FF1B31");

                    b.HasIndex("Delivery");

                    b.HasIndex("DishId");

                    b.ToTable("DishOrder", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.PaymentOption", b =>
                {
                    b.Property<int>("OptionId")
                        .HasColumnType("int")
                        .HasColumnName("option_id");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("payment_type");

                    b.HasKey("OptionId")
                        .HasName("PK__Payment___F4EACE1BDF0F1076");

                    b.ToTable("Payment_Options", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .HasColumnType("int")
                        .HasColumnName("review_id");

                    b.Property<string>("Comments")
                        .HasColumnType("text")
                        .HasColumnName("comments");

                    b.Property<int?>("DeliveryRating")
                        .HasColumnType("int")
                        .HasColumnName("delivery_rating");

                    b.Property<int?>("FoodRating")
                        .HasColumnType("int")
                        .HasColumnName("food_rating");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.HasKey("ReviewId")
                        .HasName("PK__Review__60883D90D21AFAF2");

                    b.HasIndex("OrderId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .HasColumnType("int")
                        .HasColumnName("trip_id");

                    b.Property<TimeOnly?>("CompletionTime")
                        .HasColumnType("time")
                        .HasColumnName("completion_time");

                    b.Property<int>("CyclistId")
                        .HasColumnType("int")
                        .HasColumnName("cyclist_id");

                    b.HasKey("TripId")
                        .HasName("PK__Trip__302A5D9EFFC55EAE");

                    b.HasIndex("CyclistId");

                    b.ToTable("Trip", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Assignment2.Models.AvailableDish", b =>
                {
                    b.HasOne("Assignment2.Models.Cook", "Cook")
                        .WithMany("AvailableDishes")
                        .HasForeignKey("CookId")
                        .IsRequired()
                        .HasConstraintName("FK__Available__cook___267ABA7A");

                    b.Navigation("Cook");
                });

            modelBuilder.Entity("Assignment2.Models.Cook", b =>
                {
                    b.HasOne("Assignment2.Models.ApplicationUser", "User")
                        .WithOne("Cook")
                        .HasForeignKey("Assignment2.Models.Cook", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2.Models.Customer", b =>
                {
                    b.HasOne("Assignment2.Models.PaymentOption", "PaymentOptionNavigation")
                        .WithMany("Customers")
                        .HasForeignKey("PaymentOption")
                        .IsRequired()
                        .HasConstraintName("FK_Customer_Payment_Options");

                    b.Navigation("PaymentOptionNavigation");
                });

            modelBuilder.Entity("Assignment2.Models.Cyclist", b =>
                {
                    b.HasOne("Assignment2.Models.Bike", "Bike")
                        .WithMany("Cyclists")
                        .HasForeignKey("BikeId")
                        .IsRequired()
                        .HasConstraintName("FK_Cyclist_Bikes");

                    b.HasOne("Assignment2.Models.ApplicationUser", "User")
                        .WithOne("Cyclist")
                        .HasForeignKey("Assignment2.Models.Cyclist", "UserId");

                    b.Navigation("Bike");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment2.Models.Delivery", b =>
                {
                    b.HasOne("Assignment2.Models.Customer", "Customer")
                        .WithMany("Deliveries")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_Delivery_Customer");

                    b.HasOne("Assignment2.Models.Trip", "TripNavigation")
                        .WithMany("Deliveries")
                        .HasForeignKey("Trip_ID")
                        .IsRequired()
                        .HasConstraintName("FK_Delivery_Trip");

                    b.Navigation("Customer");

                    b.Navigation("TripNavigation");
                });

            modelBuilder.Entity("Assignment2.Models.DishOrder", b =>
                {
                    b.HasOne("Assignment2.Models.Delivery", "DeliveryNavigation")
                        .WithMany("DishOrders")
                        .HasForeignKey("Delivery")
                        .IsRequired()
                        .HasConstraintName("FK_DishOrder_Delivery");

                    b.HasOne("Assignment2.Models.AvailableDish", "Dish")
                        .WithMany("DishOrders")
                        .HasForeignKey("DishId")
                        .IsRequired()
                        .HasConstraintName("FK_DishOrder_Available_Dishes");

                    b.Navigation("DeliveryNavigation");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Assignment2.Models.Review", b =>
                {
                    b.HasOne("Assignment2.Models.DishOrder", "Order")
                        .WithMany("Reviews")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_Review_DishOrder");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Assignment2.Models.Trip", b =>
                {
                    b.HasOne("Assignment2.Models.Cyclist", "Cyclist")
                        .WithMany("Trips")
                        .HasForeignKey("CyclistId")
                        .IsRequired()
                        .HasConstraintName("FK__Trip__cyclist_id__34C8D9D1");

                    b.Navigation("Cyclist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Assignment2.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Assignment2.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Assignment2.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment2.Models.ApplicationUser", b =>
                {
                    b.Navigation("Cook");

                    b.Navigation("Cyclist");
                });

            modelBuilder.Entity("Assignment2.Models.AvailableDish", b =>
                {
                    b.Navigation("DishOrders");
                });

            modelBuilder.Entity("Assignment2.Models.Bike", b =>
                {
                    b.Navigation("Cyclists");
                });

            modelBuilder.Entity("Assignment2.Models.Cook", b =>
                {
                    b.Navigation("AvailableDishes");
                });

            modelBuilder.Entity("Assignment2.Models.Customer", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("Assignment2.Models.Cyclist", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Assignment2.Models.Delivery", b =>
                {
                    b.Navigation("DishOrders");
                });

            modelBuilder.Entity("Assignment2.Models.DishOrder", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Assignment2.Models.PaymentOption", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Assignment2.Models.Trip", b =>
                {
                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
