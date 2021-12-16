using Microsoft.EntityFrameworkCore.Migrations;

namespace AgricultureManagementSystem.Data.Migrations
{
    public partial class ChangeDateToDateTimeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Service",
                newName: "DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Service",
                newName: "Date");
        }
    }
}
