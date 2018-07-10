using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class servicoEdocumento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentoContrato",
                columns: table => new
                {
                    ContratoId = table.Column<Guid>(nullable: false),
                    ContratoId1 = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    NomeArquivo = table.Column<string>(maxLength: 125, nullable: true),
                    NomeOriginal = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoContrato", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_DocumentoContrato_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentoContrato_Contrato_ContratoId1",
                        column: x => x.ContratoId1,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicoContrato",
                columns: table => new
                {
                    ContratoId = table.Column<Guid>(nullable: false),
                    ContratoId1 = table.Column<Guid>(nullable: true),
                    FormaPagamentoId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", maxLength: 125, nullable: true),
                    TipoServicoId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoContrato", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_ServicoContrato_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicoContrato_Contrato_ContratoId1",
                        column: x => x.ContratoId1,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoContrato_ContratoId1",
                table: "DocumentoContrato",
                column: "ContratoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoContrato_ContratoId1",
                table: "ServicoContrato",
                column: "ContratoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentoContrato");

            migrationBuilder.DropTable(
                name: "ServicoContrato");
        }
    }
}
