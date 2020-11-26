using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId",
                table: "SecurityIssuePost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CMSComponent",
                table: "CMSComponent");

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
                name: "Discriminator",
                table: "CMSComponent");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "CMSComponent");

            migrationBuilder.RenameTable(
                name: "CMSComponent",
                newName: "Package");

            migrationBuilder.RenameColumn(
                name: "CMSComponentId",
                table: "SecurityIssuePost",
                newName: "CMSComponentVersionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SecurityIssuePost",
                newName: "SecurityIssuePostId");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityIssuePost_CMSComponentId",
                table: "SecurityIssuePost",
                newName: "IX_SecurityIssuePost_CMSComponentVersionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Package",
                newName: "PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "PackageId");

            migrationBuilder.CreateTable(
                name: "CMS",
                columns: table => new
                {
                    CMSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS", x => x.CMSId);
                });

            migrationBuilder.CreateTable(
                name: "CMSComponentVersion",
                columns: table => new
                {
                    CMSComponentVersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMSComponent_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSComponentVersion", x => x.CMSComponentVersionId);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    VersionNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CMSComponentVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.VersionNumber);
                    table.ForeignKey(
                        name: "FK_Versions_CMSComponentVersion_CMSComponentVersionId",
                        column: x => x.CMSComponentVersionId,
                        principalTable: "CMSComponentVersion",
                        principalColumn: "CMSComponentVersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CMSComponentVersion",
                columns: new[] { "CMSComponentVersionId", "CMSComponent_Name" },
                values: new object[] { 1, "Umbraco CMS" });

            migrationBuilder.InsertData(
                table: "CMSComponentVersion",
                columns: new[] { "CMSComponentVersionId", "CMSComponent_Name" },
                values: new object[] { 2, "Umbraco CMS" });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "VersionNumber", "CMSComponentVersionId" },
                values: new object[] { "1.1", 1 });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "VersionNumber", "CMSComponentVersionId" },
                values: new object[] { "1.2", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Versions_CMSComponentVersionId",
                table: "Versions",
                column: "CMSComponentVersionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePost_CMSComponentVersion_CMSComponentVersionId",
                table: "SecurityIssuePost",
                column: "CMSComponentVersionId",
                principalTable: "CMSComponentVersion",
                principalColumn: "CMSComponentVersionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePost_CMSComponentVersion_CMSComponentVersionId",
                table: "SecurityIssuePost");

            migrationBuilder.DropTable(
                name: "CMS");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "CMSComponentVersion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "CMSComponent");

            migrationBuilder.RenameColumn(
                name: "CMSComponentVersionId",
                table: "SecurityIssuePost",
                newName: "CMSComponentId");

            migrationBuilder.RenameColumn(
                name: "SecurityIssuePostId",
                table: "SecurityIssuePost",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityIssuePost_CMSComponentVersionId",
                table: "SecurityIssuePost",
                newName: "IX_SecurityIssuePost_CMSComponentId");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "CMSComponent",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CMSComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "CMSComponent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CMSComponent",
                table: "CMSComponent",
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
