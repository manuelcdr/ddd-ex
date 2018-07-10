using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    public partial class atualizaProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroPasta",
                table: "Processo");

            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "Processo",
                newName: "Vara");

            migrationBuilder.RenameColumn(
                name: "NumeroInterno",
                table: "Processo",
                newName: "TipoAcaoId");

            migrationBuilder.AlterColumn<byte>(
                name: "NumeroInstancia",
                table: "Processo",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<short>(
                name: "Ano",
                table: "Processo",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<Guid>(
                name: "AreaOfensoraId",
                table: "Processo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CausaRealId",
                table: "Processo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Processo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCitacao",
                table: "Processo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDistribuicao",
                table: "Processo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Esfera",
                table: "Processo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForumId",
                table: "Processo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MotivoAcionamentoId",
                table: "Processo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OrgaoId",
                table: "Processo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ProcessoEletronico",
                table: "Processo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reu",
                table: "Processo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CausaReal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausaReal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 125, nullable: true),
                    Sigla = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamiliaOfensora",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaOfensora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Justica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DescricaoReduzida = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Justica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivoAcionamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoAcionamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(maxLength: 125, nullable: true),
                    EstadoId = table.Column<int>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Nome = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaOfensora",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    FamiliaOfensoraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaOfensora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaOfensora_FamiliaOfensora_FamiliaOfensoraId",
                        column: x => x.FamiliaOfensoraId,
                        principalTable: "FamiliaOfensora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orgao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DescricaoReduzida = table.Column<string>(nullable: true),
                    JusticaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orgao_Justica_JusticaId",
                        column: x => x.JusticaId,
                        principalTable: "Justica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(maxLength: 125, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    CidadeId = table.Column<int>(nullable: false),
                    Complemento = table.Column<string>(maxLength: 125, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 125, nullable: true),
                    Numero = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forum_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoAcao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    OrgaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoAcao_Orgao_OrgaoId",
                        column: x => x.OrgaoId,
                        principalTable: "Orgao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processo_AreaOfensoraId",
                table: "Processo",
                column: "AreaOfensoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_CausaRealId",
                table: "Processo",
                column: "CausaRealId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_CidadeId",
                table: "Processo",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_ForumId",
                table: "Processo",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_MotivoAcionamentoId",
                table: "Processo",
                column: "MotivoAcionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_OrgaoId",
                table: "Processo",
                column: "OrgaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_TipoAcaoId",
                table: "Processo",
                column: "TipoAcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaOfensora_FamiliaOfensoraId",
                table: "AreaOfensora",
                column: "FamiliaOfensoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_CidadeId",
                table: "Forum",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orgao_JusticaId",
                table: "Orgao",
                column: "JusticaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoAcao_OrgaoId",
                table: "TipoAcao",
                column: "OrgaoId");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processo_Cidade_CidadeId",
                table: "Processo",
                column: "CidadeId",
                principalTable: "Cidade",
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

            migrationBuilder.DropTable(
                name: "AreaOfensora");

            migrationBuilder.DropTable(
                name: "CausaReal");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "MotivoAcionamento");

            migrationBuilder.DropTable(
                name: "TipoAcao");

            migrationBuilder.DropTable(
                name: "FamiliaOfensora");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Orgao");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Justica");

            migrationBuilder.DropIndex(
                name: "IX_Processo_AreaOfensoraId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_CausaRealId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_CidadeId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_ForumId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_MotivoAcionamentoId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_OrgaoId",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_Processo_TipoAcaoId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "AreaOfensoraId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "CausaRealId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "DataCitacao",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "DataDistribuicao",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "Esfera",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "MotivoAcionamentoId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "OrgaoId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "ProcessoEletronico",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "Reu",
                table: "Processo");

            migrationBuilder.RenameColumn(
                name: "Vara",
                table: "Processo",
                newName: "Observacoes");

            migrationBuilder.RenameColumn(
                name: "TipoAcaoId",
                table: "Processo",
                newName: "NumeroInterno");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroInstancia",
                table: "Processo",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<string>(
                name: "NumeroPasta",
                table: "Processo",
                maxLength: 125,
                nullable: true);
        }
    }
}
