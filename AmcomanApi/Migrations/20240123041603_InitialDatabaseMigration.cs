using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmcomanApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Afl");

            migrationBuilder.CreateTable(
                name: "AflProducts",
                schema: "Afl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advertiser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    AdvertizerLinkID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AflProducts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AflProducts",
                schema: "Afl");
        }
    }
}
