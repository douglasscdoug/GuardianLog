using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class RefatorarEnderecoSemCep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_PessoasFisicas_IdPessoaFisica",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_CEPs_IdCep",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Empresas_IdEmpresa",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PessoasFisicas_IdPessoaFisica",
                table: "Enderecos");

            migrationBuilder.DropTable(
                name: "CEPs");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Cidades_CodCidadeIBGE",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_CodCidadeIBGE",
                table: "Cidades");

            migrationBuilder.RenameColumn(
                name: "IdCep",
                table: "Enderecos",
                newName: "IdCidade");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_IdCep",
                table: "Enderecos",
                newName: "IX_Enderecos_IdCidade");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CodCidadeIBGE",
                table: "Cidades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_CodCidadeIBGE",
                table: "Cidades",
                column: "CodCidadeIBGE",
                unique: true,
                filter: "[CodCidadeIBGE] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_PessoasFisicas_IdPessoaFisica",
                table: "Contatos",
                column: "IdPessoaFisica",
                principalTable: "PessoasFisicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Cidades_IdCidade",
                table: "Enderecos",
                column: "IdCidade",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Empresas_IdEmpresa",
                table: "Enderecos",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PessoasFisicas_IdPessoaFisica",
                table: "Enderecos",
                column: "IdPessoaFisica",
                principalTable: "PessoasFisicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_PessoasFisicas_IdPessoaFisica",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Cidades_IdCidade",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Empresas_IdEmpresa",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PessoasFisicas_IdPessoaFisica",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_CodCidadeIBGE",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "IdCidade",
                table: "Enderecos",
                newName: "IdCep");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_IdCidade",
                table: "Enderecos",
                newName: "IX_Enderecos_IdCep");

            migrationBuilder.AlterColumn<int>(
                name: "CodCidadeIBGE",
                table: "Cidades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Cidades_CodCidadeIBGE",
                table: "Cidades",
                column: "CodCidadeIBGE");

            migrationBuilder.CreateTable(
                name: "CEPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCidade = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CEPs_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "CodCidadeIBGE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_CodCidadeIBGE",
                table: "Cidades",
                column: "CodCidadeIBGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CEPs_IdCidade",
                table: "CEPs",
                column: "IdCidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_PessoasFisicas_IdPessoaFisica",
                table: "Contatos",
                column: "IdPessoaFisica",
                principalTable: "PessoasFisicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_CEPs_IdCep",
                table: "Enderecos",
                column: "IdCep",
                principalTable: "CEPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Empresas_IdEmpresa",
                table: "Enderecos",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PessoasFisicas_IdPessoaFisica",
                table: "Enderecos",
                column: "IdPessoaFisica",
                principalTable: "PessoasFisicas",
                principalColumn: "Id");
        }
    }
}
