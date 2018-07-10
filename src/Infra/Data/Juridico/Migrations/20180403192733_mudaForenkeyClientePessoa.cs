using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class mudaForenkeyClientePessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_Id",
                table: "Cliente",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_Id",
                table: "Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cliente_Id",
                table: "Pessoa",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
