using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POWERSystem.Data.Migrations
{
    public partial class AddedOrdersAndCablesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Parts",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "Delivery",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PartOrderId",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CablesOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnclosureId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CablesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CablesOrders_Enclosure_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosure",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CablesOrders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartsOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnclosureId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsOrders_Enclosure_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosure",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartsOrders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Conductors = table.Column<int>(type: "int", nullable: false),
                    CrossSection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voltage = table.Column<int>(type: "int", nullable: false),
                    Routing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignLength = table.Column<int>(type: "int", nullable: false),
                    InstallLength = table.Column<int>(type: "int", nullable: true),
                    PullDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConnectedFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConnectedTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnclosureId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangeDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CableOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cables_CablesOrders_CableOrderId",
                        column: x => x.CableOrderId,
                        principalTable: "CablesOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cables_Enclosure_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosure",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartOrderId",
                table: "Parts",
                column: "PartOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cables_CableOrderId",
                table: "Cables",
                column: "CableOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cables_EnclosureId",
                table: "Cables",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Cables_IsDeleted",
                table: "Cables",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CablesOrders_EnclosureId",
                table: "CablesOrders",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_CablesOrders_IsDeleted",
                table: "CablesOrders",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CablesOrders_ProjectId",
                table: "CablesOrders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrders_EnclosureId",
                table: "PartsOrders",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrders_IsDeleted",
                table: "PartsOrders",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrders_ProjectId",
                table: "PartsOrders",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartsOrders_PartOrderId",
                table: "Parts",
                column: "PartOrderId",
                principalTable: "PartsOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartsOrders_PartOrderId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "Cables");

            migrationBuilder.DropTable(
                name: "PartsOrders");

            migrationBuilder.DropTable(
                name: "CablesOrders");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartOrderId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "PartOrderId",
                table: "Parts");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Parts",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);
        }
    }
}
