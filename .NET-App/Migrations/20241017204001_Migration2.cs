using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Removing "CPR" from Cook table 

            migrationBuilder.DropColumn(
                name: "CPR",
                table: "Cook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Adding "CPR" to Cook table 

            migrationBuilder.AddColumn<string>(
                name: "CPR",
                table: "Cook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
