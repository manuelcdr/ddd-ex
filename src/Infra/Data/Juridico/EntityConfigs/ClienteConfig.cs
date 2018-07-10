using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class ClienteConfig : EntityConfigBase<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);
            HasOne<Pessoa>("Pessoa", "Id");
        }
    }
}
