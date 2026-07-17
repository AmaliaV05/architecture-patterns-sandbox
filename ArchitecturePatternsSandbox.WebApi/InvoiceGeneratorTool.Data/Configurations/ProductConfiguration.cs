using InvoiceGeneratorTool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGeneratorTool.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).HasPrecision(18, 2);

            builder.HasData(
                new Product { Id = 1, Name = "Laptop Dell XPS", Price = 4500.00m },
                new Product { Id = 2, Name = "Mouse Wireless", Price = 150.00m },
                new Product { Id = 3, Name = "Monitor 4K", Price = 2200.00m }
            );
        }
    }
}
