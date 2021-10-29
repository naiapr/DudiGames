using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Capital",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Capital",
                type: "int",
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
    }
}
