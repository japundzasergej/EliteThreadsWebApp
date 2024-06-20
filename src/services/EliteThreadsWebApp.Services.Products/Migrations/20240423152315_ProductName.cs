using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteThreadsWebApp.Services.Products.Migrations
{
    /// <inheritdoc />
    public partial class ProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");
        }
    }
}
