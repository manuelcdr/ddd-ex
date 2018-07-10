using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class servicoEdocumento4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentoContrato",
                table: "DocumentoContrato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentoContrato",
                table: "DocumentoContrato",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoContrato_ContratoId",
                table: "DocumentoContrato",
                column: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentoContrato",
                table: "DocumentoContrato");

            migrationBuilder.DropIndex(
                name: "IX_DocumentoContrato_ContratoId",
                table: "DocumentoContrato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentoContrato",
                table: "DocumentoContrato",
                column: "ContratoId");
        }
    }
}
