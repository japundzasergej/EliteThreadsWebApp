using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EliteThreadsWebApp.Services.Promotions.Migrations
{
    /// <inheritdoc />
    public partial class SetNullDeleteBehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Collections_CollectionId",
                table: "Products"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Collections_CollectionId",
                table: "Products",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.SetNull
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.SetNull
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Collections_CollectionId",
                table: "Products"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products"
            );

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "DiscountId", "DiscountAmount", "DiscountName" },
                values: new object[,]
                {
                    { 1, 30, "30% OFF" },
                    { 2, 20, "20% OFF" },
                    { 3, 10, "10% OFF" }
                }
            );

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "PromotionId", "Message" },
                values: new object[,]
                {
                    { 1, "MID SEASON SALE: up to -30% with free delivery for all orders" },
                    { 2, "FREE SHIPPING ON ORDERS OVER 80€" }
                }
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Collections_CollectionId",
                table: "Products",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "DiscountId"
            );
        }
    }
}
