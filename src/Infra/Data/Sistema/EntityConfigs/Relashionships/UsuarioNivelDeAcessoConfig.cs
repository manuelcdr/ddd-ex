using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Sistema.EntityConfigs
{
    public class UsuarioNivelDeAcessoConfig : EntityConfigBase<UsuarioNivelDeAcesso>
    {
        public override void Configure(EntityTypeBuilder<UsuarioNivelDeAcesso> builder)
        {
            base.Configure(builder);
            ManyToManyAndKeys<Usuario, NivelDeAcesso>();
        }
    }
}
