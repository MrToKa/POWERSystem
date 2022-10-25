using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POWERSystem.Data.Migrations
{
    public partial class SiteServicesAddedToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteServices_Projects_ProjectId",
                table: "SiteServices");

            migrationBuilder.DropIndex(
                name: "IX_SiteServices_ProjectId",
                table: "SiteServices");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "SiteServices");

            migrationBuilder.CreateTable(
                name: "ProjectSiteService",
                columns: table => new
                {
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SiteServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSiteService", x => new { x.ProjectsId, x.SiteServicesId });
                    table.ForeignKey(
                        name: "FK_ProjectSiteService_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectSiteService_SiteServices_SiteServicesId",
                        column: x => x.SiteServicesId,
                        principalTable: "SiteServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSiteService_SiteServicesId",
                table: "ProjectSiteService",
                column: "SiteServicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSiteService");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "SiteServices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SiteServices_ProjectId",
                table: "SiteServices",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteServices_Projects_ProjectId",
                table: "SiteServices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
