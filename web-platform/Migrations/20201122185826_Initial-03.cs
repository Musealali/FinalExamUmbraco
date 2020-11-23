using Microsoft.EntityFrameworkCore.Migrations;

namespace web_platform.Migrations
{
    public partial class Initial03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "CMSComponent");

            migrationBuilder.AddColumn<string>(
                name: "CMSComponentId",
                table: "SecurityIssuePost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CMSComponentId1",
                table: "SecurityIssuePost",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CMSComponent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CMSComponent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CMSComponent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CMSComponent",
                table: "CMSComponent",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityIssuePost_CMSComponent_CMSComponentId1",
                table: "SecurityIssuePost");

            migrationBuilder.DropIndex(
                name: "IX_SecurityIssuePost_CMSComponentId1",
                table: "SecurityIssuePost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CMSComponent",
                table: "CMSComponent");

            migrationBuilder.DropColumn(
                name: "CMSComponentId",
                table: "SecurityIssuePost");

            migrationBuilder.DropColumn(
                name: "CMSComponentId1",
                table: "SecurityIssuePost");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CMSComponent");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CMSComponent");

            migrationBuilder.RenameTable(
                name: "CMSComponent",
                newName: "Package");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Package",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "Name");

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
        }
    }
}
