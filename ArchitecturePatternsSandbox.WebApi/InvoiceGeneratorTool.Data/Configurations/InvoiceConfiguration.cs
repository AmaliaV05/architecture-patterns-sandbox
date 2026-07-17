using InvoiceGeneratorTool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGeneratorTool.Data.Configurations
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.TotalAmount).HasPrecision(18, 2);

            builder.HasData(
                new { Id = 1, TotalAmount = 4650.00m, Date = new DateTimeOffset(2026, 3, 12, 12, 4, 2, TimeSpan.Zero), ClientId = 1 },
                new { Id = 2, TotalAmount = 2200.00m, Date = new DateTimeOffset(2026, 3, 12, 12, 7, 56, TimeSpan.Zero), ClientId = 2 }
            );
        }
    }
}
