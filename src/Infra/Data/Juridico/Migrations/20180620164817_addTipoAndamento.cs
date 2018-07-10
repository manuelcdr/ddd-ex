using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class addTipoAndamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoAndamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    GrupoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAndamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoAndamento_GrupoAndamento_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "GrupoAndamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoAndamento_GrupoId",
                table: "TipoAndamento",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoAndamento");
        }
    }
}
