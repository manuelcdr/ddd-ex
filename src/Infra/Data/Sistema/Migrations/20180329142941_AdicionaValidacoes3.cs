using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    public partial class AdicionaValidacoes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "NivelDeAcesso",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Detalhes",
                table: "NivelDeAcesso",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Menu",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Menu",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "NivelDeAcesso",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Detalhes",
                table: "NivelDeAcesso",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Menu",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Menu",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);
        }
    }
}
