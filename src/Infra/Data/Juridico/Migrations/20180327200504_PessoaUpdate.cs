using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class PessoaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailFinanceiro",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Pessoa",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atuacao",
                table: "Cliente",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Segmento",
                table: "Cliente",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Cliente",
                maxLength: 125,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailFinanceiro",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Atuacao",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Segmento",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Cliente");
        }
    }
}
