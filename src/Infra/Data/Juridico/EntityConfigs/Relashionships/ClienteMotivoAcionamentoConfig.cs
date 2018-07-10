using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs.Relashionships
{
    public class ClienteMotivoAcionamentoConfig : EntityConfigBase<ClienteMotivoAcionamento>
    {
        public override void Configure(EntityTypeBuilder<ClienteMotivoAcionamento> builder)
        {
            base.Configure(builder);
            ManyToManyAndKeys<Cliente, MotivoAcionamento>();
        }
    }
}
