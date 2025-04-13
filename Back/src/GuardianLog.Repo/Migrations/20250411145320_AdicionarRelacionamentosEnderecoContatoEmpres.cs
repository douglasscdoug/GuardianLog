using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentosEnderecoContatoEmpres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Contatos_IdContato",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoasFisicas_Contatos_IdContato",
                table: "PessoasFisicas");

            migrationBuilder.DropIndex(
                name: "IX_PessoasFisicas_IdContato",
                table: "PessoasFisicas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_IdContato",
                table: "Empresas");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_IdEmpresa",
                table: "Contatos",
                column: "IdEmpresa",
                unique: true,
                filter: "[IdEmpresa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_IdPessoaFisica",
                table: "Contatos",
                column: "IdPessoaFisica",
                unique: true,
                filter: "[IdPessoaFisica] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Empresas_IdEmpresa",
                table: "Contatos",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_PessoasFisicas_IdPessoaFisica",
                table: "Contatos",
                column: "IdPessoaFisica",
                principalTable: "PessoasFisicas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Empresas_IdEmpresa",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_PessoasFisicas_IdPessoaFisica",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_IdEmpresa",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_IdPessoaFisica",
                table: "Contatos");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_IdContato",
                table: "PessoasFisicas",
                column: "IdContato",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_IdContato",
                table: "Empresas",
                column: "IdContato",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Contatos_IdContato",
                table: "Empresas",
                column: "IdContato",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoasFisicas_Contatos_IdContato",
                table: "PessoasFisicas",
                column: "IdContato",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
