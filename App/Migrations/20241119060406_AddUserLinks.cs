using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cyclist",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cook",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cyclist_UserId",
                table: "Cyclist",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cook_UserId",
                table: "Cook",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cook_AspNetUsers_UserId",
                table: "Cook",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cyclist_AspNetUsers_UserId",
                table: "Cyclist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cook_AspNetUsers_UserId",
                table: "Cook");

            migrationBuilder.DropForeignKey(
                name: "FK_Cyclist_AspNetUsers_UserId",
                table: "Cyclist");

            migrationBuilder.DropIndex(
                name: "IX_Cyclist_UserId",
                table: "Cyclist");

            migrationBuilder.DropIndex(
                name: "IX_Cook_UserId",
                table: "Cook");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cyclist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cook");
        }
    }
}
