using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class PessoaUpdate11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipePessoa_Pessoa_PessoaId",
                table: "EquipePessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Cliente_Id",
                table: "PessoaJuridica");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessoPessoa_Pessoa_PessoaId",
                table: "ProcessoPessoa");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica");

            migrationBuilder.RenameTable(
                name: "PessoaJuridica",
                newName: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "inscricaoMunicipal",
                table: "Pessoa",
                newName: "DadosPessoaJuridica_inscricaoMunicipal");

            migrationBuilder.RenameColumn(
                name: "RazaoSocial",
                table: "Pessoa",
                newName: "DadosPessoaJuridica_RazaoSocial");

            migrationBuilder.RenameColumn(
                name: "InscricaoEstadual",
                table: "Pessoa",
                newName: "DadosPessoaJuridica_InscricaoEstadual");

            migrationBuilder.RenameColumn(
                name: "EmailFinanceiro",
                table: "Pessoa",
                newName: "DadosPessoaJuridica_EmailFinanceiro");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Pessoa",
                newName: "DadosPessoaJuridica_CNPJ");

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaJuridica_inscricaoMunicipal",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaJuridica_RazaoSocial",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaJuridica_InscricaoEstadual",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaJuridica_EmailFinanceiro",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaJuridica_CNPJ",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

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
                name: "DadosPessoaFisica_CPF",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DadosPessoaFisica_Celular",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DadosPessoaFisica_DataNascimento",
                table: "Pessoa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DadosPessoaFisica_OrgaoEmissorRG",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DadosPessoaFisica_RG",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DadosPessoaFisica_TelefoneComercial",
                table: "Pessoa",
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
                onDelete: ReferentialAction.Restrict);

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
                name: "DadosPessoaFisica_CPF",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DadosPessoaFisica_Celular",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DadosPessoaFisica_DataNascimento",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DadosPessoaFisica_OrgaoEmissorRG",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DadosPessoaFisica_RG",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DadosPessoaFisica_TelefoneComercial",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "PessoaJuridica");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_inscricaoMunicipal",
                table: "PessoaJuridica",
                newName: "inscricaoMunicipal");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_RazaoSocial",
                table: "PessoaJuridica",
                newName: "RazaoSocial");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_InscricaoEstadual",
                table: "PessoaJuridica",
                newName: "InscricaoEstadual");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_EmailFinanceiro",
                table: "PessoaJuridica",
                newName: "EmailFinanceiro");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_CNPJ",
                table: "PessoaJuridica",
                newName: "CNPJ");

            migrationBuilder.AlterColumn<string>(
                name: "inscricaoMunicipal",
                table: "PessoaJuridica",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "PessoaJuridica",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "PessoaJuridica",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailFinanceiro",
                table: "PessoaJuridica",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "PessoaJuridica",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PessoaJuridica",
                table: "PessoaJuridica",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CPF = table.Column<string>(maxLength: 125, nullable: true),
                    Celular = table.Column<string>(maxLength: 125, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    OrgaoEmissorRG = table.Column<string>(maxLength: 125, nullable: true),
                    RG = table.Column<string>(maxLength: 125, nullable: true),
                    TelefoneComercial = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Cliente_Id",
                        column: x => x.Id,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    table.ForeignKey(
                        name: "FK_Pessoa_Cliente_Id",
                        column: x => x.Id,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoa_PessoaFisica_Id",
                        column: x => x.Id,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoa_PessoaJuridica_Id",
                        column: x => x.Id,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipePessoa_Pessoa_PessoaId",
                table: "EquipePessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Cliente_Id",
                table: "PessoaJuridica",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
