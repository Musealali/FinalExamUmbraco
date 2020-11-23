using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class ModifiedDatabaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CMSComponent",
                keyColumn: "Id",
                keyValue: 1,
                column: "Version",
                value: "8.9.1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CMSComponent",
                keyColumn: "Id",
                keyValue: 1,
                column: "Version",
                value: "V8.9.1");
        }
    }
}
