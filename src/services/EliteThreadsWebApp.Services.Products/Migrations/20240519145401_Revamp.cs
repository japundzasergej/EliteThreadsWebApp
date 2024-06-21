using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteThreadsWebApp.Services.Products.Migrations
{
    /// <inheritdoc />
    public partial class Revamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Reviews");

            migrationBuilder.DropColumn(name: "FiveStarRating", table: "Products");

            migrationBuilder.DropColumn(name: "FourStarRating", table: "Products");

            migrationBuilder.DropColumn(name: "OneStarRating", table: "Products");

            migrationBuilder.DropColumn(name: "Rating", table: "Products");

            migrationBuilder.DropColumn(name: "ThreeStarRating", table: "Products");

            migrationBuilder.DropColumn(name: "TotalRatingCount", table: "Products");

            migrationBuilder.DropColumn(name: "TotalRatingSum", table: "Products");

            migrationBuilder.RenameColumn(
                name: "TwoStarRating",
                table: "Products",
                newName: "ProductsLeft"
            );

            migrationBuilder.AddColumn<bool>(
                name: "IsInStock",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "IsInStock", table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductsLeft",
                table: "Products",
                newName: "TwoStarRating"
            );

            migrationBuilder.AddColumn<int>(
                name: "FiveStarRating",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "FourStarRating",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "OneStarRating",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f
            );

            migrationBuilder.AddColumn<int>(
                name: "ThreeStarRating",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "TotalRatingCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<float>(
                name: "TotalRatingSum",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f
            );

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table =>
                    new
                    {
                        ReviewId = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        ProductId = table.Column<int>(type: "int", nullable: false),
                        CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId"
            );
        }
    }
}
