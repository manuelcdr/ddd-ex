using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class StatusContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicoContrato_Contrato_ContratoId",
                table: "ServicoContrato");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ServicoContrato_Contrato_ContratoId1",
            //    table: "ServicoContrato");

            //migrationBuilder.DropIndex(
            //    name: "IX_ServicoContrato_ContratoId1",
            //    table: "ServicoContrato");

            migrationBuilder.DropColumn(
                name: "ContratoId1",
                table: "ServicoContrato");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServicoContrato_FormaPagamentoId",
                table: "ServicoContrato",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoContrato_TipoServicoId",
                table: "ServicoContrato",
                column: "TipoServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicoContrato_Contrato_ContratoId",
                table: "ServicoContrato",
                column: "ContratoId",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicoContrato_FormaPagamento_FormaPagamentoId",
                table: "ServicoContrato",
                column: "FormaPagamentoId",
                principalTable: "FormaPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicoContrato_TipoServico_TipoServicoId",
                table: "ServicoContrato",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicoContrato_Contrato_ContratoId",
                table: "ServicoContrato");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicoContrato_FormaPagamento_FormaPagamentoId",
                table: "ServicoContrato");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicoContrato_TipoServico_TipoServicoId",
                table: "ServicoContrato");

            migrationBuilder.DropIndex(
                name: "IX_ServicoContrato_FormaPagamentoId",
                table: "ServicoContrato");

            migrationBuilder.DropIndex(
                name: "IX_ServicoContrato_TipoServicoId",
                table: "ServicoContrato");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Contrato");

            migrationBuilder.AddColumn<Guid>(
                name: "ContratoId1",
                table: "ServicoContrato",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicoContrato_ContratoId1",
                table: "ServicoContrato",
                column: "ContratoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicoContrato_Contrato_ContratoId",
                table: "ServicoContrato",
                column: "ContratoId",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicoContrato_Contrato_ContratoId1",
                table: "ServicoContrato",
                column: "ContratoId1",
                principalTable: "Contrato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
