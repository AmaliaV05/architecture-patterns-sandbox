using ECommerceLite.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceLite.Data.Data
{
    public class ECommerceLiteDbContext : DbContext
    {
        public ECommerceLiteDbContext(DbContextOptions<ECommerceLiteDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ProductName).IsRequired();
                entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
                entity.Property(e => e.CustomerEmail).IsRequired();
            });
        }
    }
}
