using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmcomanApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryGroupIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CategoryGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CategoryGroups");
        }
    }
}
