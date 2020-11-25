using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class blabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId",
                table: "SecurityIssuePost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityIssuePost",
                table: "SecurityIssuePost");

            migrationBuilder.DeleteData(
                table: "CMSComponent",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CMSComponent",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CMSComponent",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Version",
                table: "CMSComponent");

            migrationBuilder.RenameTable(
                name: "SecurityIssuePost",
                newName: "SecurityIssuePosts");

            migrationBuilder.RenameColumn(
                name: "CMSComponentId",
                table: "SecurityIssuePosts",
                newName: "CMSComponentVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityIssuePost_CMSComponentId",
                table: "SecurityIssuePosts",
                newName: "IX_SecurityIssuePosts_CMSComponentVersionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityIssuePosts",
                table: "SecurityIssuePosts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Version",
                columns: table => new
                {
                    VersionNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Version", x => x.VersionNumber);
                });

            migrationBuilder.CreateTable(
                name: "CMSComponentVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMSComponentId = table.Column<int>(type: "int", nullable: true),
                    VersionNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_CMSComponentVersion_Version_VersionNumber",
                        column: x => x.VersionNumber,
                        principalTable: "Version",
                        principalColumn: "VersionNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersion_CMSComponentId",
                table: "CMSComponentVersion",
                column: "CMSComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_CMSComponentVersion_VersionNumber",
                table: "CMSComponentVersion",
                column: "VersionNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePosts_CMSComponentVersion_CMSComponentVersionId",
                table: "SecurityIssuePosts",
                column: "CMSComponentVersionId",
                principalTable: "CMSComponentVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePosts_CMSComponentVersion_CMSComponentVersionId",
                table: "SecurityIssuePosts");

            migrationBuilder.DropTable(
                name: "CMSComponentVersion");

            migrationBuilder.DropTable(
                name: "Version");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityIssuePosts",
                table: "SecurityIssuePosts");

            migrationBuilder.RenameTable(
                name: "SecurityIssuePosts",
                newName: "SecurityIssuePost");

            migrationBuilder.RenameColumn(
                name: "CMSComponentVersionId",
                table: "SecurityIssuePost",
                newName: "CMSComponentId");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityIssuePosts_CMSComponentVersionId",
                table: "SecurityIssuePost",
                newName: "IX_SecurityIssuePost_CMSComponentId");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "CMSComponent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityIssuePost",
                table: "SecurityIssuePost",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CMSComponent",
                columns: new[] { "Id", "Discriminator", "Name", "Version" },
                values: new object[] { 1, "CMS", "CMS", "8.9.1" });

            migrationBuilder.InsertData(
                table: "CMSComponent",
                columns: new[] { "Id", "Discriminator", "Name", "Version" },
                values: new object[] { 2, "Package", "Forms", "8.6.9" });

            migrationBuilder.InsertData(
                table: "CMSComponent",
                columns: new[] { "Id", "Discriminator", "Name", "Version" },
                values: new object[] { 3, "Package", "uSync", "6.2.1" });

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId",
                table: "SecurityIssuePost",
                column: "CMSComponentId",
                principalTable: "CMSComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
