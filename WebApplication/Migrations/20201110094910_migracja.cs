using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class migracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanowaniePosilkow_posilki_id_posilku",
                table: "PlanowaniePosilkow");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanowaniePosilkow_AspNetUsers_id_uzytkownika",
                table: "PlanowaniePosilkow");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanowanieTreningow_treningi_id_treningu",
                table: "PlanowanieTreningow");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanowanieTreningow_AspNetUsers_id_uzytkownika",
                table: "PlanowanieTreningow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanowanieTreningow",
                table: "PlanowanieTreningow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanowaniePosilkow",
                table: "PlanowaniePosilkow");

            migrationBuilder.RenameTable(
                name: "PlanowanieTreningow",
                newName: "planowaneTreningi");

            migrationBuilder.RenameTable(
                name: "PlanowaniePosilkow",
                newName: "planowanePosilki");

            migrationBuilder.RenameIndex(
                name: "IX_PlanowanieTreningow_id_uzytkownika",
                table: "planowaneTreningi",
                newName: "IX_planowaneTreningi_id_uzytkownika");

            migrationBuilder.RenameIndex(
                name: "IX_PlanowaniePosilkow_id_uzytkownika",
                table: "planowanePosilki",
                newName: "IX_planowanePosilki_id_uzytkownika");

            migrationBuilder.AddPrimaryKey(
                name: "PK_planowaneTreningi",
                table: "planowaneTreningi",
                columns: new[] { "id_treningu", "id_uzytkownika", "data" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_planowanePosilki",
                table: "planowanePosilki",
                columns: new[] { "id_posilku", "id_uzytkownika", "data" });

            migrationBuilder.AddForeignKey(
                name: "FK_planowanePosilki_posilki_id_posilku",
                table: "planowanePosilki",
                column: "id_posilku",
                principalTable: "posilki",
                principalColumn: "id_posilku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planowanePosilki_AspNetUsers_id_uzytkownika",
                table: "planowanePosilki",
                column: "id_uzytkownika",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_planowaneTreningi_treningi_id_treningu",
                table: "planowaneTreningi",
                column: "id_treningu",
                principalTable: "treningi",
                principalColumn: "id_treningu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planowaneTreningi_AspNetUsers_id_uzytkownika",
                table: "planowaneTreningi",
                column: "id_uzytkownika",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planowanePosilki_posilki_id_posilku",
                table: "planowanePosilki");

            migrationBuilder.DropForeignKey(
                name: "FK_planowanePosilki_AspNetUsers_id_uzytkownika",
                table: "planowanePosilki");

            migrationBuilder.DropForeignKey(
                name: "FK_planowaneTreningi_treningi_id_treningu",
                table: "planowaneTreningi");

            migrationBuilder.DropForeignKey(
                name: "FK_planowaneTreningi_AspNetUsers_id_uzytkownika",
                table: "planowaneTreningi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_planowaneTreningi",
                table: "planowaneTreningi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_planowanePosilki",
                table: "planowanePosilki");

            migrationBuilder.RenameTable(
                name: "planowaneTreningi",
                newName: "PlanowanieTreningow");

            migrationBuilder.RenameTable(
                name: "planowanePosilki",
                newName: "PlanowaniePosilkow");

            migrationBuilder.RenameIndex(
                name: "IX_planowaneTreningi_id_uzytkownika",
                table: "PlanowanieTreningow",
                newName: "IX_PlanowanieTreningow_id_uzytkownika");

            migrationBuilder.RenameIndex(
                name: "IX_planowanePosilki_id_uzytkownika",
                table: "PlanowaniePosilkow",
                newName: "IX_PlanowaniePosilkow_id_uzytkownika");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanowanieTreningow",
                table: "PlanowanieTreningow",
                columns: new[] { "id_treningu", "id_uzytkownika", "data" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanowaniePosilkow",
                table: "PlanowaniePosilkow",
                columns: new[] { "id_posilku", "id_uzytkownika", "data" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlanowaniePosilkow_posilki_id_posilku",
                table: "PlanowaniePosilkow",
                column: "id_posilku",
                principalTable: "posilki",
                principalColumn: "id_posilku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanowaniePosilkow_AspNetUsers_id_uzytkownika",
                table: "PlanowaniePosilkow",
                column: "id_uzytkownika",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanowanieTreningow_treningi_id_treningu",
                table: "PlanowanieTreningow",
                column: "id_treningu",
                principalTable: "treningi",
                principalColumn: "id_treningu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanowanieTreningow_AspNetUsers_id_uzytkownika",
                table: "PlanowanieTreningow",
                column: "id_uzytkownika",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
