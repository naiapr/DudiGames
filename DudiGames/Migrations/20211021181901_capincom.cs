using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class capincom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Capital_capitalId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "CapitalGiro",
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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Capital_CapitalId",
                table: "Compra",
                column: "CapitalId",
                principalTable: "Capital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "CapitalGiro",
                table: "Compra",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Capital_capitalId",
                table: "Compra",
                column: "capitalId",
                principalTable: "Capital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
