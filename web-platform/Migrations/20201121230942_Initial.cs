using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CMS",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMS", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SecurityIssuePost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueReproduction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityIssuePost", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMS");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "SecurityIssuePost");
        }
    }
}
