using InvoiceGeneratorTool.Data.Configurations;
using InvoiceGeneratorTool.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGeneratorTool.Data.Data
{
    public class InvoiceGeneratorToolDbContext : DbContext
    {
        public InvoiceGeneratorToolDbContext(DbContextOptions<InvoiceGeneratorToolDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceProduct> InvoicesProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceProductConfiguration());
        }
    }
}
