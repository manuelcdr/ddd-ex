using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class createTablePedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CausaRealPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausaRealPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoPedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Risco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    JusticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoPedido_Justica_JusticaId",
                        column: x => x.JusticaId,
                        principalTable: "Justica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoPedido_JusticaId",
                table: "TipoPedido",
                column: "JusticaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CausaRealPedido");

            migrationBuilder.DropTable(
                name: "ResultadoPedido");

            migrationBuilder.DropTable(
                name: "Risco");

            migrationBuilder.DropTable(
                name: "TipoPedido");
        }
    }
}
