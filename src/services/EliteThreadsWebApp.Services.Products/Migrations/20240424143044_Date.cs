using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EliteThreadsWebApp.Services.Products.Migrations
{
    /// <inheritdoc />
    public partial class Date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatedDate",
                table: "Reviews",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2"
            );

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Clothing" },
                    { 2, "Accessories" },
                    { 3, "Shoes" }
                }
            );

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "SubcategoryId", "CategoryId", "SubcategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Suits" },
                    { 2, 1, "Tuxedos" },
                    { 3, 1, "Blazers" },
                    { 4, 1, "Dress Shirts" },
                    { 5, 1, "Casual Shirts" },
                    { 6, 1, "Polo Shirts" },
                    { 7, 1, "Overshirts" },
                    { 8, 1, "Waistcoats" },
                    { 9, 1, "Knitwear" },
                    { 10, 1, "Jeans" },
                    { 11, 1, "Trousers" },
                    { 12, 1, "Outerwear" },
                    { 13, 1, "Sweatshirts and Joggers" },
                    { 14, 1, "Polo T-Shirts" },
                    { 15, 1, "Bermuda" },
                    { 16, 1, "Underwear and Pajamas" },
                    { 17, 1, "Swim Shorts" },
                    { 18, 2, "Ties" },
                    { 19, 2, "Pocket Squares" },
                    { 20, 2, "Socks" },
                    { 21, 2, "Belts" },
                    { 22, 2, "Hats" },
                    { 23, 2, "Bow Ties" },
                    { 24, 2, "Cummerbunds" },
                    { 25, 2, "Cufflinks" },
                    { 26, 2, "Braces" },
                    { 27, 2, "Rucksacks and Suitcases" },
                    { 28, 2, "Sunglasses" },
                    { 29, 2, "Small Leather Goods" },
                    { 30, 2, "Beach Towels" },
                    { 31, 3, "Sneakers" },
                    { 32, 3, "Loafers" },
                    { 33, 3, "Classic" },
                    { 34, 3, "Flip Flops" }
                }
            );
        }
    }
}
