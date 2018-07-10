using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId1",
                table: "UsuarioNivelDeAcesso");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioNivelDeAcesso_UsuarioId1",
                table: "UsuarioNivelDeAcesso");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "UsuarioNivelDeAcesso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId1",
                table: "UsuarioNivelDeAcesso",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioNivelDeAcesso_UsuarioId1",
                table: "UsuarioNivelDeAcesso",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioNivelDeAcesso_Usuario_UsuarioId1",
                table: "UsuarioNivelDeAcesso",
                column: "UsuarioId1",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
