using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PantryClub.Services.Users.Migrations
{
    /// <inheritdoc />
    public partial class InitialUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("00ea5b3e-307c-421d-9a34-670a25d03829"), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "anesu@gmail.com", "Anesu", "Mutumwa" },
                    { new Guid("4a8321c1-c147-490c-ac3a-401a81df6c5b"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "angel@gmail.com", "Angel", "Mutumwa" },
                    { new Guid("94097710-8742-4f61-bf80-3a93a66f7493"), new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tendai@gmail.com", "Tendai", "Mutumwa" },
                    { new Guid("f5b4a916-13ee-4f91-8e64-482db5ec47e8"), new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "arielle@gmail.com", "Arielle", "Mutumwa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
