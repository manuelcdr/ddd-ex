using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class AndamentoConfig : EntityConfigBase<Andamento>
    {
        public override void Configure(EntityTypeBuilder<Andamento> builder)
        {
            base.Configure(builder);

            HasOneWithMany<Processo>();
            HasOne<TipoAndamento>("Tipo");
        }
    }
}
