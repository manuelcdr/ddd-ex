﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Cross.Common.Enums;
using PGLaw.Infra.Data.Juridico.Context;
using System;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    [DbContext(typeof(JuridicoContext))]
    [Migration("20180620171028_addAndamento2")]
    partial class addAndamento2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PGLaw.Domain.Juridico.Common.Entitties.Forum", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Forum");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Enderecos.Entitties.Cidade", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Cep")
                        .HasMaxLength(125);

                    b.Property<int>("EstadoId");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("Nome")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Enderecos.Entitties.Estado", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nome")
                        .HasMaxLength(125);

                    b.Property<string>("Sigla")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", b =>
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

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", b =>
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

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships.PessoaCliente", b =>
                {
                    b.Property<Guid>("PessoaId");

                    b.Property<Guid>("ClienteId");

                    b.HasKey("PessoaId", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("PessoaCliente");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Andamento", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<int>("Origem");

                    b.Property<Guid>("ProcessoId");

                    b.Property<Guid>("TipoId");

                    b.HasKey("Id");

                    b.HasIndex("ProcessoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Andamento");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.AreaOfensora", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.Property<Guid>("FamiliaOfensoraId");

                    b.HasKey("Id");

                    b.HasIndex("FamiliaOfensoraId");

                    b.ToTable("AreaOfensora");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.CausaReal", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("CausaReal");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.CausaRealPedido", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("CausaRealPedido");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.FamiliaOfensora", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("FamiliaOfensora");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.MotivoAcionamento", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("MotivoAcionamento");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Pedido", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid?>("CausaRealId");

                    b.Property<Guid>("ProcessoId");

                    b.Property<int?>("ResultadoId");

                    b.Property<Guid?>("RiscoId");

                    b.Property<Guid>("TipoId");

                    b.Property<decimal?>("ValorPedido");

                    b.Property<decimal?>("ValorProvisao");

                    b.Property<decimal?>("ValorResultado");

                    b.HasKey("Id");

                    b.HasIndex("CausaRealId");

                    b.HasIndex("ProcessoId");

                    b.HasIndex("ResultadoId");

                    b.HasIndex("RiscoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Processo", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<short>("Ano");

                    b.Property<Guid>("AreaOfensoraId");

                    b.Property<Guid?>("CausaRealId");

                    b.Property<int>("CidadeId");

                    b.Property<Guid>("ClienteId");

                    b.Property<DateTime>("DataCitacao");

                    b.Property<DateTime?>("DataDistribuicao");

                    b.Property<int>("Esfera");

                    b.Property<Guid>("FamiliaOfensoraId");

                    b.Property<int>("ForumId");

                    b.Property<int>("JusticaId");

                    b.Property<Guid>("MotivoAcionamentoId");

                    b.Property<byte>("NumeroInstancia");

                    b.Property<string>("NumeroPrimeiraInstancia")
                        .HasMaxLength(125);

                    b.Property<string>("NumeroSegundaInstancia")
                        .HasMaxLength(125);

                    b.Property<string>("NumeroTerceiraInstancia")
                        .HasMaxLength(125);

                    b.Property<int>("OrgaoId");

                    b.Property<bool>("ProcessoEletronico");

                    b.Property<bool>("Reu");

                    b.Property<Guid>("RiscoId");

                    b.Property<int>("TipoAcaoId");

                    b.Property<string>("Vara")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.HasIndex("AreaOfensoraId");

                    b.HasIndex("CausaRealId");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FamiliaOfensoraId");

                    b.HasIndex("ForumId");

                    b.HasIndex("JusticaId");

                    b.HasIndex("MotivoAcionamentoId");

                    b.HasIndex("OrgaoId");

                    b.HasIndex("RiscoId");

                    b.HasIndex("TipoAcaoId");

                    b.ToTable("Processo");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ClienteAreaOfensora", b =>
                {
                    b.Property<Guid>("ClienteId");

                    b.Property<Guid>("AreaOfensoraId");

                    b.HasKey("ClienteId", "AreaOfensoraId");

                    b.HasIndex("AreaOfensoraId");

                    b.ToTable("ClienteAreaOfensora");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ClienteCausaReal", b =>
                {
                    b.Property<Guid>("ClienteId");

                    b.Property<Guid>("CausaRealId");

                    b.HasKey("ClienteId", "CausaRealId");

                    b.HasIndex("CausaRealId");

                    b.ToTable("ClienteCausaReal");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ClienteMotivoAcionamento", b =>
                {
                    b.Property<Guid>("ClienteId");

                    b.Property<Guid>("MotivoAcionamentoId");

                    b.HasKey("ClienteId", "MotivoAcionamentoId");

                    b.HasIndex("MotivoAcionamentoId");

                    b.ToTable("ClienteMotivoAcionamento");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ProcessoPessoa", b =>
                {
                    b.Property<Guid>("PessoaId");

                    b.Property<Guid>("ProcessoId");

                    b.Property<Guid>("TipoRelacaoId");

                    b.HasKey("PessoaId", "ProcessoId", "TipoRelacaoId");

                    b.HasIndex("ProcessoId");

                    b.HasIndex("TipoRelacaoId");

                    b.ToTable("ProcessoPessoa");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.TipoPedido", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.Property<int>("JusticaId");

                    b.HasKey("Id");

                    b.HasIndex("JusticaId");

                    b.ToTable("TipoPedido");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.GrupoAndamento", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("GrupoAndamento");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.Justica", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.Property<string>("DescricaoReduzida");

                    b.HasKey("Id");

                    b.ToTable("Justica");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.Orgao", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.Property<string>("DescricaoReduzida");

                    b.Property<int>("JusticaId");

                    b.HasKey("Id");

                    b.HasIndex("JusticaId");

                    b.ToTable("Orgao");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.ResultadoPedido", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("ResultadoPedido");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.Risco", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Risco");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoAcao", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.Property<int>("OrgaoId");

                    b.HasKey("Id");

                    b.HasIndex("OrgaoId");

                    b.ToTable("TipoAcao");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoAndamento", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.Property<Guid>("GrupoId");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("TipoAndamento");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoRelacao", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TipoRelacao");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Common.Entitties.Forum", b =>
                {
                    b.OwnsOne("PGLaw.Domain.Juridico.Enderecos.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ForumId");

                            b1.Property<string>("Bairro")
                                .HasColumnName("Bairro")
                                .HasMaxLength(125);

                            b1.Property<string>("Cep")
                                .HasColumnName("Cep")
                                .HasMaxLength(10);

                            b1.Property<int>("CidadeId")
                                .HasColumnName("CidadeId");

                            b1.Property<string>("Complemento")
                                .HasColumnName("Complemento")
                                .HasMaxLength(125);

                            b1.Property<string>("Logradouro")
                                .HasColumnName("Logradouro")
                                .HasMaxLength(125);

                            b1.Property<string>("Numero")
                                .HasColumnName("Numero")
                                .HasMaxLength(15);

                            b1.HasIndex("CidadeId");

                            b1.ToTable("Forum");

                            b1.HasOne("PGLaw.Domain.Juridico.Enderecos.Entitties.Cidade", "Cidade")
                                .WithMany()
                                .HasForeignKey("CidadeId")
                                .OnDelete(DeleteBehavior.Restrict);

                            b1.HasOne("PGLaw.Domain.Juridico.Common.Entitties.Forum")
                                .WithOne("Endereco")
                                .HasForeignKey("PGLaw.Domain.Juridico.Enderecos.ValueObjects.Endereco", "ForumId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Enderecos.Entitties.Cidade", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Enderecos.Entitties.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", b =>
                {
                    b.OwnsOne("PGLaw.Domain.Juridico.Pessoas.Entities.DadosPessoaFisica", "DadosPessoaFisica", b1 =>
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

                            b1.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa")
                                .WithOne("DadosPessoaFisica")
                                .HasForeignKey("PGLaw.Domain.Juridico.Pessoas.Entities.DadosPessoaFisica", "PessoaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("PGLaw.Domain.Juridico.Pessoas.Entities.DadosPessoaJuridica", "DadosPessoaJuridica", b1 =>
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

                            b1.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa")
                                .WithOne("DadosPessoaJuridica")
                                .HasForeignKey("PGLaw.Domain.Juridico.Pessoas.Entities.DadosPessoaJuridica", "PessoaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships.PessoaCliente", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithMany("PessoaCliente")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", "Pessoa")
                        .WithMany("PessoaCliente")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Andamento", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.Processo", "Processo")
                        .WithMany("Andamentos")
                        .HasForeignKey("ProcessoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoAndamento", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.AreaOfensora", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.FamiliaOfensora", "FamiliaOfensora")
                        .WithMany("AreasOfensoras")
                        .HasForeignKey("FamiliaOfensoraId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Pedido", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.CausaRealPedido", "CausaReal")
                        .WithMany()
                        .HasForeignKey("CausaRealId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.Processo", "Processo")
                        .WithMany("Pedidos")
                        .HasForeignKey("ProcessoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.ResultadoPedido", "Resultado")
                        .WithMany()
                        .HasForeignKey("ResultadoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.Risco", "Risco")
                        .WithMany()
                        .HasForeignKey("RiscoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.TipoPedido", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Processo", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.AreaOfensora", "AreaOfensora")
                        .WithMany()
                        .HasForeignKey("AreaOfensoraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.CausaReal", "CausaReal")
                        .WithMany()
                        .HasForeignKey("CausaRealId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Enderecos.Entitties.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithMany("Processos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.FamiliaOfensora", "FamiliaOfensora")
                        .WithMany()
                        .HasForeignKey("FamiliaOfensoraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Common.Entitties.Forum", "Forum")
                        .WithMany()
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.Justica", "Justica")
                        .WithMany()
                        .HasForeignKey("JusticaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.MotivoAcionamento", "MotivoAcionamento")
                        .WithMany()
                        .HasForeignKey("MotivoAcionamentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.Orgao", "Orgao")
                        .WithMany()
                        .HasForeignKey("OrgaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.Risco", "Risco")
                        .WithMany()
                        .HasForeignKey("RiscoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoAcao", "TipoAcao")
                        .WithMany()
                        .HasForeignKey("TipoAcaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ClienteAreaOfensora", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.AreaOfensora", "AreaOfensora")
                        .WithMany("ClienteAreaOfensora")
                        .HasForeignKey("AreaOfensoraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithMany("ClienteAreaOfensora")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ClienteCausaReal", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.CausaReal", "CausaReal")
                        .WithMany("ClienteCausaReal")
                        .HasForeignKey("CausaRealId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithMany("ClienteCausaReal")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ClienteMotivoAcionamento", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithMany("ClienteMotivoAcionamento")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.MotivoAcionamento", "MotivoAcionamento")
                        .WithMany("ClienteMotivoAcionamento")
                        .HasForeignKey("MotivoAcionamentoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ProcessoPessoa", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", "Pessoa")
                        .WithMany("ProcessoPessoa")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.Entitties.Processo", "Processo")
                        .WithMany("ProcessoPessoa")
                        .HasForeignKey("ProcessoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoRelacao", "TipoRelacao")
                        .WithMany()
                        .HasForeignKey("TipoRelacaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.TipoPedido", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.Justica", "Justica")
                        .WithMany()
                        .HasForeignKey("JusticaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.Orgao", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.Justica", "Justica")
                        .WithMany()
                        .HasForeignKey("JusticaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoAcao", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.Orgao", "Orgao")
                        .WithMany()
                        .HasForeignKey("OrgaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.ValueObjects.TipoAndamento", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Processos.ValueObjects.GrupoAndamento", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
