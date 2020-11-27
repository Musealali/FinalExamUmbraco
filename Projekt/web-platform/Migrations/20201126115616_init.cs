using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMSComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMSComponentVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMSComponentId = table.Column<int>(type: "int", nullable: false),
                    ComponentVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSComponentVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CMSComponentVersions_CMSComponents_CMSComponentId",
                        column: x => x.CMSComponentId,
                        principalTable: "CMSComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CMSComponentVersions_ComponentVersions_ComponentVersionId",
                        column: x => x.ComponentVersionId,
                        principalTable: "ComponentVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecurityIssuePosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueReproduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMSComponentVersionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityIssuePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityIssuePosts_CMSComponentVersions_CMSComponentVersionId",
                        column: x => x.CMSComponentVersionId,
                        principalTable: "CMSComponentVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CMSComponents",
                columns: new[] { "Id", "CType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Forms" },
                    { 2, 1, "uSync" },
                    { 3, 0, "Umbraco UNO" },
                    { 4, 0, "Umbraco Cloud" },
                    { 5, 0, "Umbraco Hearthbreak" },
                    { 6, 0, "Umbraco CMS" }
                });

            migrationBuilder.InsertData(
                table: "ComponentVersions",
                columns: new[] { "Id", "VersionNumber" },
                values: new object[,]
                {
                    { 10, "3.2" },
                    { 9, "3.1" },
                    { 8, "2.4" },
                    { 7, "2.3" },
                    { 6, "2.2" },
                    { 3, "1.3" },
                    { 4, "1.4" },
                    { 11, "3.3" },
                    { 2, "1.2" },
                    { 1, "1.1" },
                    { 5, "2.1" },
                    { 12, "3.4" }
                });

            migrationBuilder.InsertData(
                table: "CMSComponentVersions",
                columns: new[] { "Id", "CMSComponentId", "ComponentVersionId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 22, 2, 11 },
                    { 17, 1, 11 },
                    { 10, 5, 11 },
                    { 7, 4, 10 },
                    { 14, 6, 9 },
                    { 4, 3, 8 },
                    { 13, 6, 7 },
                    { 9, 5, 7 },
                    { 21, 2, 6 },
                    { 6, 4, 6 },
                    { 3, 3, 5 },
                    { 20, 2, 4 },
                    { 12, 6, 3 },
                    { 8, 5, 3 },
                    { 2, 3, 3 },
                    { 16, 1, 2 },
                    { 5, 4, 2 },
                    { 19, 2, 1 },
                    { 15, 1, 1 },
                    { 11, 5, 12 },
                    { 18, 1, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersions_CMSComponentId",
                table: "CMSComponentVersions",
                column: "CMSComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersions_ComponentVersionId",
                table: "CMSComponentVersions",
                column: "ComponentVersionId");

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
                name: "CMSComponentVersions");

            migrationBuilder.DropTable(
                name: "CMSComponents");

            migrationBuilder.DropTable(
                name: "ComponentVersions");
        }
    }
}
