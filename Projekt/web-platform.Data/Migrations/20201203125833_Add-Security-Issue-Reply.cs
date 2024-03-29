﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Data.Migrations
{
    public partial class AddSecurityIssueReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityIssuePostReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SecurityIssuePostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityIssuePostReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityIssuePostReplies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecurityIssuePostReplies_SecurityIssuePosts_SecurityIssuePostId",
                        column: x => x.SecurityIssuePostId,
                        principalTable: "SecurityIssuePosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityIssuePostReplies_ApplicationUserId",
                table: "SecurityIssuePostReplies",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityIssuePostReplies_SecurityIssuePostId",
                table: "SecurityIssuePostReplies",
                column: "SecurityIssuePostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityIssuePostReplies");
        }
    }
}
