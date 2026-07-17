using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLowStockProductView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW v_LowStockProducts AS
                SELECT Id, Name, Stock, MinStock
                FROM Products
                WHERE Stock < MinStock;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS v_LowStockProducts;");
        }
    }
}
