using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMSComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMSComponentVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMSComponentId = table.Column<int>(type: "int", nullable: true),
                    VersionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSComponentVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMSComponentVersion_CMSComponent_CMSComponentId",
                        column: x => x.CMSComponentId,
                        principalTable: "CMSComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CMSComponentVersion_ComponentVersion_VersionId",
                        column: x => x.VersionId,
                        principalTable: "ComponentVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecurityIssuePosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueReproduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMSComponentVersionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityIssuePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityIssuePosts_CMSComponentVersion_CMSComponentVersionId",
                        column: x => x.CMSComponentVersionId,
                        principalTable: "CMSComponentVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersion_CMSComponentId",
                table: "CMSComponentVersion",
                column: "CMSComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersion_VersionId",
                table: "CMSComponentVersion",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityIssuePosts_CMSComponentVersionId",
                table: "SecurityIssuePosts",
                column: "CMSComponentVersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityIssuePosts");

            migrationBuilder.DropTable(
                name: "CMSComponentVersion");

            migrationBuilder.DropTable(
                name: "CMSComponent");

            migrationBuilder.DropTable(
                name: "ComponentVersion");
        }
    }
}
