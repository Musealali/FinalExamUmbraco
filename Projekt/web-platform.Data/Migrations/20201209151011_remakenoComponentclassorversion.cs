using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Data.Migrations
{
    public partial class remakenoComponentclassorversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePosts_CMSComponentVersions_CMSComponentVersionId",
                table: "SecurityIssuePosts");

            migrationBuilder.DropTable(
                name: "CMSComponentVersions");

            migrationBuilder.DropTable(
                name: "CMSComponents");

            migrationBuilder.DropTable(
                name: "ComponentVersions");

            migrationBuilder.DropIndex(
                name: "IX_SecurityIssuePosts_CMSComponentVersionId",
                table: "SecurityIssuePosts");

            migrationBuilder.DropColumn(
                name: "CMSComponentVersionId",
                table: "SecurityIssuePosts");

            migrationBuilder.AddColumn<string>(
                name: "ComponentName",
                table: "SecurityIssuePosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComponentVersion",
                table: "SecurityIssuePosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentName",
                table: "SecurityIssuePosts");

            migrationBuilder.DropColumn(
                name: "ComponentVersion",
                table: "SecurityIssuePosts");

            migrationBuilder.AddColumn<int>(
                name: "CMSComponentVersionId",
                table: "SecurityIssuePosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CMSComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "CMSComponents",
                columns: new[] { "Id", "ComponentType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Forms" },
                    { 2, 1, "uSync" },
                    { 3, 1, "Umbraco UNO" },
                    { 4, 1, "Umbraco Heartcore" },
                    { 5, 0, "Umbraco CMS" }
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
                    { 4, "1.4" },
                    { 11, "3.3" },
                    { 3, "1.3" },
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
                    { 19, 2, 11 },
                    { 14, 1, 11 },
                    { 7, 4, 11 },
                    { 11, 5, 9 },
                    { 4, 3, 8 },
                    { 10, 5, 7 },
                    { 6, 4, 7 },
                    { 8, 4, 12 },
                    { 18, 2, 6 },
                    { 17, 2, 4 },
                    { 9, 5, 3 },
                    { 5, 4, 3 },
                    { 2, 3, 3 },
                    { 13, 1, 2 },
                    { 16, 2, 1 },
                    { 12, 1, 1 },
                    { 3, 3, 5 },
                    { 15, 1, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityIssuePosts_CMSComponentVersionId",
                table: "SecurityIssuePosts",
                column: "CMSComponentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersions_CMSComponentId",
                table: "CMSComponentVersions",
                column: "CMSComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersions_ComponentVersionId",
                table: "CMSComponentVersions",
                column: "ComponentVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePosts_CMSComponentVersions_CMSComponentVersionId",
                table: "SecurityIssuePosts",
                column: "CMSComponentVersionId",
                principalTable: "CMSComponentVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
