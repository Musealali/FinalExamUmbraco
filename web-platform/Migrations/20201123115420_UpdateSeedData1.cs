using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class UpdateSeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMS");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropColumn(
                name: "CMSComponent_Name",
                table: "CMSComponentVersion");

            migrationBuilder.CreateTable(
                name: "CMSComponents",
                columns: table => new
                {
                    CMSComponentVersionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMSComponents", x => x.CMSComponentVersionId);
                    table.ForeignKey(
                        name: "FK_CMSComponents_CMSComponentVersion_CMSComponentVersionId",
                        column: x => x.CMSComponentVersionId,
                        principalTable: "CMSComponentVersion",
                        principalColumn: "CMSComponentVersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CMSComponents",
                columns: new[] { "CMSComponentVersionId", "Name" },
                values: new object[] { 1, "Umbraco CMS" });

            migrationBuilder.InsertData(
                table: "CMSComponents",
                columns: new[] { "CMSComponentVersionId", "Name" },
                values: new object[] { 2, "Umbraco CMS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMSComponents");

            migrationBuilder.AddColumn<string>(
                name: "CMSComponent_Name",
                table: "CMSComponentVersion",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "Package",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageId);
                });

            migrationBuilder.UpdateData(
                table: "CMSComponentVersion",
                keyColumn: "CMSComponentVersionId",
                keyValue: 1,
                column: "CMSComponent_Name",
                value: "Umbraco CMS");

            migrationBuilder.UpdateData(
                table: "CMSComponentVersion",
                keyColumn: "CMSComponentVersionId",
                keyValue: 2,
                column: "CMSComponent_Name",
                value: "Umbraco CMS");
        }
    }
}
