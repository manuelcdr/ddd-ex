using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class servicoEdocumento5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentoContrato",
                table: "DocumentoContrato",
                column: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentoContrato",
                table: "DocumentoContrato");

        }
    }
}
