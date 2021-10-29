using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class finalfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapitalId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "CapitalGiro",
                table: "Financeiro",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CapitalId",
                table: "Pedido",
                column: "CapitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Capital_CapitalId",
                table: "Pedido",
                column: "CapitalId",
                principalTable: "Capital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Capital_CapitalId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_CapitalId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CapitalId",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "CapitalGiro",
                table: "Financeiro",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
