using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PantryClub.Services.Orders.Migrations
{
    /// <inheritdoc />
    public partial class InitialOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Price", "ProductName", "Quantity", "UserId" },
                values: new object[,]
                {
                    { new Guid("3b766af9-37f9-446f-bd7f-f1fe87bb3b8c"), 11m, "Avocado", 8, new Guid("9f9868f0-ae85-4932-a735-ac8bd34ec9ac") },
                    { new Guid("99400f3f-0deb-4d9e-bf4f-401d1988bfb9"), 15m, "Apple", 9, new Guid("99b6c24c-0f37-4474-86ed-7e0611a0be83") },
                    { new Guid("a5b95104-4e75-4e7e-a01b-1b78409dcab0"), 19m, "Grape", 6, new Guid("9b7cf18a-320c-4a71-8337-54558e2c7253") },
                    { new Guid("f44235ab-935a-4f51-bfd5-8fea7ddd0f39"), 17m, "Orange", 4, new Guid("a5f799fe-1850-43f9-ad96-41454309a3ad") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
