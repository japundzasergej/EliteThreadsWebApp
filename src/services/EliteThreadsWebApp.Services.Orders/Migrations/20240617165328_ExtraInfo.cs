using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteThreadsWebApp.Services.Orders.Migrations
{
    /// <inheritdoc />
    public partial class ExtraInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OrderHeaders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)"
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrderHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.CreateTable(
                name: "PersonalInfos",
                columns: table =>
                    new
                    {
                        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfos", x => x.UserId);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_UserId",
                table: "OrderHeaders",
                column: "UserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_PersonalInfos_UserId",
                table: "OrderHeaders",
                column: "UserId",
                principalTable: "PersonalInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_PersonalInfos_UserId",
                table: "OrderHeaders"
            );

            migrationBuilder.DropTable(name: "PersonalInfos");

            migrationBuilder.DropIndex(name: "IX_OrderHeaders_UserId", table: "OrderHeaders");

            migrationBuilder.DropColumn(name: "DateCreated", table: "OrderHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)"
            );
        }
    }
}
