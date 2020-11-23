using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class DatabaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId1",
                table: "SecurityIssuePost");

            migrationBuilder.DropIndex(
                name: "IX_SecurityIssuePost_CMSComponentId1",
                table: "SecurityIssuePost");

            migrationBuilder.DropColumn(
                name: "CMSComponentId1",
                table: "SecurityIssuePost");

            migrationBuilder.AlterColumn<int>(
                name: "CMSComponentId",
                table: "SecurityIssuePost",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CMSComponent",
                columns: new[] { "Id", "Discriminator", "Name", "Version" },
                values: new object[] { 1, "CMS", "CMS", "V8.9.1" });

            migrationBuilder.InsertData(
                table: "CMSComponent",
                columns: new[] { "Id", "Discriminator", "Name", "Version" },
                values: new object[] { 2, "Package", "Forms", "8.6.9" });

            migrationBuilder.InsertData(
                table: "CMSComponent",
                columns: new[] { "Id", "Discriminator", "Name", "Version" },
                values: new object[] { 3, "Package", "uSync", "6.2.1" });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityIssuePost_CMSComponentId",
                table: "SecurityIssuePost",
                column: "CMSComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId",
                table: "SecurityIssuePost",
                column: "CMSComponentId",
                principalTable: "CMSComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId",
                table: "SecurityIssuePost");

            migrationBuilder.DropIndex(
                name: "IX_SecurityIssuePost_CMSComponentId",
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

            migrationBuilder.AlterColumn<string>(
                name: "CMSComponentId",
                table: "SecurityIssuePost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CMSComponentId1",
                table: "SecurityIssuePost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityIssuePost_CMSComponentId1",
                table: "SecurityIssuePost",
                column: "CMSComponentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId1",
                table: "SecurityIssuePost",
                column: "CMSComponentId1",
                principalTable: "CMSComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
