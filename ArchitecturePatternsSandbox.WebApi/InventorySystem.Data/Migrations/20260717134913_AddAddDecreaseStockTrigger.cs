using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAddDecreaseStockTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TRIGGER tr_DecreaseStock
                ON Products
                AFTER UPDATE
                AS
                BEGIN
                    IF (ROWCOUNT_BIG() = 0) RETURN;

                    IF NOT UPDATE(Stock) 
                    BEGIN
                        UPDATE p
                        SET p.Stock = p.Stock - sub.TotalSold
                        FROM Products p
                        INNER JOIN (
                            SELECT si.ProductId, SUM(si.Quantity) AS TotalSold
                            FROM SaleItem si
                            INNER JOIN inserted i ON si.ProductId = i.Id
                            GROUP BY si.ProductId
                        ) sub ON p.Id = sub.ProductId;
                    END
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS tr_DecreaseStock;");
        }
    }
}
