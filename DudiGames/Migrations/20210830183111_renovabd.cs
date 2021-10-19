using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class renovabd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Financeiro");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Financeiro",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstoqueId",
                table: "Financeiro",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVenda",
                table: "Financeiro",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "PrecoUnitario",
                table: "Financeiro",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecoVenda",
                table: "Financeiro",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Financeiro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_EstoqueId",
                table: "Financeiro",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_PedidoId",
                table: "Financeiro",
                column: "PedidoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Financeiro_PedidoId",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "DataVenda",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Financeiro");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Financeiro",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstoqueId",
                table: "Financeiro",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Financeiro",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
