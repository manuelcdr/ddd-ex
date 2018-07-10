﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PGLaw.Infra.Cross.Common.Enums;
using PGLaw.Infra.Data.Contratos.Context;
using System;

namespace PGLaw.Infra.Data.Contratos.Migrations
{
    [DbContext(typeof(ContratoContext))]
    partial class ContratoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.Entitties.Contrato", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<bool>("ClausulaJuros");

                    b.Property<bool>("ClausulaMulta");

                    b.Property<Guid>("ClienteId");

                    b.Property<DateTime>("DataAssinatura");

                    b.Property<DateTime?>("DataVencimento");

                    b.Property<Guid>("GerenciaId");

                    b.Property<Guid>("IndiceReajusteId");

                    b.Property<string>("Juros")
                        .HasMaxLength(125);

                    b.Property<string>("Multa")
                        .HasMaxLength(125);

                    b.Property<string>("Objeto")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(125);

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(125);

                    b.Property<int>("StatusId");

                    b.Property<Guid>("TipoId");

                    b.Property<Guid>("VigenciaId");

                    b.HasKey("Id");

                    b.HasIndex("GerenciaId");

                    b.HasIndex("IndiceReajusteId");

                    b.HasIndex("TipoId");

                    b.HasIndex("VigenciaId");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.Entitties.DocumentoContrato", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("ContratoId");

                    b.Property<string>("NomeArquivo")
                        .HasMaxLength(125);

                    b.Property<string>("NomeOriginal")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.ToTable("DocumentoContrato");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.Entitties.ServicoContrato", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("ContratoId");

                    b.Property<Guid>("FormaPagamentoId");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(125);

                    b.Property<Guid>("TipoServicoId");

                    b.Property<decimal?>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.HasIndex("FormaPagamentoId");

                    b.HasIndex("TipoServicoId");

                    b.ToTable("ServicoContrato");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.ValueObjects.FormaPagamento", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("FormaPagamento");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.ValueObjects.Gerencia", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Gerencia");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.ValueObjects.IndiceReajuste", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("IndiceReajuste");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.ValueObjects.Tipo", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.ValueObjects.TipoServico", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TipoServico");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.ValueObjects.Vigencia", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Vigencia");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Pessoas.Entitties.Cliente", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Atuacao")
                        .HasMaxLength(125);

                    b.Property<string>("Segmento")
                        .HasMaxLength(125);

                    b.Property<string>("UF")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Pessoas.Entitties.Pessoa", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Email")
                        .HasMaxLength(125);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Observacoes")
                        .HasMaxLength(125);

                    b.Property<string>("Telefone")
                        .HasMaxLength(125);

                    b.Property<int>("TipoPessoa");

                    b.Property<string>("Url")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.Entitties.Contrato", b =>
                {
                    b.HasOne("PGLaw.Domain.Contratos.Contratos.ValueObjects.Gerencia", "Gerencia")
                        .WithMany()
                        .HasForeignKey("GerenciaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Contratos.Contratos.ValueObjects.IndiceReajuste", "IndiceReajuste")
                        .WithMany()
                        .HasForeignKey("IndiceReajusteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Contratos.Contratos.ValueObjects.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Contratos.Contratos.ValueObjects.Vigencia", "Vigencia")
                        .WithMany()
                        .HasForeignKey("VigenciaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.Entitties.DocumentoContrato", b =>
                {
                    b.HasOne("PGLaw.Domain.Contratos.Contratos.Entitties.Contrato", "Contrato")
                        .WithMany("DocumentoContratos")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Contratos.Entitties.ServicoContrato", b =>
                {
                    b.HasOne("PGLaw.Domain.Contratos.Contratos.Entitties.Contrato", "Contrato")
                        .WithMany("ServicoContratos")
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PGLaw.Domain.Contratos.Contratos.ValueObjects.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Contratos.Contratos.ValueObjects.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("TipoServicoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Pessoas.Entitties.Cliente", b =>
                {
                    b.HasOne("PGLaw.Domain.Contratos.Pessoas.Entitties.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Contratos.Pessoas.Entitties.Pessoa", b =>
                {
                    b.OwnsOne("PGLaw.Domain.Contratos.Pessoas.Entitties.DadosPessoaFisica", "DadosPessoaFisica", b1 =>
                        {
                            b1.Property<Guid>("PessoaId");

                            b1.Property<string>("CPF")
                                .HasColumnName("CPF")
                                .HasMaxLength(11);

                            b1.Property<string>("Celular")
                                .HasColumnName("Celular")
                                .HasMaxLength(125);

                            b1.Property<DateTime?>("DataNascimento")
                                .HasColumnName("DataNascimento");

                            b1.Property<string>("OrgaoEmissorRG")
                                .HasColumnName("OrgaoEmissorRG")
                                .HasMaxLength(125);

                            b1.Property<string>("RG")
                                .HasColumnName("RG")
                                .HasMaxLength(125);

                            b1.Property<string>("TelefoneComercial")
                                .HasColumnName("TelefoneComercial")
                                .HasMaxLength(125);

                            b1.ToTable("Pessoa");

                            b1.HasOne("PGLaw.Domain.Contratos.Pessoas.Entitties.Pessoa")
                                .WithOne("DadosPessoaFisica")
                                .HasForeignKey("PGLaw.Domain.Contratos.Pessoas.Entitties.DadosPessoaFisica", "PessoaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("PGLaw.Domain.Contratos.Pessoas.Entitties.DadosPessoaJuridica", "DadosPessoaJuridica", b1 =>
                        {
                            b1.Property<Guid>("PessoaId");

                            b1.Property<string>("CNPJ")
                                .HasColumnName("CNPJ")
                                .HasMaxLength(15);

                            b1.Property<string>("EmailFinanceiro")
                                .HasColumnName("EmailFinanceiro")
                                .HasMaxLength(125);

                            b1.Property<string>("InscricaoEstadual")
                                .HasColumnName("InscricaoEstadual")
                                .HasMaxLength(125);

                            b1.Property<string>("InscricaoMunicipal")
                                .HasColumnName("inscricaoMunicipal")
                                .HasMaxLength(125);

                            b1.Property<string>("RazaoSocial")
                                .HasColumnName("RazaoSocial")
                                .HasMaxLength(125);

                            b1.ToTable("Pessoa");

                            b1.HasOne("PGLaw.Domain.Contratos.Pessoas.Entitties.Pessoa")
                                .WithOne("DadosPessoaJuridica")
                                .HasForeignKey("PGLaw.Domain.Contratos.Pessoas.Entitties.DadosPessoaJuridica", "PessoaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
