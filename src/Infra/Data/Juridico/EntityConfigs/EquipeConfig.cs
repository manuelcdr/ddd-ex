using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class EquipeConfig : EntityConfigBase<Equipe>
    {
        public override void Configure(EntityTypeBuilder<Equipe> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Descricao)
                .HasMaxLength(255);
        }
    }
}
