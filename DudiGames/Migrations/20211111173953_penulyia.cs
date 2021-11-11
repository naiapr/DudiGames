using Microsoft.EntityFrameworkCore.Migrations;

namespace DudiGames.Migrations
{
    public partial class penulyia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Capital_CapitalId",
                table: "Financeiro");

            migrationBuilder.DropIndex(
                name: "IX_Financeiro_CapitalId",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "CapitalGiro",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "CapitalId",
                table: "Financeiro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CapitalGiro",
                table: "Financeiro",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CapitalId",
                table: "Financeiro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_CapitalId",
                table: "Financeiro",
                column: "CapitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Capital_CapitalId",
                table: "Financeiro",
                column: "CapitalId",
                principalTable: "Capital",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
