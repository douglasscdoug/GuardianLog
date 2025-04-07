using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AjusteIdCepEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_CEPs_CepId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_CepId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "CepId",
                table: "Enderecos");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdCep",
                table: "Enderecos",
                column: "IdCep");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_CEPs_IdCep",
                table: "Enderecos",
                column: "IdCep",
                principalTable: "CEPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_CEPs_IdCep",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_IdCep",
                table: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "CepId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CepId",
                table: "Enderecos",
                column: "CepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_CEPs_CepId",
                table: "Enderecos",
                column: "CepId",
                principalTable: "CEPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
