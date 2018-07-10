using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class addcolunasprocesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processo_AreaOfensora_AreaOfensoraId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Cidade_CidadeId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Cliente_ClienteId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Forum_ForumId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_MotivoAcionamento_MotivoAcionamentoId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Orgao_OrgaoId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_TipoAcao_TipoAcaoId",
                table: "Processo");

            migrationBuilder.AddColumn<Guid>(
                name: "FamiliaOfensoraId",
                table: "Processo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "JusticaId",
                table: "Processo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RiscoId",
                table: "Processo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Processo_FamiliaOfensoraId",
                table: "Processo",
                column: "FamiliaOfensoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_JusticaId",
                table: "Processo",
                column: "JusticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_RiscoId",
                table: "Processo",
                column: "RiscoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_AreaOfensora_AreaOfensoraId",
                table: "Processo",
                column: "AreaOfensoraId",
                principalTable: "AreaOfensora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo",
                column: "CausaRealId",
                principalTable: "CausaReal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Cidade_CidadeId",
                table: "Processo",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Cliente_ClienteId",
                table: "Processo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_FamiliaOfensora_FamiliaOfensoraId",
                table: "Processo",
                column: "FamiliaOfensoraId",
                principalTable: "FamiliaOfensora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Forum_ForumId",
                table: "Processo",
                column: "ForumId",
                principalTable: "Forum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Justica_JusticaId",
                table: "Processo",
                column: "JusticaId",
                principalTable: "Justica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_MotivoAcionamento_MotivoAcionamentoId",
                table: "Processo",
                column: "MotivoAcionamentoId",
                principalTable: "MotivoAcionamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Orgao_OrgaoId",
                table: "Processo",
                column: "OrgaoId",
                principalTable: "Orgao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Risco_RiscoId",
                table: "Processo",
                column: "RiscoId",
                principalTable: "Risco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_TipoAcao_TipoAcaoId",
                table: "Processo",
                column: "TipoAcaoId",
                principalTable: "TipoAcao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processo_AreaOfensora_AreaOfensoraId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Cidade_CidadeId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Cliente_ClienteId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_FamiliaOfensora_FamiliaOfensoraId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Forum_ForumId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Justica_JusticaId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_MotivoAcionamento_MotivoAcionamentoId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Orgao_OrgaoId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_Risco_RiscoId",
                table: "Processo");

            migrationBuilder.DropForeignKey(
                name: "FK_Processo_TipoAcao_TipoAcaoId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_FamiliaOfensoraId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_JusticaId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_RiscoId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "FamiliaOfensoraId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "JusticaId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "RiscoId",
                table: "Processo");

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_AreaOfensora_AreaOfensoraId",
                table: "Processo",
                column: "AreaOfensoraId",
                principalTable: "AreaOfensora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo",
                column: "CausaRealId",
                principalTable: "CausaReal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Cidade_CidadeId",
                table: "Processo",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Cliente_ClienteId",
                table: "Processo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Forum_ForumId",
                table: "Processo",
                column: "ForumId",
                principalTable: "Forum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_MotivoAcionamento_MotivoAcionamentoId",
                table: "Processo",
                column: "MotivoAcionamentoId",
                principalTable: "MotivoAcionamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Orgao_OrgaoId",
                table: "Processo",
                column: "OrgaoId",
                principalTable: "Orgao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_TipoAcao_TipoAcaoId",
                table: "Processo",
                column: "TipoAcaoId",
                principalTable: "TipoAcao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
