using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class addtabl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Compra_CompraId",
                table: "Financeiro");

            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Pedido_PedidoId",
                table: "Financeiro");

            migrationBuilder.DropIndex(
                name: "IX_Financeiro_CompraId",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "DataCompra",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "PrecoCompra",
                table: "Financeiro");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Financeiro",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Financeiro",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecoUnitario",
                table: "Financeiro",
                nullable: false,
                defaultValue: 0.0);

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
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "Financeiro");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "Financeiro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Financeiro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCompra",
                table: "Financeiro",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "PrecoCompra",
                table: "Financeiro",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_CompraId",
                table: "Financeiro",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Compra_CompraId",
                table: "Financeiro",
                column: "CompraId",
                principalTable: "Compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
