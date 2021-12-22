using Microsoft.EntityFrameworkCore.Migrations;

namespace AgricultureManagementSystem.Data.Migrations
{
    public partial class AllowNullRecipientSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TransferIn",
                table: "Transfers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferIn",
                table: "Transfers");
        }
    }
}
