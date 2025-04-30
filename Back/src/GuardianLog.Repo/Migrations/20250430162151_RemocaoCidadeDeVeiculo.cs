using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoCidadeDeVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Cidades_IdCidade",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_IdCidade",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "Veiculos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdCidade",
                table: "Veiculos",
                column: "IdCidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Cidades_IdCidade",
                table: "Veiculos",
                column: "IdCidade",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
