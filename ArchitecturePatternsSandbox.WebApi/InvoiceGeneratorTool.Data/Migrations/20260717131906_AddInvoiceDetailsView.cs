using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGeneratorTool.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW v_InvoiceDetails
                AS
                    SELECT InvoiceId, TotalAmount, Date, ProductId, p.Name AS Product, Price, Quantity, Price * Quantity * (1 + 0.21) AS SubTotal, ClientId, c.Name AS 'Client Name'
                    FROM Invoices i
                    INNER JOIN InvoicesProducts ip ON i.Id = ip.InvoiceId
                    INNER JOIN Products p ON ip.ProductId = p.Id
                    INNER JOIN Clients c ON c.Id = i.ClientId;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW v_InvoiceDetails");
        }
    }
}
