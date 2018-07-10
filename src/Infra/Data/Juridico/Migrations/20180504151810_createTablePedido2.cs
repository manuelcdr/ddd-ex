using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class createTablePedido2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CausaRealId = table.Column<Guid>(nullable: true),
                    ProcessoId = table.Column<Guid>(nullable: false),
                    ResultadoId = table.Column<int>(nullable: true),
                    RiscoId = table.Column<Guid>(nullable: true),
                    TipoId = table.Column<Guid>(nullable: false),
                    ValorPedido = table.Column<decimal>(nullable: false),
                    ValorProvisao = table.Column<decimal>(nullable: false),
                    ValorResultado = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_CausaRealPedido_CausaRealId",
                        column: x => x.CausaRealId,
                        principalTable: "CausaRealPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Processo_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_ResultadoPedido_ResultadoId",
                        column: x => x.ResultadoId,
                        principalTable: "ResultadoPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Risco_RiscoId",
                        column: x => x.RiscoId,
                        principalTable: "Risco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_TipoPedido_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CausaRealId",
                table: "Pedido",
                column: "CausaRealId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ProcessoId",
                table: "Pedido",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ResultadoId",
                table: "Pedido",
                column: "ResultadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_RiscoId",
                table: "Pedido",
                column: "RiscoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_TipoId",
                table: "Pedido",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
