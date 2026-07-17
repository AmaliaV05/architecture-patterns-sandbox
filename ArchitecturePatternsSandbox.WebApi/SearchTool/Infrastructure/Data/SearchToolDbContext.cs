using Microsoft.EntityFrameworkCore;
using SearchTool.Infrastructure.Data.Entities;

namespace SearchTool.Infrastructure.Data
{
    public class SearchToolDbContext : DbContext
    {
        public SearchToolDbContext(DbContextOptions<SearchToolDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Name);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop for work and gaming." },
                new Product { Id = 2, Name = "Smartphone", Description = "A sleek smartphone with a powerful camera." },
                new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones for immersive sound." },
                new Product { Id = 4, Name = "Smartwatch", Description = "A stylish smartwatch with fitness tracking features." },
                new Product { Id = 5, Name = "Tablet", Description = "A lightweight tablet perfect for reading and browsing." },
                new Product { Id = 6, Name = "Gaming Console", Description = "A next-gen gaming console for an immersive gaming experience." },
                new Product { Id = 7, Name = "Camera", Description = "A high-resolution camera for capturing stunning photos." },
                new Product { Id = 8, Name = "Bluetooth Speaker", Description = "A portable Bluetooth speaker with excellent sound quality." },
                new Product { Id = 9, Name = "External Hard Drive", Description = "A reliable external hard drive for data backup." },
                new Product { Id = 10, Name = "Wireless Mouse", Description = "A comfortable wireless mouse for everyday use." },
                new Product { Id = 11, Name = "Keyboard", Description = "A mechanical keyboard with customizable RGB lighting." },
                new Product { Id = 12, Name = "Monitor", Description = "A high-resolution monitor for work and gaming." },
                new Product { Id = 13, Name = "Printer", Description = "A versatile printer for home and office use." },
                new Product { Id = 14, Name = "Router", Description = "A high-speed router for reliable internet connectivity." },
                new Product { Id = 15, Name = "Smart Home Hub", Description = "A smart home hub to control all your smart devices." }
            );
        }
    }
}
