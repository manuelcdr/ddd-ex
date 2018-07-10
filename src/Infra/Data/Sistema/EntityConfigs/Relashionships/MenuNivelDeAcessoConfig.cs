using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Sistema.EntityConfigs
{
    public class MenuNivelDeAcessoConfig : EntityConfigBase<MenuNivelDeAcesso>
    {
        public override void Configure(EntityTypeBuilder<MenuNivelDeAcesso> builder)
        {
            base.Configure(builder);
            ManyToManyAndKeys<Menu, NivelDeAcesso>();
        }
    }
}
