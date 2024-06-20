using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteThreadsWebApp.Services.Orders.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderProducts_OrderProductProductId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderProductProductId",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderProductProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderProducts_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "OrderProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderProducts_ProductId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetails",
                newName: "OrderProductProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderProducts_OrderProductProductId",
                table: "OrderDetails",
                column: "OrderProductProductId",
                principalTable: "OrderProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
