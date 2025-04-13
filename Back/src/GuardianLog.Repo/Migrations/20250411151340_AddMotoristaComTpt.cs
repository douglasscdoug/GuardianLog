using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianLog.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddMotoristaComTpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaCNH",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "DataEmissaoCNH",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "DataVencimentoCNH",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "NumeroCNH",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "NumeroRegistroCNH",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "TipoVinculo",
                table: "PessoasFisicas");

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroCNH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroRegistroCNH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEmissaoCNH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimentoCNH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaCNH = table.Column<int>(type: "int", nullable: false),
                    TipoVinculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motoristas_PessoasFisicas_Id",
                        column: x => x.Id,
                        principalTable: "PessoasFisicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaCNH",
                table: "PessoasFisicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEmissaoCNH",
                table: "PessoasFisicas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimentoCNH",
                table: "PessoasFisicas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PessoasFisicas",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroCNH",
                table: "PessoasFisicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroRegistroCNH",
                table: "PessoasFisicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoVinculo",
                table: "PessoasFisicas",
                type: "int",
                nullable: true);
        }
    }
}
