using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Sistema.EntityConfigs
{
    public class MenuConfig : EntityConfigBase<Menu>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            base.Configure(builder);

            HasOneWithMany<Menu>("MenuPai", "MenusFilhos");

            builder.Property(m => m.CaminhoAcesso)
                .HasMaxLength(255);

            builder.Property(m => m.CaminhoAcessoIds)
                .HasMaxLength(255);

            builder.Ignore(m => m.Raiz);
            builder.Ignore(m => m.Ferramenta);
        }
    }
}
