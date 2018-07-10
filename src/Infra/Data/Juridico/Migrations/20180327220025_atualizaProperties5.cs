using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class atualizaProperties5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_inscricaoMunicipal",
                table: "Pessoa",
                newName: "inscricaoMunicipal");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_RazaoSocial",
                table: "Pessoa",
                newName: "RazaoSocial");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_InscricaoEstadual",
                table: "Pessoa",
                newName: "InscricaoEstadual");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_EmailFinanceiro",
                table: "Pessoa",
                newName: "EmailFinanceiro");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaJuridica_CNPJ",
                table: "Pessoa",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaFisica_TelefoneComercial",
                table: "Pessoa",
                newName: "TelefoneComercial");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaFisica_RG",
                table: "Pessoa",
                newName: "RG");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaFisica_OrgaoEmissorRG",
                table: "Pessoa",
                newName: "OrgaoEmissorRG");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaFisica_Celular",
                table: "Pessoa",
                newName: "Celular");

            migrationBuilder.RenameColumn(
                name: "DadosPessoaFisica_CPF",
                table: "Pessoa",
                newName: "CPF");

            migrationBuilder.AlterColumn<string>(
                name: "inscricaoMunicipal",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailFinanceiro",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Pessoa",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TelefoneComercial",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrgaoEmissorRG",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Pessoa",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "TelefoneComercial",
                table: "Pessoa",
                newName: "DadosPessoaFisica_TelefoneComercial");

            migrationBuilder.RenameColumn(
                name: "RG",
                table: "Pessoa",
                newName: "DadosPessoaFisica_RG");

            migrationBuilder.RenameColumn(
                name: "OrgaoEmissorRG",
                table: "Pessoa",
                newName: "DadosPessoaFisica_OrgaoEmissorRG");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Pessoa",
                newName: "DadosPessoaFisica_Celular");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Pessoa",
                newName: "DadosPessoaFisica_CPF");

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
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaFisica_TelefoneComercial",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaFisica_RG",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaFisica_OrgaoEmissorRG",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaFisica_Celular",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DadosPessoaFisica_CPF",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
