using InvoiceGeneratorTool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGeneratorTool.Data.Configurations
{
    internal class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoiceProduct>
    {
        public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
        {
            builder.HasKey(ip => new { ip.InvoiceId, ip.ProductId });

            builder.HasOne(ip => ip.Invoice)
                  .WithMany(i => i.InvoiceProducts)
                  .HasForeignKey(ip => ip.InvoiceId);

            builder.HasOne(ip => ip.Product)
                  .WithMany(p => p.InvoiceProducts)
                  .HasForeignKey(ip => ip.ProductId);

            builder.Property(ip => ip.Quantity).IsRequired();

            builder.HasData(
                new InvoiceProduct { InvoiceId = 1, ProductId = 1, Quantity = 1 },
                new InvoiceProduct { InvoiceId = 1, ProductId = 2, Quantity = 1 },
                new InvoiceProduct { InvoiceId = 2, ProductId = 3, Quantity = 1 }
            );
        }
    }
}
