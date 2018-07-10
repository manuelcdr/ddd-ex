using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class PessoaUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cliente_ClienteId",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cliente_PessoaJuridica_ClienteId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_ClienteId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_PessoaJuridica_ClienteId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "PessoaJuridica_ClienteId",
                table: "Pessoa");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaJuridica_ClienteId",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ClienteId",
                table: "Pessoa",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_PessoaJuridica_ClienteId",
                table: "Pessoa",
                column: "PessoaJuridica_ClienteId",
                unique: true,
                filter: "[PessoaJuridica_ClienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cliente_ClienteId",
                table: "Pessoa",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cliente_PessoaJuridica_ClienteId",
                table: "Pessoa",
                column: "PessoaJuridica_ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
