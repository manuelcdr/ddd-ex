using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class PessoaConfig : EntityConfigBase<Pessoa>
    {
        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Nome)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.TipoPessoa)
                .IsRequired();

            builder.Ignore(p => p.DocumentoPrincipal);

            builder.OwnsOne(
                p => p.DadosPessoaFisica, 
                sa =>
                {
                    sa.Property(pf => pf.CPF)
                        .HasColumnName("CPF")
                        .HasMaxLength(11);

                    sa.Property(pf => pf.Celular)
                        .HasColumnName("Celular")
                        .HasMaxLength(125);

                    sa.Property(pf => pf.OrgaoEmissorRG)
                        .HasColumnName("OrgaoEmissorRG")
                        .HasMaxLength(125);

                    sa.Property(pf => pf.RG)
                        .HasColumnName("RG")
                        .HasMaxLength(125);

                    sa.Property(pf => pf.TelefoneComercial)
                        .HasColumnName("TelefoneComercial")
                        .HasMaxLength(125);

                    sa.Property(pf => pf.DataNascimento)
                        .HasColumnName("DataNascimento");

                    base.ConfigurarAutoValidador(sa);

                });

            builder.OwnsOne(
                p => p.DadosPessoaJuridica, 
                sa =>
                {
                    sa.Property(pf => pf.CNPJ)
                        .HasColumnName("CNPJ")
                        .HasMaxLength(15);

                    sa.Property(pf => pf.EmailFinanceiro)
                        .HasColumnName("EmailFinanceiro")
                        .HasMaxLength(125);

                    sa.Property(pf => pf.InscricaoEstadual)
                        .HasColumnName("InscricaoEstadual")
                        .HasMaxLength(125);

                    sa.Property(pf => pf.InscricaoMunicipal)
                        .HasColumnName("inscricaoMunicipal")
                        .HasMaxLength(125);

                    sa.Property(pf => pf.RazaoSocial)
                        .HasColumnName("RazaoSocial")
                        .HasMaxLength(125);

                    base.ConfigurarAutoValidador(sa);
                });
        }
    }
}
