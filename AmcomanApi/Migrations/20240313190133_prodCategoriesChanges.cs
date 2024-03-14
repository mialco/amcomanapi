using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmcomanApi.Migrations
{
    /// <inheritdoc />
    public partial class prodCategoriesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatID",
                table: "AflProducts_Categories");

            migrationBuilder.DropColumn(
                name: "ProdId",
                table: "AflProducts_Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13801147-db74-4a2c-84c7-80a148059b81", null, "User", "USER" },
                    { "27ab5a7e-46b3-4665-90c0-32aec0afade4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13801147-db74-4a2c-84c7-80a148059b81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27ab5a7e-46b3-4665-90c0-32aec0afade4");

            migrationBuilder.AddColumn<int>(
                name: "CatID",
                table: "AflProducts_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdId",
                table: "AflProducts_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
