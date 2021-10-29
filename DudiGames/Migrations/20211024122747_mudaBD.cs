using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class mudaBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Capital_CapitalId",
                table: "Compra");

            migrationBuilder.RenameColumn(
                name: "CapitalId",
                table: "Compra",
                newName: "capitalId");

            migrationBuilder.RenameIndex(
                name: "IX_Compra_CapitalId",
                table: "Compra",
                newName: "IX_Compra_capitalId");

            migrationBuilder.AlterColumn<int>(
                name: "capitalId",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Capital_capitalId",
                table: "Compra",
                column: "capitalId",
                principalTable: "Capital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Capital_capitalId",
                table: "Compra");

            migrationBuilder.RenameColumn(
                name: "capitalId",
                table: "Compra",
                newName: "CapitalId");

            migrationBuilder.RenameIndex(
                name: "IX_Compra_capitalId",
                table: "Compra",
                newName: "IX_Compra_CapitalId");

            migrationBuilder.AlterColumn<int>(
                name: "CapitalId",
                table: "Compra",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Capital_CapitalId",
                table: "Compra",
                column: "CapitalId",
                principalTable: "Capital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
