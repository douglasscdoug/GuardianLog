using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcasVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TecnologiasRastreamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnologiasRastreamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposCarreta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCarreta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposVinculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVinculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelosVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMarcaVeiculo = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelosVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelosVeiculos_MarcasVeiculos_IdMarcaVeiculo",
                        column: x => x.IdMarcaVeiculo,
                        principalTable: "MarcasVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodUFIBGE = table.Column<int>(type: "int", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCidadeIBGE = table.Column<int>(type: "int", nullable: false),
                    NomeCidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeiculoInternacional = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    IdTipoCarreta = table.Column<int>(type: "int", nullable: true),
                    Chassi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdModeloVeiculo = table.Column<int>(type: "int", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    IdCor = table.Column<int>(type: "int", nullable: false),
                    Renavam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false),
                    IdTipoVinculo = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_Cores_IdCor",
                        column: x => x.IdCor,
                        principalTable: "Cores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_ModelosVeiculos_IdModeloVeiculo",
                        column: x => x.IdModeloVeiculo,
                        principalTable: "ModelosVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_TecnologiasRastreamento_IdTecnologia",
                        column: x => x.IdTecnologia,
                        principalTable: "TecnologiasRastreamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_TiposCarreta_IdTipoCarreta",
                        column: x => x.IdTipoCarreta,
                        principalTable: "TiposCarreta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_TiposVeiculo_IdTipoVeiculo",
                        column: x => x.IdTipoVeiculo,
                        principalTable: "TiposVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_TiposVinculo_IdTipoVinculo",
                        column: x => x.IdTipoVinculo,
                        principalTable: "TiposVinculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Amarelo" },
                    { 2, "Azul" },
                    { 3, "Branco" },
                    { 4, "Cinza" },
                    { 5, "Dourado" },
                    { 6, "Laranja" },
                    { 7, "Marrom" },
                    { 8, "Prata" },
                    { 9, "Preto" },
                    { 10, "Verde" },
                    { 11, "Vermelho" },
                    { 12, "Não informado" }
                });

            migrationBuilder.InsertData(
                table: "MarcasVeiculos",
                columns: new[] { "Id", "DataAlteracao", "DataCadastro", "Nome" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8380), "Scania" },
                    { 2, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8406), "Volvo" },
                    { 3, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8408), "DAF" },
                    { 4, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8410), "MAN" },
                    { 5, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8411), "Renault" },
                    { 6, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8413), "Volkswagen" },
                    { 7, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8414), "Ford" },
                    { 8, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8416), "Iveco" },
                    { 9, null, new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8418), "Mercedes-Benz" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Brasil" },
                    { 2, "Argentina" },
                    { 3, "Chile" },
                    { 4, "Uruguai" }
                });

            migrationBuilder.InsertData(
                table: "TiposCarreta",
                columns: new[] { "Id", "DataAlteracao", "DataCadastro", "Nome" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4173), "Baú" },
                    { 2, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4182), "Baú Refrigerado" },
                    { 3, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4184), "Sider" },
                    { 4, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4185), "Tanque" },
                    { 5, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4187), "Graneleiro" },
                    { 6, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4188), "Prancha" },
                    { 7, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4190), "Bitrem" },
                    { 8, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4191), "Cegonha" }
                });

            migrationBuilder.InsertData(
                table: "TiposVeiculo",
                columns: new[] { "Id", "DataAlteracao", "DataCadastro", "Nome" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4258), "Cavalo" },
                    { 2, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4259), "Carreta" },
                    { 3, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4261), "Truck" },
                    { 4, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4263), "Toco" },
                    { 5, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4264), "VUC" },
                    { 6, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4266), "Automovel" },
                    { 7, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4267), "Onibus" },
                    { 8, null, new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4269), "Utilitário" }
                });

            migrationBuilder.InsertData(
                table: "TiposVinculo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Agregado" },
                    { 2, "Frota" },
                    { 3, "Terceiro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_IdEstado",
                table: "Cidades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdPais",
                table: "Estados",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosVeiculos_IdMarcaVeiculo",
                table: "ModelosVeiculos",
                column: "IdMarcaVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdCidade",
                table: "Veiculos",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdCor",
                table: "Veiculos",
                column: "IdCor");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdModeloVeiculo",
                table: "Veiculos",
                column: "IdModeloVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdTecnologia",
                table: "Veiculos",
                column: "IdTecnologia");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdTipoCarreta",
                table: "Veiculos",
                column: "IdTipoCarreta");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdTipoVeiculo",
                table: "Veiculos",
                column: "IdTipoVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdTipoVinculo",
                table: "Veiculos",
                column: "IdTipoVinculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "ModelosVeiculos");

            migrationBuilder.DropTable(
                name: "TecnologiasRastreamento");

            migrationBuilder.DropTable(
                name: "TiposCarreta");

            migrationBuilder.DropTable(
                name: "TiposVeiculo");

            migrationBuilder.DropTable(
                name: "TiposVinculo");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "MarcasVeiculos");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
