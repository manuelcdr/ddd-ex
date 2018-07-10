using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    public partial class atualizaTabelaMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ordem",
                table: "Menu",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaminhoAcesso",
                table: "Menu",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaminhoAcessoIds",
                table: "Menu",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoAcesso",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "CaminhoAcessoIds",
                table: "Menu");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ordem",
                table: "Menu",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
