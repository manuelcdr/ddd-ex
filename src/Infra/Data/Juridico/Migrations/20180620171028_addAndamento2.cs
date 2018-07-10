using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class addAndamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Andamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Origem = table.Column<int>(nullable: false),
                    ProcessoId = table.Column<Guid>(nullable: false),
                    TipoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Andamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Andamento_Processo_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Andamento_TipoAndamento_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoAndamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Andamento_ProcessoId",
                table: "Andamento",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Andamento_TipoId",
                table: "Andamento",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Andamento");
        }
    }
}
