using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class PessoaUpdate10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_PessoaFisica_DadosPessoaFisicaId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_PessoaJuridica_DadosPessoaJuridicaId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFisica_Pessoa_Id",
                table: "PessoaFisica");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Pessoa_Id",
                table: "PessoaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_DadosPessoaFisicaId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_DadosPessoaJuridicaId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DadosPessoaFisicaId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DadosPessoaJuridicaId",
                table: "Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_PessoaFisica_Id",
                table: "Pessoa",
                column: "Id",
                principalTable: "PessoaFisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_PessoaJuridica_Id",
                table: "Pessoa",
                column: "Id",
                principalTable: "PessoaJuridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaFisica_Cliente_Id",
                table: "PessoaFisica",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Cliente_Id",
                table: "PessoaJuridica",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_PessoaFisica_Id",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_PessoaJuridica_Id",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFisica_Cliente_Id",
                table: "PessoaFisica");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Cliente_Id",
                table: "PessoaJuridica");

            migrationBuilder.AddColumn<Guid>(
                name: "DadosPessoaFisicaId",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DadosPessoaJuridicaId",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_DadosPessoaFisicaId",
                table: "Cliente",
                column: "DadosPessoaFisicaId",
                unique: true,
                filter: "[DadosPessoaFisicaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_DadosPessoaJuridicaId",
                table: "Cliente",
                column: "DadosPessoaJuridicaId",
                unique: true,
                filter: "[DadosPessoaJuridicaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_PessoaFisica_DadosPessoaFisicaId",
                table: "Cliente",
                column: "DadosPessoaFisicaId",
                principalTable: "PessoaFisica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_PessoaJuridica_DadosPessoaJuridicaId",
                table: "Cliente",
                column: "DadosPessoaJuridicaId",
                principalTable: "PessoaJuridica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaFisica_Pessoa_Id",
                table: "PessoaFisica",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Pessoa_Id",
                table: "PessoaJuridica",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
