using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechStockSync.Api.Entities;

namespace TechStockSync.Api.Data
{
    public class TechStockDbContext : DbContext
    {
        public TechStockDbContext(DbContextOptions<TechStockDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- CATEGORIES ---
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // --- PRODUCTS ---
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Sku).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasPrecision(18, 2);

                entity.HasIndex(e => e.Sku).IsUnique();
            });

            // --- CUSTOMERS ---
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.CompanyName).HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.HasIndex(e => e.Email);
            });

            // --- ORDERS ---
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
                entity.Property(e => e.InvoicePath).HasMaxLength(500);

                entity.HasIndex(e => e.WooCommerceOrderId).IsUnique();
            });

            // --- ORDER ITEMS ---
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PurchasePrice).HasPrecision(18, 2);
            });
        }
    }
}
