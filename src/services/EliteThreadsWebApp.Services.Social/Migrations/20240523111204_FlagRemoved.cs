using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteThreadsWebApp.Services.Social.Migrations
{
    /// <inheritdoc />
    public partial class FlagRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductRated",
                table: "UserRatings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProductRated",
                table: "UserRatings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
