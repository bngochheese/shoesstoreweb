using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStoreWebsite.Data.Migrations
{
    /// <inheritdoc />
    public partial class MG5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Shoes");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sole",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Storagen_Instructions",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "Sole",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "Storagen_Instructions",
                table: "Shoes");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Shoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
