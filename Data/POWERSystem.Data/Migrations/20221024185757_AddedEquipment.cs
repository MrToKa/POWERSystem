using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POWERSystem.Data.Migrations
{
    public partial class AddedEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cables_Enclosure_EnclosureId",
                table: "Cables");

            migrationBuilder.DropForeignKey(
                name: "FK_Enclosure_Projects_ProjectId",
                table: "Enclosure");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Storages_StorageId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_StorageId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Parts");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Enclosure",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnclosureId",
                table: "CablesOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnclosureId",
                table: "Cables",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartStorage",
                columns: table => new
                {
                    PartsId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartStorage", x => new { x.PartsId, x.StorageId });
                    table.ForeignKey(
                        name: "FK_PartStorage_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartStorage_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CablesOrders_EnclosureId",
                table: "CablesOrders",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_IsDeleted",
                table: "Equipment",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_StorageId",
                table: "Equipment",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_PartStorage_StorageId",
                table: "PartStorage",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cables_Enclosure_EnclosureId",
                table: "Cables",
                column: "EnclosureId",
                principalTable: "Enclosure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CablesOrders_Enclosure_EnclosureId",
                table: "CablesOrders",
                column: "EnclosureId",
                principalTable: "Enclosure",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enclosure_Projects_ProjectId",
                table: "Enclosure",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cables_Enclosure_EnclosureId",
                table: "Cables");

            migrationBuilder.DropForeignKey(
                name: "FK_CablesOrders_Enclosure_EnclosureId",
                table: "CablesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Enclosure_Projects_ProjectId",
                table: "Enclosure");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "PartStorage");

            migrationBuilder.DropIndex(
                name: "IX_CablesOrders_EnclosureId",
                table: "CablesOrders");

            migrationBuilder.DropColumn(
                name: "EnclosureId",
                table: "CablesOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "StorageId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Enclosure",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EnclosureId",
                table: "Cables",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_StorageId",
                table: "Parts",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cables_Enclosure_EnclosureId",
                table: "Cables",
                column: "EnclosureId",
                principalTable: "Enclosure",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enclosure_Projects_ProjectId",
                table: "Enclosure",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Storages_StorageId",
                table: "Parts",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id");
        }
    }
}
