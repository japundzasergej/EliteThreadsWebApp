using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteThreadsWebApp.Services.ShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class CartDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedColor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SelectedSize",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "SelectedColor",
                table: "CartDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SelectedSize",
                table: "CartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedColor",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "SelectedSize",
                table: "CartDetails");

            migrationBuilder.AddColumn<string>(
                name: "SelectedColor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SelectedSize",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
