using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class PessoaUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_PessoaFisicaId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_PessoaJuridicaId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_PessoaFisicaId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_PessoaJuridicaId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "PessoaJuridicaId",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PessoaFisicaId",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaJuridicaId",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PessoaFisicaId",
                table: "Cliente",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PessoaJuridicaId",
                table: "Cliente",
                column: "PessoaJuridicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_PessoaFisicaId",
                table: "Cliente",
                column: "PessoaFisicaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_PessoaJuridicaId",
                table: "Cliente",
                column: "PessoaJuridicaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
