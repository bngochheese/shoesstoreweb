using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStoreWebsite.Data.Migrations
{
    /// <inheritdoc />
    public partial class MG7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URLImage",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLImage",
                table: "Shoes");
        }
    }
}
