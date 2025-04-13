using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEntidadeMotorista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoasFisicas_Estados_EstadoId",
                table: "PessoasFisicas");

            migrationBuilder.DropIndex(
                name: "IX_PessoasFisicas_EstadoId",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "PessoasFisicas");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_IdEstadoRG",
                table: "PessoasFisicas",
                column: "IdEstadoRG");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasFisicas_Estados_IdEstadoRG",
                table: "PessoasFisicas",
                column: "IdEstadoRG",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoasFisicas_Estados_IdEstadoRG",
                table: "PessoasFisicas");

            migrationBuilder.DropIndex(
                name: "IX_PessoasFisicas_IdEstadoRG",
                table: "PessoasFisicas");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "PessoasFisicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_EstadoId",
                table: "PessoasFisicas",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasFisicas_Estados_EstadoId",
                table: "PessoasFisicas",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
