using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Data.Migrations
{
    public partial class refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CMSComponents",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Umbraco Heartcore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CMSComponents",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Umbraco heartCore");
        }
    }
}
