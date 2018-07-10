using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class AdicionaValidacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Equipe_EquipeId",
                table: "Processo");

            migrationBuilder.DropTable(
                name: "EquipeCliente");

            migrationBuilder.DropTable(
                name: "EquipePessoa");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Processo_EquipeId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Processo");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaFisica_DataNascimento",
                table: "Pessoa",
                newName: "DataNascimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Pessoa",
                newName: "DadosPessoaFisica_DataNascimento");

            migrationBuilder.AddColumn<Guid>(
                name: "EquipeId",
                table: "Processo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Processo_EquipeId",
                table: "Processo",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeCliente_EquipeId",
                table: "EquipeCliente",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipePessoa_EquipeId",
                table: "EquipePessoa",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Equipe_EquipeId",
                table: "Processo",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
