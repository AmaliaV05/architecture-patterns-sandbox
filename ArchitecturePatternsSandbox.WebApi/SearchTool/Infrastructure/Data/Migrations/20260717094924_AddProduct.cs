using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SearchTool.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A high-performance laptop for work and gaming.", "Laptop" },
                    { 2, "A sleek smartphone with a powerful camera.", "Smartphone" },
                    { 3, "Noise-cancelling headphones for immersive sound.", "Headphones" },
                    { 4, "A stylish smartwatch with fitness tracking features.", "Smartwatch" },
                    { 5, "A lightweight tablet perfect for reading and browsing.", "Tablet" },
                    { 6, "A next-gen gaming console for an immersive gaming experience.", "Gaming Console" },
                    { 7, "A high-resolution camera for capturing stunning photos.", "Camera" },
                    { 8, "A portable Bluetooth speaker with excellent sound quality.", "Bluetooth Speaker" },
                    { 9, "A reliable external hard drive for data backup.", "External Hard Drive" },
                    { 10, "A comfortable wireless mouse for everyday use.", "Wireless Mouse" },
                    { 11, "A mechanical keyboard with customizable RGB lighting.", "Keyboard" },
                    { 12, "A high-resolution monitor for work and gaming.", "Monitor" },
                    { 13, "A versatile printer for home and office use.", "Printer" },
                    { 14, "A high-speed router for reliable internet connectivity.", "Router" },
                    { 15, "A smart home hub to control all your smart devices.", "Smart Home Hub" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
