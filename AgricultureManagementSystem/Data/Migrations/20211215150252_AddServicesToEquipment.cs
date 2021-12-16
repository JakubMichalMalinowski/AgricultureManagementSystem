using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgricultureManagementSystem.Data.Migrations
{
    public partial class AddServicesToEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CombineId = table.Column<int>(type: "int", nullable: true),
                    HeaderId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    TractorId = table.Column<int>(type: "int", nullable: true),
                    TrailerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Combines_CombineId",
                        column: x => x.CombineId,
                        principalTable: "Combines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Header_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "Header",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Tractors_TractorId",
                        column: x => x.TractorId,
                        principalTable: "Tractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_CombineId",
                table: "Service",
                column: "CombineId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_HeaderId",
                table: "Service",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_MachineId",
                table: "Service",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_TractorId",
                table: "Service",
                column: "TractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_TrailerId",
                table: "Service",
                column: "TrailerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
