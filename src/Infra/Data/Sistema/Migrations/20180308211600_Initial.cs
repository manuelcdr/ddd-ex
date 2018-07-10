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
                    Ordem = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelDeAcesso",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Detalhes = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelDeAcesso", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MenuNivelDeAcesso_NivelDeAcessoId",
                table: "MenuNivelDeAcesso",
                column: "NivelDeAcessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuNivelDeAcesso");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "NivelDeAcesso");
        }
    }
}
