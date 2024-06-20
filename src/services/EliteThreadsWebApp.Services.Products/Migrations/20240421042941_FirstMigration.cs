using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EliteThreadsWebApp.Services.Products.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table =>
                    new
                    {
                        CategoryId = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                }
            );

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table =>
                    new
                    {
                        SubcategoryId = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        SubcategoryName = table.Column<string>(
                            type: "nvarchar(max)",
                            nullable: false
                        ),
                        CategoryId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.SubcategoryId);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table =>
                    new
                    {
                        ProductId = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        ProductDescription = table.Column<string>(
                            type: "nvarchar(max)",
                            nullable: false
                        ),
                        Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Compositions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Fabric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Pattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        SubcategoryId = table.Column<int>(type: "int", nullable: false),
                        Price = table.Column<double>(type: "float", nullable: false),
                        Rating = table.Column<float>(type: "real", nullable: false),
                        New = table.Column<bool>(type: "bit", nullable: false),
                        MustHave = table.Column<bool>(type: "bit", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "SubcategoryId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table =>
                    new
                    {
                        ReviewId = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                        ProductId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
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

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                column: "SubcategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Reviews");

            migrationBuilder.DropTable(name: "Products");

            migrationBuilder.DropTable(name: "Subcategories");

            migrationBuilder.DropTable(name: "Categories");
        }
    }
}
