using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class addRelacionamentosTiposeCliente2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteAreaOfensora",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    AreaOfensoraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteAreaOfensora", x => new { x.ClienteId, x.AreaOfensoraId });
                    table.ForeignKey(
                        name: "FK_ClienteAreaOfensora_AreaOfensora_AreaOfensoraId",
                        column: x => x.AreaOfensoraId,
                        principalTable: "AreaOfensora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteAreaOfensora_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteCausaReal",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    CausaRealId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteCausaReal", x => new { x.ClienteId, x.CausaRealId });
                    table.ForeignKey(
                        name: "FK_ClienteCausaReal_CausaReal_CausaRealId",
                        column: x => x.CausaRealId,
                        principalTable: "CausaReal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteCausaReal_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteMotivoAcionamento",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    MotivoAcionamentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMotivoAcionamento", x => new { x.ClienteId, x.MotivoAcionamentoId });
                    table.ForeignKey(
                        name: "FK_ClienteMotivoAcionamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteMotivoAcionamento_MotivoAcionamento_MotivoAcionamentoId",
                        column: x => x.MotivoAcionamentoId,
                        principalTable: "MotivoAcionamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteAreaOfensora_AreaOfensoraId",
                table: "ClienteAreaOfensora",
                column: "AreaOfensoraId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCausaReal_CausaRealId",
                table: "ClienteCausaReal",
                column: "CausaRealId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMotivoAcionamento_MotivoAcionamentoId",
                table: "ClienteMotivoAcionamento",
                column: "MotivoAcionamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteAreaOfensora");

            migrationBuilder.DropTable(
                name: "ClienteCausaReal");

            migrationBuilder.DropTable(
                name: "ClienteMotivoAcionamento");
        }
    }
}
