﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    Nome = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(maxLength: 125, nullable: false),
                    Email = table.Column<string>(maxLength: 125, nullable: true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(maxLength: 125, nullable: true),
                    TipoPessoa = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 125, nullable: true),
                    CPF = table.Column<string>(maxLength: 125, nullable: true),
                    Celular = table.Column<string>(maxLength: 125, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    OrgaoEmissorRG = table.Column<string>(maxLength: 125, nullable: true),
                    RG = table.Column<string>(maxLength: 125, nullable: true),
                    TelefoneComercial = table.Column<string>(maxLength: 125, nullable: true),
                    CNPJ = table.Column<string>(maxLength: 125, nullable: true),
                    InscricaoEstadual = table.Column<string>(maxLength: 125, nullable: true),
                    Observacoes = table.Column<string>(maxLength: 125, nullable: true),
                    inscricaoMunicipal = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Cliente_Id",
                        column: x => x.Id,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipeCliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    EquipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeCliente", x => new { x.ClienteId, x.EquipeId });
                    table.ForeignKey(
                        name: "FK_EquipeCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipeCliente_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    EquipeId = table.Column<Guid>(nullable: false),
                    NumeroInstancia = table.Column<int>(nullable: false),
                    NumeroInterno = table.Column<int>(nullable: false),
                    NumeroPasta = table.Column<string>(maxLength: 125, nullable: true),
                    NumeroPrimeiraInstancia = table.Column<string>(maxLength: 125, nullable: true),
                    NumeroSegundaInstancia = table.Column<string>(maxLength: 125, nullable: true),
                    NumeroTerceiraInstancia = table.Column<string>(maxLength: 125, nullable: true),
                    Observacoes = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Processo_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipePessoa",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    EquipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipePessoa", x => new { x.PessoaId, x.EquipeId });
                    table.ForeignKey(
                        name: "FK_EquipePessoa_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipePessoa_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessoPessoa",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    ProcessoId = table.Column<Guid>(nullable: false),
                    TipoRelacaoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessoPessoa", x => new { x.PessoaId, x.ProcessoId, x.TipoRelacaoId });
                    table.ForeignKey(
                        name: "FK_ProcessoPessoa_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessoPessoa_Processo_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeCliente_EquipeId",
                table: "EquipeCliente",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipePessoa_EquipeId",
                table: "EquipePessoa",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_ClienteId",
                table: "Processo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_EquipeId",
                table: "Processo",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessoPessoa_ProcessoId",
                table: "ProcessoPessoa",
                column: "ProcessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeCliente");

            migrationBuilder.DropTable(
                name: "EquipePessoa");

            migrationBuilder.DropTable(
                name: "ProcessoPessoa");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Processo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Equipe");
        }
    }
}
