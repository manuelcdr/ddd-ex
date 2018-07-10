using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Common.Entitties;
using PGLaw.Domain.Juridico.Enderecos.Entitties;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class ProcessoConfig : EntityConfigBase<Processo>
    {
        public override void Configure(EntityTypeBuilder<Processo> builder)
        {
            base.Configure(builder);

            IsRequired(p => p.ClienteId);

            HasOneWithMany<Cliente>();
            HasOne<FamiliaOfensora>();
            HasOne<AreaOfensora>();
            HasOne<MotivoAcionamento>();
            HasOne<CausaReal>();
            HasOne<Justica>();
            HasOne<Orgao>();
            HasOne<TipoAcao>();
            HasOne<Forum>();
            HasOne<Cidade>();
            HasOne<Risco>();
        }
    }
}
