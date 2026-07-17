using Microsoft.EntityFrameworkCore;
using StatusCheckSystem.Data.Entities;

namespace StatusCheckSystem.Data.Data
{
    public class StatusCheckSystemDbContext : DbContext
    {
        public StatusCheckSystemDbContext(DbContextOptions<StatusCheckSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<VerificationLog> Verifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VerificationLog>()
                .HasIndex(v => v.Url);
        }
    }
}
