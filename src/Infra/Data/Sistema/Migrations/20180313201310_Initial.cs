using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MenuPaiId = table.Column<Guid>(nullable: true),
                    Ordem = table.Column<string>(maxLength: 100, nullable: true),
                    Titulo = table.Column<string>(maxLength: 100, nullable: true),
                    Url = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_MenuPaiId",
                        column: x => x.MenuPaiId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NivelDeAcesso",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Detalhes = table.Column<string>(maxLength: 100, nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelDeAcesso", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Usuario",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        AcessoDiasDaSemana = table.Column<int>(nullable: false),
            //        Ativo = table.Column<bool>(nullable: false),
            //        Email = table.Column<string>(maxLength: 100, nullable: true),
            //        TrocarSenha = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Usuario", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "MenuNivelDeAcesso",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(nullable: false),
                    NivelDeAcessoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuNivelDeAcesso", x => new { x.MenuId, x.NivelDeAcessoId });
                    table.ForeignKey(
                        name: "FK_MenuNivelDeAcesso_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                        column: x => x.NivelDeAcessoId,
                        principalTable: "NivelDeAcesso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_UsuarioNivelDeAcesso_NivelDeAcesso_NivelDeAcessoId",
                        column: x => x.NivelDeAcessoId,
                        principalTable: "NivelDeAcesso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuPaiId",
                table: "Menu",
                column: "MenuPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuNivelDeAcesso_NivelDeAcessoId",
                table: "MenuNivelDeAcesso",
                column: "NivelDeAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioNivelDeAcesso_NivelDeAcessoId",
                table: "UsuarioNivelDeAcesso",
                column: "NivelDeAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioNivelDeAcesso_UsuarioId1",
                table: "UsuarioNivelDeAcesso",
                column: "UsuarioId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuNivelDeAcesso");

            migrationBuilder.DropTable(
                name: "UsuarioNivelDeAcesso");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "NivelDeAcesso");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
