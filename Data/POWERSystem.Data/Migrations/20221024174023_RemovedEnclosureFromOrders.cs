using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POWERSystem.Data.Migrations
{
    public partial class RemovedEnclosureFromOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CablesOrders_Enclosure_EnclosureId",
                table: "CablesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PartsOrders_Enclosure_EnclosureId",
                table: "PartsOrders");

            migrationBuilder.DropIndex(
                name: "IX_PartsOrders_EnclosureId",
                table: "PartsOrders");

            migrationBuilder.DropIndex(
                name: "IX_CablesOrders_EnclosureId",
                table: "CablesOrders");

            migrationBuilder.DropColumn(
                name: "EnclosureId",
                table: "PartsOrders");

            migrationBuilder.DropColumn(
                name: "EnclosureId",
                table: "CablesOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnclosureId",
                table: "PartsOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnclosureId",
                table: "CablesOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrders_EnclosureId",
                table: "PartsOrders",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_CablesOrders_EnclosureId",
                table: "CablesOrders",
                column: "EnclosureId");

            migrationBuilder.AddForeignKey(
                name: "FK_CablesOrders_Enclosure_EnclosureId",
                table: "CablesOrders",
                column: "EnclosureId",
                principalTable: "Enclosure",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PartsOrders_Enclosure_EnclosureId",
                table: "PartsOrders",
                column: "EnclosureId",
                principalTable: "Enclosure",
                principalColumn: "Id");
        }
    }
}
