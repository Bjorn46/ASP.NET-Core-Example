using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // adding "HasPassedFoodSafetyCourse" to Cook table 
            migrationBuilder.AddColumn<bool>(
                name: "HasPassedFoodSafetyCourse",
                table: "Cook",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Dropping migration changes 
            migrationBuilder.DropColumn(
                name: "HasPassedFoodSafetyCourse",
                table: "Cook");
        }
    }
}
