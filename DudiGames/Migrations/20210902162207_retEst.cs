using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class retEst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Estoque_EstoqueId",
                table: "Financeiro");

            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Pedido_PedidoId",
                table: "Financeiro");

            migrationBuilder.DropIndex(
                name: "IX_Financeiro_EstoqueId",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Financeiro");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Financeiro",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Pedido_PedidoId",
                table: "Financeiro",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Pedido_PedidoId",
                table: "Financeiro");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Financeiro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Financeiro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_EstoqueId",
                table: "Financeiro",
                column: "EstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Estoque_EstoqueId",
                table: "Financeiro",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Pedido_PedidoId",
                table: "Financeiro",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
