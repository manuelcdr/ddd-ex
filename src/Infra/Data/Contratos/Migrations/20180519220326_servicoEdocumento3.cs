using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class servicoEdocumento3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicoContrato",
                table: "ServicoContrato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicoContrato",
                table: "ServicoContrato",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoContrato_ContratoId",
                table: "ServicoContrato",
                column: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicoContrato",
                table: "ServicoContrato");

            migrationBuilder.DropIndex(
                name: "IX_ServicoContrato_ContratoId",
                table: "ServicoContrato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicoContrato",
                table: "ServicoContrato",
                column: "ContratoId");
        }
    }
}
