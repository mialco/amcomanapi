using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmcomanApi.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAlteredApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Custom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Custom",
                table: "AspNetUsers");
        }
    }
}
