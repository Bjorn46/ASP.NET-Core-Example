using System;
using System.Collections.Generic;
using EFSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace EFSolution.Data;

public partial class FoodAppContext : DbContext
{
    public FoodAppContext()
    {
    }

    public FoodAppContext(DbContextOptions<FoodAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cook> Cooks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Cyclist> Cyclists { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=FoodApp;User Id=sa;Password=YourStrongPassword!;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cook>(entity =>
        {
            entity.HasKey(e => e.CookId).HasName("PK__Cook__E5180761E2C898F6");

            entity.ToTable("Cook");

            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.CprNumber).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8BD815AB5");

            entity.ToTable("Customer");

            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PaymentOption).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Cyclist>(entity =>
        {
            entity.HasKey(e => e.CyclistId).HasName("PK__Cyclist__A3CBF9808C3994CD");

            entity.ToTable("Cyclist");

            entity.Property(e => e.BikeType).HasMaxLength(20);
            entity.Property(e => e.CprNumber).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.Order).WithMany(p => p.Cyclists)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderId");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK__Dish__18834F50121FFBE0");

            entity.ToTable("Dish");

            entity.Property(e => e.DishName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cook).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.CookId)
                .HasConstraintName("FK_DishCookId");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF0EBF0D9A");

            entity.ToTable("Order");

            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_OrderCustomerId");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36C7F7AC854");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Dish).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.DishId)
                .HasConstraintName("FK_OrderDetailDishId");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetailOrderId");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trip__51DC713ED4B85493");

            entity.ToTable("Trip");

            entity.Property(e => e.DeliveryAdress).HasMaxLength(100);
            entity.Property(e => e.PickupAdress).HasMaxLength(100);

            entity.HasOne(d => d.Cyclist).WithMany(p => p.Trips)
                .HasForeignKey(d => d.CyclistId)
                .HasConstraintName("FK_TripCyclistId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
