﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PGLaw.Infra.Cross.Common.Enums;
using PGLaw.Infra.Data.Sistema.Context;
using System;

namespace PGLaw.Infra.Data.Sistema.Migrations
{
    [DbContext(typeof(SistemaContext))]
    [Migration("20180326181243_atualizaTabelaMenu2")]
    partial class atualizaTabelaMenu2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoAcesso")
                        .HasMaxLength(255);

                    b.Property<string>("CaminhoAcessoIds")
                        .HasMaxLength(255);

                    b.Property<Guid?>("MenuPaiId");

                    b.Property<int>("Ordem");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("MenuPaiId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.NivelDeAcesso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalhes")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("NivelDeAcesso");
                });

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.Relashionships.MenuNivelDeAcesso", b =>
                {
                    b.Property<Guid>("MenuId");

                    b.Property<Guid>("NivelDeAcessoId");

                    b.HasKey("MenuId", "NivelDeAcessoId");

                    b.HasIndex("NivelDeAcessoId");

                    b.ToTable("MenuNivelDeAcesso");
                });

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.Relashionships.UsuarioNivelDeAcesso", b =>
                {
                    b.Property<Guid>("UsuarioId");

                    b.Property<Guid>("NivelDeAcessoId");

                    b.HasKey("UsuarioId", "NivelDeAcessoId");

                    b.HasIndex("NivelDeAcessoId");

                    b.ToTable("UsuarioNivelDeAcesso");
                });

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AcessoDiasDaSemana");

                    b.Property<bool>("Ativo");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("TrocarSenha");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.Menu", b =>
                {
                    b.HasOne("PGLaw.Domain.Sistema.Entitties.Menu", "MenuPai")
                        .WithMany("MenusFilhos")
                        .HasForeignKey("MenuPaiId");
                });

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.Relashionships.MenuNivelDeAcesso", b =>
                {
                    b.HasOne("PGLaw.Domain.Sistema.Entitties.Menu", "Menu")
                        .WithMany("MenuNivelDeAcesso")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PGLaw.Domain.Sistema.Entitties.NivelDeAcesso", "NivelDeAcesso")
                        .WithMany("MenuNivelDeAcesso")
                        .HasForeignKey("NivelDeAcessoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PGLaw.Domain.Sistema.Entitties.Relashionships.UsuarioNivelDeAcesso", b =>
                {
                    b.HasOne("PGLaw.Domain.Sistema.Entitties.NivelDeAcesso", "NivelDeAcesso")
                        .WithMany("UsuarioNivelDeAcesso")
                        .HasForeignKey("NivelDeAcessoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PGLaw.Domain.Sistema.Entitties.Usuario", "Usuario")
                        .WithMany("UsuarioNiveiDeAcesso")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
