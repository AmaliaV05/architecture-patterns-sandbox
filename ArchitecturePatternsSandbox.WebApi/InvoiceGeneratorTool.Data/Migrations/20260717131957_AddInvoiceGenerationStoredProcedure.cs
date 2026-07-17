using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGeneratorTool.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceGenerationStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE  sp_GenerateInvoice
                    @json nvarchar(max)                    
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- 1. Variables to hold temporary data
                    DECLARE @NewInvoiceId INT;                   
                    DECLARE @TotalAmount DECIMAL(18, 2) = 0;
                    
                    BEGIN TRANSACTION;

                    BEGIN TRY
                        -- 2. Insert the main Invoice
                        INSERT INTO Invoices (ClientId, [Date], TotalAmount)
                        VALUES (
                            JSON_VALUE(@json, '$.ClientId'), 
                            SYSDATETIMEOFFSET(), 
                            @TotalAmount -- Initial placeholder
                        );

                        -- Capture the ID of the invoice we just created
                        SET @NewInvoiceId = SCOPE_IDENTITY();

                        -- 3. Insert into the Junction Table (InvoiceProduct)
                        INSERT INTO InvoicesProducts (InvoiceId, ProductId, Quantity)
                        SELECT 
                            @NewInvoiceId,
                            productId,
                            qty
                        FROM OPENJSON(@json, '$.InvoicesProducts') WITH (
                            productId INT '$.ProductId',
                            qty INT '$.Quantity'
                        );

                        -- 4. (Optional) Update the Invoice TotalAmount based on Product prices
                        -- This assumes your Product table has a 'Price' column
                        UPDATE Invoices
                        SET TotalAmount = ISNULL((
                            SELECT SUM(ip.Quantity * p.Price)
                            FROM InvoicesProducts ip
                            JOIN Products p ON ip.ProductId = p.Id
                            WHERE ip.InvoiceId = @NewInvoiceId
                        ), 0)
                        WHERE Id = @NewInvoiceId;

                        COMMIT TRANSACTION;
                    END TRY
                    BEGIN CATCH
                        IF @@TRANCOUNT > 0
                            ROLLBACK TRANSACTION;
                        THROW; -- Rethrow error for debugging
                    END CATCH
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE sp_GenerateInvoice");
        }
    }
}
