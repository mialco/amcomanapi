using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmcomanApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AflProducts",
                schema: "Afl",
                newName: "AflProducts");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryImgAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryImgDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryAdditionalInfoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryAdditionalInfoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryRecordStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryLinkCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryAdvertiser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryAdvertiserLinkID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryIsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AflProducts_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdId = table.Column<int>(type: "int", nullable: false),
                    CatID = table.Column<int>(type: "int", nullable: false),
                    AflProductId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AflProducts_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AflProducts_Categories_AflProducts_AflProductId",
                        column: x => x.AflProductId,
                        principalTable: "AflProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AflProducts_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AflProducts_Categories_AflProductId",
                table: "AflProducts_Categories",
                column: "AflProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AflProducts_Categories_CategoryId",
                table: "AflProducts_Categories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AflProducts_Categories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.EnsureSchema(
                name: "Afl");

            migrationBuilder.RenameTable(
                name: "AflProducts",
                newName: "AflProducts",
                newSchema: "Afl");
        }
    }
}
