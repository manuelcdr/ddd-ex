﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PGLaw.Infra.Cross.Common.Enums;
using PGLaw.Infra.Data.Juridico.Context;
using System;

namespace PGLaw.Infra.Data.Juridico.Migrations
{
    [DbContext(typeof(JuridicoContext))]
    [Migration("20180327205751_PessoaUpdate10")]
    partial class PessoaUpdate10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Equipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255);

                    b.Property<string>("Nome")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.ToTable("Equipe");
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

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaFisica", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("CPF")
                        .HasMaxLength(125);

                    b.Property<string>("Celular")
                        .HasMaxLength(125);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("OrgaoEmissorRG")
                        .HasMaxLength(125);

                    b.Property<string>("RG")
                        .HasMaxLength(125);

                    b.Property<string>("TelefoneComercial")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaJuridica", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(125);

                    b.Property<string>("EmailFinanceiro")
                        .HasMaxLength(125);

                    b.Property<string>("InscricaoEstadual")
                        .HasMaxLength(125);

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(125);

                    b.Property<string>("inscricaoMunicipal")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships.EquipeCliente", b =>
                {
                    b.Property<Guid>("ClienteId");

                    b.Property<Guid>("EquipeId");

                    b.HasKey("ClienteId", "EquipeId");

                    b.HasIndex("EquipeId");

                    b.ToTable("EquipeCliente");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships.EquipePessoa", b =>
                {
                    b.Property<Guid>("PessoaId");

                    b.Property<Guid>("EquipeId");

                    b.HasKey("PessoaId", "EquipeId");

                    b.HasIndex("EquipeId");

                    b.ToTable("EquipePessoa");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Processo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<Guid>("EquipeId");

                    b.Property<int>("NumeroInstancia");

                    b.Property<int>("NumeroInterno");

                    b.Property<string>("NumeroPasta")
                        .HasMaxLength(125);

                    b.Property<string>("NumeroPrimeiraInstancia")
                        .HasMaxLength(125);

                    b.Property<string>("NumeroSegundaInstancia")
                        .HasMaxLength(125);

                    b.Property<string>("NumeroTerceiraInstancia")
                        .HasMaxLength(125);

                    b.Property<string>("Observacoes")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EquipeId");

                    b.ToTable("Processo");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Relashionships.ProcessoPessoa", b =>
                {
                    b.Property<Guid>("PessoaId");

                    b.Property<Guid>("ProcessoId");

                    b.Property<Guid>("TipoRelacaoId");

                    b.HasKey("PessoaId", "ProcessoId", "TipoRelacaoId");

                    b.HasIndex("ProcessoId");

                    b.ToTable("ProcessoPessoa");
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithOne("Pessoa")
                        .HasForeignKey("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", "Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaFisica", "DadosPessoaFisica")
                        .WithOne("Pessoa")
                        .HasForeignKey("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", "Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaJuridica", "DadosPessoaJuridica")
                        .WithOne("Pessoa")
                        .HasForeignKey("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", "Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaFisica", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithOne("DadosPessoaFisica")
                        .HasForeignKey("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaFisica", "Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaJuridica", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithOne("DadosPessoaJuridica")
                        .HasForeignKey("PGLaw.Domain.Juridico.Pessoas.Entities.PessoaJuridica", "Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships.EquipeCliente", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithMany("EquipesClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Equipe", "Equipe")
                        .WithMany("EquipesClientes")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships.EquipePessoa", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Equipe", "Equipe")
                        .WithMany("EquipesPessoas")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Pessoa", "Pessoa")
                        .WithMany("EquipePessoa")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PGLaw.Domain.Juridico.Processos.Entitties.Processo", b =>
                {
                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Cliente", "Cliente")
                        .WithMany("Processos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PGLaw.Domain.Juridico.Pessoas.Entities.Equipe", "Equipe")
                        .WithMany("Processos")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                });
#pragma warning restore 612, 618
        }
    }
}
