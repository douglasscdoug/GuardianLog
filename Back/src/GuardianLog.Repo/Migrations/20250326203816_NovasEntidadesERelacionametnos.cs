using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class NovasEntidadesERelacionametnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "TiposVeiculo");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "TiposVeiculo");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "TiposCarreta");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "TiposCarreta");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "TecnologiasRastreamento");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "TecnologiasRastreamento");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "ModelosVeiculos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "ModelosVeiculos");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "MarcasVeiculos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "MarcasVeiculos");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidade",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    IdPessoaFisica = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgaosEmissores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeInstituicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoOrgao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgaosEmissores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    IdContato = table.Column<int>(type: "int", nullable: false),
                    TipoEmpresa = table.Column<int>(type: "int", nullable: false),
                    EhCliente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Contatos_IdContato",
                        column: x => x.IdContato,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoasFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroCPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroRG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOrgaoEmissor = table.Column<int>(type: "int", nullable: false),
                    DataEmissaoRG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    IdEstadoRG = table.Column<int>(type: "int", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    IdContato = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NumeroCNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroRegistroCNH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEmissaoCNH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataVencimentoCNH = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaCNH = table.Column<int>(type: "int", nullable: true),
                    TipoVinculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasFisicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoasFisicas_Contatos_IdContato",
                        column: x => x.IdContato,
                        principalTable: "Contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoasFisicas_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoasFisicas_OrgaosEmissores_IdOrgaoEmissor",
                        column: x => x.IdOrgaoEmissor,
                        principalTable: "OrgaosEmissores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCep = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    IdPessoaFisica = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_CEPs_CepId",
                        column: x => x.IdCep,
                        principalTable: "CEPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enderecos_PessoasFisicas_IdPessoaFisica",
                        column: x => x.IdPessoaFisica,
                        principalTable: "PessoasFisicas",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nacionalidade",
                value: "Brasileiro");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nacionalidade",
                value: "Argentino");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nacionalidade",
                value: "Chileno");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nacionalidade",
                value: "Uruguaio");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_CodCidadeIBGE",
                table: "Cidades",
                column: "CodCidadeIBGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CEPs_IdCidade",
                table: "CEPs",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_IdContato",
                table: "Empresas",
                column: "IdContato",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CepId",
                table: "Enderecos",
                column: "CepId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdEmpresa",
                table: "Enderecos",
                column: "IdEmpresa",
                unique: true,
                filter: "[IdEmpresa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdPessoaFisica",
                table: "Enderecos",
                column: "IdPessoaFisica",
                unique: true,
                filter: "[IdPessoaFisica] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_EstadoId",
                table: "PessoasFisicas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_IdContato",
                table: "PessoasFisicas",
                column: "IdContato",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_IdOrgaoEmissor",
                table: "PessoasFisicas",
                column: "IdOrgaoEmissor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "CEPs");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "PessoasFisicas");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "OrgaosEmissores");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Cidades_CodCidadeIBGE",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_CodCidadeIBGE",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "Nacionalidade",
                table: "Paises");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Veiculos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Veiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "TiposVeiculo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "TiposVeiculo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "TiposCarreta",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "TiposCarreta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "TecnologiasRastreamento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "TecnologiasRastreamento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "ModelosVeiculos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "ModelosVeiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "MarcasVeiculos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "MarcasVeiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8689) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8693) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8694) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8698) });

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8699) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4407) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4409) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4415) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4418) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4477) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4481) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4484) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4486) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataAlteracao", "DataCadastro" },
                values: new object[] { null, new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4489) });
        }
    }
}
