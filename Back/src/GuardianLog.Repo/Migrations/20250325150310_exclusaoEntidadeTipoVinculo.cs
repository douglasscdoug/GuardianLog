using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class exclusaoEntidadeTipoVinculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TiposVinculo_IdTipoVinculo",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "TiposVinculo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_IdTipoVinculo",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "IdTipoVinculo",
                table: "Veiculos",
                newName: "TipoVinculo");

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 461, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 25, 12, 3, 9, 462, DateTimeKind.Local).AddTicks(4489));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoVinculo",
                table: "Veiculos",
                newName: "IdTipoVinculo");

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

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "MarcasVeiculos",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 862, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "TiposCarreta",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "TiposVeiculo",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 3, 11, 16, 29, 14, 863, DateTimeKind.Local).AddTicks(4269));

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
                name: "IX_Veiculos_IdTipoVinculo",
                table: "Veiculos",
                column: "IdTipoVinculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TiposVinculo_IdTipoVinculo",
                table: "Veiculos",
                column: "IdTipoVinculo",
                principalTable: "TiposVinculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
