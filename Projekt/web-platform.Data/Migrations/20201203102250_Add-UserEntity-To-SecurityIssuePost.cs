using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Data.Migrations
{
    public partial class AddUserEntityToSecurityIssuePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SecurityIssuePosts",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityIssuePosts_ApplicationUserId",
                table: "SecurityIssuePosts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePosts_AspNetUsers_ApplicationUserId",
                table: "SecurityIssuePosts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePosts_AspNetUsers_ApplicationUserId",
                table: "SecurityIssuePosts");

            migrationBuilder.DropIndex(
                name: "IX_SecurityIssuePosts_ApplicationUserId",
                table: "SecurityIssuePosts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SecurityIssuePosts");
        }
    }
}
