using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class conserMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CapitalGiro",
                table: "Pedido",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CapitalId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

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
                name: "CapitalGiro",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CapitalId",
                table: "Pedido");
        }
    }
}
