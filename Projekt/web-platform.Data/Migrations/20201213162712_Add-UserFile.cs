using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Data.Migrations
{
    public partial class AddUserFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityIssuePostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFiles_SecurityIssuePosts_SecurityIssuePostId",
                        column: x => x.SecurityIssuePostId,
                        principalTable: "SecurityIssuePosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFiles_SecurityIssuePostId",
                table: "UserFiles",
                column: "SecurityIssuePostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFiles");
        }
    }
}
