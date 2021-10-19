using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class AddMetodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCompra",
                table: "Financeiro",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVenda",
                table: "Financeiro",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "PrecoCompra",
                table: "Financeiro",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrecoVenda",
                table: "Financeiro",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCompra",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "DataVenda",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "PrecoCompra",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "Financeiro");
        }
    }
}
