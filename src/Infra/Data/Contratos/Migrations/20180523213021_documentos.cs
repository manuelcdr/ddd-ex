using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class documentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentoContrato_Contrato_ContratoId",
                table: "DocumentoContrato");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_DocumentoContrato_Contrato_ContratoId1",
            //    table: "DocumentoContrato");

            //migrationBuilder.DropIndex(
            //    name: "IX_DocumentoContrato_ContratoId1",
            //    table: "DocumentoContrato");

            migrationBuilder.DropColumn(
                name: "ContratoId1",
                table: "DocumentoContrato");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Cliente",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Segmento",
                table: "Cliente",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Atuacao",
                table: "Cliente",
                maxLength: 125,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentoContrato_Contrato_ContratoId",
                table: "DocumentoContrato",
                column: "ContratoId",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentoContrato_Contrato_ContratoId",
                table: "DocumentoContrato");

            migrationBuilder.AddColumn<Guid>(
                name: "ContratoId1",
                table: "DocumentoContrato",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Segmento",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Atuacao",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 125,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoContrato_ContratoId1",
                table: "DocumentoContrato",
                column: "ContratoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentoContrato_Contrato_ContratoId",
                table: "DocumentoContrato",
                column: "ContratoId",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentoContrato_Contrato_ContratoId1",
                table: "DocumentoContrato",
                column: "ContratoId1",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
