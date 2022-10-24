using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POWERSystem.Data.Migrations
{
    public partial class AddedStorages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StorageId",
                table: "PartsOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StorageId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StorageId",
                table: "CablesOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StorageId",
                table: "Cables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrders_StorageId",
                table: "PartsOrders",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_StorageId",
                table: "Parts",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_CablesOrders_StorageId",
                table: "CablesOrders",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cables_StorageId",
                table: "Cables",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ProjectId",
                table: "Storages",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cables_Storages_StorageId",
                table: "Cables",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CablesOrders_Storages_StorageId",
                table: "CablesOrders",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Storages_StorageId",
                table: "Parts",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PartsOrders_Storages_StorageId",
                table: "PartsOrders",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cables_Storages_StorageId",
                table: "Cables");

            migrationBuilder.DropForeignKey(
                name: "FK_CablesOrders_Storages_StorageId",
                table: "CablesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Storages_StorageId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_PartsOrders_Storages_StorageId",
                table: "PartsOrders");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropIndex(
                name: "IX_PartsOrders_StorageId",
                table: "PartsOrders");

            migrationBuilder.DropIndex(
                name: "IX_Parts_StorageId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_CablesOrders_StorageId",
                table: "CablesOrders");

            migrationBuilder.DropIndex(
                name: "IX_Cables_StorageId",
                table: "Cables");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "PartsOrders");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "CablesOrders");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Cables");
        }
    }
}
