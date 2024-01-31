﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmcomanApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryGroup_DateTimeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryIsActive",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AflProducts_Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "AflProducts_Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AflProducts_Categories");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "AflProducts_Categories");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Categories",
                newName: "CategoryIsActive");
        }
    }
}
