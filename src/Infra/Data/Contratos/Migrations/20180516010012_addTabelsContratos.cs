using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    public partial class addTabelsContratos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    ClausulaJuros = table.Column<bool>(nullable: false),
                    ClausulaMulta = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    DataAssinatura = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    GerenciaId = table.Column<Guid>(nullable: false),
                    IndiceReajusteId = table.Column<Guid>(nullable: false),
                    Juros = table.Column<string>(nullable: true),
                    Multa = table.Column<string>(nullable: true),
                    Objeto = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    TipoId = table.Column<Guid>(nullable: false),
                    VigenciaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");
        }
    }
}
