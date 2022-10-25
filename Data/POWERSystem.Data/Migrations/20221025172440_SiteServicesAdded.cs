using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POWERSystem.Data.Migrations
{
    public partial class SiteServicesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteServiceId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteServiceId",
                table: "Cables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SiteServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RequestedFrom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequiredTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteServices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_SiteServiceId",
                table: "Parts",
                column: "SiteServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cables_SiteServiceId",
                table: "Cables",
                column: "SiteServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteServices_ProjectId",
                table: "SiteServices",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cables_SiteServices_SiteServiceId",
                table: "Cables",
                column: "SiteServiceId",
                principalTable: "SiteServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_SiteServices_SiteServiceId",
                table: "Parts",
                column: "SiteServiceId",
                principalTable: "SiteServices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cables_SiteServices_SiteServiceId",
                table: "Cables");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_SiteServices_SiteServiceId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "SiteServices");

            migrationBuilder.DropIndex(
                name: "IX_Parts_SiteServiceId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Cables_SiteServiceId",
                table: "Cables");

            migrationBuilder.DropColumn(
                name: "SiteServiceId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "SiteServiceId",
                table: "Cables");
        }
    }
}
