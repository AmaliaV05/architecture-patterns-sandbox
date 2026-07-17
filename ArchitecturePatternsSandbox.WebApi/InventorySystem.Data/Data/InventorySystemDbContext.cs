using InventorySystem.Data.Entities;
using InventorySystem.Data.View;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Data.Data
{
    public class InventorySystemDbContext : DbContext
    {
        public InventorySystemDbContext(DbContextOptions<InventorySystemDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<LowStockProductView> LowStockProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleItem>()
                .HasKey(si => new { si.SaleId, si.ProductId });
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId);
            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(si => si.ProductId);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price).HasPrecision(18, 2);
                entity.Property(p => p.RowVersion).IsRowVersion().IsRequired();
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(s => s.TotalAmount).HasPrecision(18, 2);
                entity.ToTable("Sales", t => t.HasTrigger("tr_DecreaseStock"));
            });

            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, SaleDate = new DateTime(2026, 03, 12), TotalAmount = 100.00m },
                new Sale { Id = 2, SaleDate = new DateTime(2026, 03, 23), TotalAmount = 200.00m },
                new Sale { Id = 3, SaleDate = new DateTime(2026, 03, 25), TotalAmount = 300.00m },
                new Sale { Id = 4, SaleDate = new DateTime(2026, 04, 05), TotalAmount = 400.00m }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product A", Price = 10.00m, Stock = 100, MinStock = 10 },
                new Product { Id = 2, Name = "Product B", Price = 20.00m, Stock = 200, MinStock = 20 },
                new Product { Id = 3, Name = "Product C", Price = 30.00m, Stock = 300, MinStock = 30 },
                new Product { Id = 4, Name = "Product D", Price = 40.00m, Stock = 400, MinStock = 40 },
                new Product { Id = 5, Name = "Product E", Price = 50.00m, Stock = 45, MinStock = 50 }
            );

            modelBuilder.Entity<SaleItem>().HasData(
                new SaleItem { SaleId = 1, ProductId = 1, Quantity = 2 },
                new SaleItem { SaleId = 1, ProductId = 2, Quantity = 3 },
                new SaleItem { SaleId = 2, ProductId = 3, Quantity = 4 },
                new SaleItem { SaleId = 2, ProductId = 4, Quantity = 5 },
                new SaleItem { SaleId = 3, ProductId = 5, Quantity = 6 },
                new SaleItem { SaleId = 3, ProductId = 1, Quantity = 7 },
                new SaleItem { SaleId = 4, ProductId = 2, Quantity = 8 },
                new SaleItem { SaleId = 4, ProductId = 3, Quantity = 9 }
            );

            modelBuilder.Entity<LowStockProductView>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("v_LowStockProducts");
            });
        }
    }
}
