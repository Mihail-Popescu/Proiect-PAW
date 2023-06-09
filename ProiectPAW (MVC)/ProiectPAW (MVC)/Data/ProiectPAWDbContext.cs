﻿using ProiectPAW__MVC_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProiectPAW__MVC_.Data
{
    public class ProiectPAWDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;

        public ProiectPAWDbContext(DbContextOptions<ProiectPAWDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // other configuration code...
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>()
        .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);
            modelBuilder.Entity<ActiveService>()
                .HasKey(c => c.ActiveServiceId);
            modelBuilder.Entity<Address>()
                .HasKey(c => c.AddressId);
            modelBuilder.Entity<Card>()
                .HasKey(c => c.CardId);
            modelBuilder.Entity<Order>()
                .HasKey(c => c.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasKey(c => c.OrderItemId);
            modelBuilder.Entity<Admin>()
                .HasKey(c => c.AdminId);
        }

        public DbSet<ActiveService> ActiveService { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Admin> Admin { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
