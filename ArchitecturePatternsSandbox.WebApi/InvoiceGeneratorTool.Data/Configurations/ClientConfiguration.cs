using InvoiceGeneratorTool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGeneratorTool.Data.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Credit).HasPrecision(18, 2);

            builder.HasMany(c => c.Invoices)
                  .WithOne(i => i.Client)
                  .IsRequired();

            builder.HasData(
                new Client { Id = 1, Name = "Jerry P.", Credit = 5000.00m },
                new Client { Id = 2, Name = "Bell B.", Credit = 1200.50m }
            );
        }
    }
}
