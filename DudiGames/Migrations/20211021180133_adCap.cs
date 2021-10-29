using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class adCap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CapitalGiro",
                table: "Financeiro",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<double>(
                name: "CapitalGiro",
                table: "Compra",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CapitalId",
                table: "Compra",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SaldoCapital",
                table: "Compra",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CapitalId",
                table: "Compra",
                column: "CapitalId");

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

            migrationBuilder.DropIndex(
                name: "IX_Compra_CapitalId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "CapitalGiro",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "CapitalId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "SaldoCapital",
                table: "Compra");

            migrationBuilder.AlterColumn<double>(
                name: "CapitalGiro",
                table: "Financeiro",
                type: "double",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
