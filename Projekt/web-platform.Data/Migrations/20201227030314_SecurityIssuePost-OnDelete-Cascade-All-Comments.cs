using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Data.Migrations
{
    public partial class SecurityIssuePostOnDeleteCascadeAllComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePostReplies_SecurityIssuePosts_SecurityIssuePostId",
                table: "SecurityIssuePostReplies");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePostReplies_SecurityIssuePosts_SecurityIssuePostId",
                table: "SecurityIssuePostReplies",
                column: "SecurityIssuePostId",
                principalTable: "SecurityIssuePosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePostReplies_SecurityIssuePosts_SecurityIssuePostId",
                table: "SecurityIssuePostReplies");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePostReplies_SecurityIssuePosts_SecurityIssuePostId",
                table: "SecurityIssuePostReplies",
                column: "SecurityIssuePostId",
                principalTable: "SecurityIssuePosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
