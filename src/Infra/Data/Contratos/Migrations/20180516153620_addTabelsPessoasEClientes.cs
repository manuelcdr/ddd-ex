using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class addTabelsPessoasEClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Observacoes = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TipoPessoa = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    Celular = table.Column<string>(maxLength: 125, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    OrgaoEmissorRG = table.Column<string>(maxLength: 125, nullable: true),
                    RG = table.Column<string>(maxLength: 125, nullable: true),
                    TelefoneComercial = table.Column<string>(maxLength: 125, nullable: true),
                    CNPJ = table.Column<string>(maxLength: 15, nullable: true),
                    EmailFinanceiro = table.Column<string>(maxLength: 125, nullable: true),
                    InscricaoEstadual = table.Column<string>(maxLength: 125, nullable: true),
                    inscricaoMunicipal = table.Column<string>(maxLength: 125, nullable: true),
                    RazaoSocial = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Atuacao = table.Column<string>(nullable: true),
                    Segmento = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Pessoa_Id",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
