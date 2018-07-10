using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Common.Entitties;
using PGLaw.Infra.Cross.Common.Configuration;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class ForumConfig : EntityConfigBase<Forum>
    {
        public override void Configure(EntityTypeBuilder<Forum> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(
                p => p.Endereco,
                sa =>
                {
                    sa.Property(pf => pf.Logradouro)
                        .HasColumnName("Logradouro")
                        .HasMaxLength(ParametrosDeConfiguracao.MaxLenght);

                    sa.Property(pf => pf.Numero)
                        .HasColumnName("Numero")
                        .HasMaxLength(15);

                    sa.Property(pf => pf.Bairro)
                        .HasColumnName("Bairro")
                        .HasMaxLength(ParametrosDeConfiguracao.MaxLenght);

                    sa.Property(pf => pf.Cep)
                        .HasColumnName("Cep")
                        .HasMaxLength(10);

                    sa.Property(x => x.CidadeId)
                    .HasColumnName("CidadeId");

                    sa.HasOne(pf => pf.Cidade)
                        .WithMany()
                        .HasForeignKey(x => x.CidadeId)
                        .OnDelete(DeleteBehavior.Restrict);

                    sa.Property(pf => pf.Complemento)
                        .HasColumnName("Complemento")
                        .HasMaxLength(ParametrosDeConfiguracao.MaxLenght);

                    base.ConfigurarAutoValidador(sa);
                });
        }
    }
}
