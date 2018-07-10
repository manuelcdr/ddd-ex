using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    public partial class AtualizaçãodeUsuarioeNiveldeAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_Menu_MenuId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NivelDeAcesso",
                table: "NivelDeAcesso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "NivelDeAcesso",
                newName: "NiveisDeAcessos");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuPaiId",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NiveisDeAcessos",
                table: "NiveisDeAcessos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsuarioNivelDeAcesso",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(nullable: false),
                    NivelDeAcessoId = table.Column<Guid>(nullable: false),
                    UsuarioId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioNivelDeAcesso", x => new { x.UsuarioId, x.NivelDeAcessoId });
                    table.ForeignKey(
                        name: "FK_UsuarioNivelDeAcesso_NiveisDeAcessos_NivelDeAcessoId",
                        column: x => x.NivelDeAcessoId,
                        principalTable: "NiveisDeAcessos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioNivelDeAcesso_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioNivelDeAcesso_AspNetUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuPaiId",
                table: "Menus",
                column: "MenuPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioNivelDeAcesso_NivelDeAcessoId",
                table: "UsuarioNivelDeAcesso",
                column: "NivelDeAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioNivelDeAcesso_UsuarioId1",
                table: "UsuarioNivelDeAcesso",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuNivelDeAcesso_Menus_MenuId",
                table: "MenuNivelDeAcesso",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuNivelDeAcesso_NiveisDeAcessos_NivelDeAcessoId",
                table: "MenuNivelDeAcesso",
                column: "NivelDeAcessoId",
                principalTable: "NiveisDeAcessos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_MenuPaiId",
                table: "Menus",
                column: "MenuPaiId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_Menus_MenuId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuNivelDeAcesso_NiveisDeAcessos_NivelDeAcessoId",
                table: "MenuNivelDeAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_MenuPaiId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "UsuarioNivelDeAcesso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NiveisDeAcessos",
                table: "NiveisDeAcessos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MenuPaiId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuPaiId",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "NiveisDeAcessos",
                newName: "NivelDeAcesso");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NivelDeAcesso",
                table: "NivelDeAcesso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

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
        }
    }
}
