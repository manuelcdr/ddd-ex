using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    public partial class verificandoAtualizacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_MenuPaiId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_Menu_MenuId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "UsuarioNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId",
                table: "UsuarioNivelDeAcesso");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Menu_MenuPaiId",
                table: "Menu",
                column: "MenuPaiId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuNivelDeAcesso_Menu_MenuId",
                table: "MenuNivelDeAcesso",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "MenuNivelDeAcesso",
                column: "NivelDeAcessoId",
                principalTable: "NivelDeAcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "UsuarioNivelDeAcesso",
                column: "NivelDeAcessoId",
                principalTable: "NivelDeAcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId",
                table: "UsuarioNivelDeAcesso",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Menu_MenuPaiId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_Menu_MenuId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "UsuarioNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId",
                table: "UsuarioNivelDeAcesso");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Menu_MenuPaiId",
                table: "Menu",
                column: "MenuPaiId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuNivelDeAcesso_Menu_MenuId",
                table: "MenuNivelDeAcesso",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "MenuNivelDeAcesso",
                column: "NivelDeAcessoId",
                principalTable: "NivelDeAcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "UsuarioNivelDeAcesso",
                column: "NivelDeAcessoId",
                principalTable: "NivelDeAcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId",
                table: "UsuarioNivelDeAcesso",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
