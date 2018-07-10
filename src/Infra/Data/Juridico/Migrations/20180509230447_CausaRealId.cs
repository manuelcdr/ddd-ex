using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class CausaRealId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo");

            migrationBuilder.AlterColumn<Guid>(
                name: "CausaRealId",
                table: "Processo",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorResultado",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorProvisao",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPedido",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo",
                column: "CausaRealId",
                principalTable: "CausaReal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo");

            migrationBuilder.AlterColumn<Guid>(
                name: "CausaRealId",
                table: "Processo",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorResultado",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorProvisao",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPedido",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_CausaReal_CausaRealId",
                table: "Processo",
                column: "CausaRealId",
                principalTable: "CausaReal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
