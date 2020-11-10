using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracja2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_planowaneTreningi",
                table: "planowaneTreningi");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "planowaneTreningi",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_planowaneTreningi",
                table: "planowaneTreningi",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_planowaneTreningi_id_treningu",
                table: "planowaneTreningi",
                column: "id_treningu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_planowaneTreningi",
                table: "planowaneTreningi");

            migrationBuilder.DropIndex(
                name: "IX_planowaneTreningi_id_treningu",
                table: "planowaneTreningi");

            migrationBuilder.DropColumn(
                name: "id",
                table: "planowaneTreningi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_planowaneTreningi",
                table: "planowaneTreningi",
                columns: new[] { "id_treningu", "id_uzytkownika", "data" });
        }
    }
}
