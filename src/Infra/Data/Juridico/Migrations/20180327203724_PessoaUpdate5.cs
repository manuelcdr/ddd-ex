using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class PessoaUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipePessoa_Pessoa_PessoaId",
                table: "EquipePessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessoPessoa_Pessoa_PessoaId",
                table: "ProcessoPessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "TipoPessoa",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "OrgaoEmissorRG",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "TelefoneComercial",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "PessoaJuridica");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "PessoaJuridica",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 125, nullable: true),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Observacoes = table.Column<string>(maxLength: 125, nullable: true),
                    Telefone = table.Column<string>(maxLength: 125, nullable: true),
                    TipoPessoa = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CPF = table.Column<string>(maxLength: 125, nullable: true),
                    Celular = table.Column<string>(maxLength: 125, nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    OrgaoEmissorRG = table.Column<string>(maxLength: 125, nullable: true),
                    RG = table.Column<string>(maxLength: 125, nullable: true),
                    TelefoneComercial = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Pessoa_Id",
                        column: x => x.Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_ClienteId",
                table: "PessoaJuridica",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_ClienteId",
                table: "PessoaFisica",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_Id",
                table: "Cliente",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipePessoa_Pessoa_PessoaId",
                table: "EquipePessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Cliente_ClienteId",
                table: "PessoaJuridica",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Pessoa_Id",
                table: "PessoaJuridica",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessoPessoa_Pessoa_PessoaId",
                table: "ProcessoPessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_Id",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipePessoa_Pessoa_PessoaId",
                table: "EquipePessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Cliente_ClienteId",
                table: "PessoaJuridica");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Pessoa_Id",
                table: "PessoaJuridica");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessoPessoa_Pessoa_PessoaId",
                table: "ProcessoPessoa");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PessoaJuridica_ClienteId",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "PessoaJuridica");

            migrationBuilder.RenameTable(
                name: "PessoaJuridica",
                newName: "Pessoa");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoa",
                maxLength: 125,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pessoa",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoa",
                table: "Pessoa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgaoEmissorRG",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneComercial",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipePessoa_Pessoa_PessoaId",
                table: "EquipePessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessoPessoa_Pessoa_PessoaId",
                table: "ProcessoPessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
