using DataHeavyTool.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataHeavyTool.Data.Data
{
    public class DataHeavyToolDbContext : DbContext
    {
        public DataHeavyToolDbContext(DbContextOptions<DataHeavyToolDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(x => x.AssetTicker).HasMaxLength(10);
                entity.Property(x => x.TransactionType).HasConversion<string>().HasMaxLength(10);
                entity.Property(x => x.Quantity).HasPrecision(18, 8);
                entity.Property(x => x.PricePerUnit).HasPrecision(18, 4);
                entity.Property(x => x.Fee).HasPrecision(10, 2);
            });
        }
    }
}
