using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteThreadsWebApp.Services.Orders.Migrations
{
    /// <inheritdoc />
    public partial class ErrorHandling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaymentError",
                table: "OrderHeaders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentError",
                table: "OrderHeaders");
        }
    }
}
