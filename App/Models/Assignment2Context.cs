using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Models;

public partial class Assignment2Context : IdentityDbContext<ApplicationUser>
{
    public Assignment2Context()
    {
    }

    public Assignment2Context(DbContextOptions<Assignment2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AvailableDish> AvailableDishes { get; set; }

    public virtual DbSet<Bike> Bikes { get; set; }

    public virtual DbSet<Cook> Cooks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Cyclist> Cyclists { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<DishOrder> DishOrders { get; set; }

    public virtual DbSet<PaymentOption> PaymentOptions { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 

        modelBuilder.Entity<AvailableDish>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK__Availabl__9F2B4CF96E6A8AC6");

            entity.ToTable("Available_Dishes");

            entity.Property(e => e.DishId)
                .ValueGeneratedNever()
                .HasColumnName("dish_id");
            entity.Property(e => e.AvailableFrom)
                .HasColumnType("datetime")
                .HasColumnName("available_from");
            entity.Property(e => e.AvailableTo)
                .HasColumnType("datetime")
                .HasColumnName("available_to");
            entity.Property(e => e.CookId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cook_id");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Cook).WithMany(p => p.AvailableDishes)
                .HasForeignKey(d => d.CookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Available__cook___267ABA7A");
        });

        modelBuilder.Entity<Bike>(entity =>
        {
            entity.HasKey(e => e.BikeId).HasName("PK__Bikes__AD5B3CB77A0FA3B8");

            entity.Property(e => e.BikeId)
                .ValueGeneratedNever()
                .HasColumnName("bike_id");
            entity.Property(e => e.BikeType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bike_type");
        });

        modelBuilder.Entity<Cook>(entity =>
        {
            entity.HasKey(e => e.CookId).HasName("PK__Cook__664AC19E3651D655");

            entity.ToTable("Cook");

            entity.Property(e => e.CookId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cook_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity
                .Property(e => e.HasPassedFoodSafetyCourse)
                .HasColumnName("HasPassedFoodSafetyCourse");
            entity.HasOne(d => d.User).WithOne(p => p.Cook).HasForeignKey<Cook>(d => d.UserId).IsRequired(false); 

        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB85F990168A");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PaymentOption)
                .HasColumnName("payment_option");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.PaymentOptionNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.PaymentOption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Payment_Options");
        });

        modelBuilder.Entity<Cyclist>(entity =>
        {
            entity.HasKey(e => e.CyclistId).HasName("PK__Cyclist__0132811BF5C58F21");

            entity.ToTable("Cyclist");

            entity.Property(e => e.CyclistId)
                .ValueGeneratedNever()
                .HasColumnName("cyclist_id");
            entity.Property(e => e.BikeId).HasColumnName("bike_id");
            entity.Property(e => e.HourlyRate)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Hourly_Rate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.Bike).WithMany(p => p.Cyclists)
                .HasForeignKey(d => d.BikeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cyclist_Bikes");
            entity.HasOne(d => d.User).WithOne(p => p.Cyclist).HasForeignKey<Cyclist>(d => d.UserId).IsRequired(false);

        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.ToTable("Delivery");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DeliveryTime).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Customer");

            entity.HasOne(d => d.TripNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.Trip_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Trip");
        });

        modelBuilder.Entity<DishOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__DishOrde__4659622977FF1B31");

            entity.ToTable("DishOrder");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.Delivery).HasColumnName("delivery");
            entity.Property(e => e.DishId).HasColumnName("dish_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.DeliveryNavigation).WithMany(p => p.DishOrders)
                .HasForeignKey(d => d.Delivery)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DishOrder_Delivery");

            entity.HasOne(d => d.Dish).WithMany(p => p.DishOrders)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DishOrder_Available_Dishes");
        });

        modelBuilder.Entity<PaymentOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Payment___F4EACE1BDF0F1076");

            entity.ToTable("Payment_Options");

            entity.Property(e => e.OptionId)
                .ValueGeneratedNever()
                .HasColumnName("option_id");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("payment_type");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__60883D90D21AFAF2");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("review_id");
            entity.Property(e => e.Comments)
                .HasColumnType("text")
                .HasColumnName("comments");
            entity.Property(e => e.DeliveryRating).HasColumnName("delivery_rating");
            entity.Property(e => e.FoodRating).HasColumnName("food_rating");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_DishOrder");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trip__302A5D9EFFC55EAE");

            entity.ToTable("Trip");

            entity.Property(e => e.TripId)
                .ValueGeneratedNever()
                .HasColumnName("trip_id");
            entity.Property(e => e.CompletionTime).HasColumnName("completion_time");
            entity.Property(e => e.CyclistId).HasColumnName("cyclist_id");
            entity.HasOne(d => d.Cyclist).WithMany(p => p.Trips)
                .HasForeignKey(d => d.CyclistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trip__cyclist_id__34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
