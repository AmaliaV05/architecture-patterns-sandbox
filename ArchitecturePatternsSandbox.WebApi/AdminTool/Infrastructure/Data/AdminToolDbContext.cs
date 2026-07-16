using AdminTool.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminTool.Infrastructure.Data
{
    public class AdminToolDbContext : DbContext
    {
        public AdminToolDbContext(DbContextOptions<AdminToolDbContext> options) : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasIndex(s => s.Key).IsUnique();

                entity.HasData(
                    new Setting { Id = 1, Key = "VisualSettings:Theme", Value = "Light" },
                    new Setting { Id = 2, Key = "VisualSettings:MaintenanceMode", Value = "true" }
                );
            });
        }
    }
}
