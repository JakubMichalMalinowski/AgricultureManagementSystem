using Microsoft.EntityFrameworkCore.Migrations;

namespace AgricultureManagementSystem.Data.Migrations
{
    public partial class AddIEngineToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelCapacity",
                table: "Combines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "Combines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "Combines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelCapacity",
                table: "Combines");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Combines");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Combines");
        }
    }
}
