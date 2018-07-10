using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Sistema.EntityConfigs
{
    public class UsuarioConfig : EntityConfigBase<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Email)
                .HasMaxLength(256);
        }
    }
}
