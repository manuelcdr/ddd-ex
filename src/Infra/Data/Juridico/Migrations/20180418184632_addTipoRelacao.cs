using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class addTipoRelacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoRelacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRelacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessoPessoa_TipoRelacaoId",
                table: "ProcessoPessoa",
                column: "TipoRelacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessoPessoa_TipoRelacao_TipoRelacaoId",
                table: "ProcessoPessoa",
                column: "TipoRelacaoId",
                principalTable: "TipoRelacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessoPessoa_TipoRelacao_TipoRelacaoId",
                table: "ProcessoPessoa");

            migrationBuilder.DropTable(
                name: "TipoRelacao");

            migrationBuilder.DropIndex(
                name: "IX_ProcessoPessoa_TipoRelacaoId",
                table: "ProcessoPessoa");
        }
    }
}
