using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class BDfim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Capital_capitalId",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_capitalId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "SaldoCapital",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "capitalId",
                table: "Compra");

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Capital",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Capital",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Capital_CompraId",
                table: "Capital",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Capital_PedidoId",
                table: "Capital",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capital_Compra_CompraId",
                table: "Capital",
                column: "CompraId",
                principalTable: "Compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Capital_Pedido_PedidoId",
                table: "Capital",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capital_Compra_CompraId",
                table: "Capital");

            migrationBuilder.DropForeignKey(
                name: "FK_Capital_Pedido_PedidoId",
                table: "Capital");

            migrationBuilder.DropIndex(
                name: "IX_Capital_CompraId",
                table: "Capital");

            migrationBuilder.DropIndex(
                name: "IX_Capital_PedidoId",
                table: "Capital");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Capital");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Capital");

            migrationBuilder.AddColumn<double>(
                name: "SaldoCapital",
                table: "Compra",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "capitalId",
                table: "Compra",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_capitalId",
                table: "Compra",
                column: "capitalId");

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
