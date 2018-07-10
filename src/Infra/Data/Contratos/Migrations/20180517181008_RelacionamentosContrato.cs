using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class RelacionamentosContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoa",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Contrato",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Objeto",
                table: "Contrato",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Multa",
                table: "Contrato",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Juros",
                table: "Contrato",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_GerenciaId",
                table: "Contrato",
                column: "GerenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IndiceReajusteId",
                table: "Contrato",
                column: "IndiceReajusteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TipoId",
                table: "Contrato",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_VigenciaId",
                table: "Contrato",
                column: "VigenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Gerencia_GerenciaId",
                table: "Contrato",
                column: "GerenciaId",
                principalTable: "Gerencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_IndiceReajuste_IndiceReajusteId",
                table: "Contrato",
                column: "IndiceReajusteId",
                principalTable: "IndiceReajuste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Tipo_TipoId",
                table: "Contrato",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Vigencia_VigenciaId",
                table: "Contrato",
                column: "VigenciaId",
                principalTable: "Vigencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Gerencia_GerenciaId",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_IndiceReajuste_IndiceReajusteId",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Tipo_TipoId",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Vigencia_VigenciaId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_GerenciaId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_IndiceReajusteId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_TipoId",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_VigenciaId",
                table: "Contrato");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Contrato",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Objeto",
                table: "Contrato",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Multa",
                table: "Contrato",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Juros",
                table: "Contrato",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);
        }
    }
}
