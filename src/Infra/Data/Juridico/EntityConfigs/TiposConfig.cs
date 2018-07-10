using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class AreaOfensoraConfig : EntityConfigBase<AreaOfensora>
    {
        public override void Configure(EntityTypeBuilder<AreaOfensora> builder)
        {
            base.Configure(builder);
            HasOneWithMany<FamiliaOfensora>(nomeCollection: "AreasOfensoras");
        }
    }

    public class OrgaoConfig : EntityConfigBase<Orgao>
    {
        public override void Configure(EntityTypeBuilder<Orgao> builder)
        {
            base.Configure(builder);

            HasOne<Justica>();
        }
    }

    public class TipoAcaoConfig : EntityConfigBase<TipoAcao>
    {
        public override void Configure(EntityTypeBuilder<TipoAcao> builder)
        {
            base.Configure(builder);
            HasOne<Orgao>();
        }
    }

    public class TipoPedidoConfig : EntityConfigBase<TipoPedido>
    {
        public override void Configure(EntityTypeBuilder<TipoPedido> builder)
        {
            base.Configure(builder);
            HasOne<Justica>();
        }
    }

    public class TipoAndamentoConfig : EntityConfigBase<TipoAndamento>
    {
        public override void Configure(EntityTypeBuilder<TipoAndamento> builder)
        {
            base.Configure(builder);
            HasOne<GrupoAndamento>("Grupo");
        }
    }

    public class TipoRelacaoConfig          : EntityConfigBase<TipoRelacao> { }
    public class RiscoConfig                : EntityConfigBase<Risco> { }
    public class ResultadoPedidoConfig      : EntityConfigBase<ResultadoPedido> { }
    public class CausaRealPedidoConfig      : EntityConfigBase<CausaRealPedido> { }
    public class CausaRealConfig            : EntityConfigBase<CausaReal> { }
    public class FamiliaOfensoraConfig      : EntityConfigBase<FamiliaOfensora> { }
    public class MotivoAcionamentoConfig    : EntityConfigBase<MotivoAcionamento> { }
    public class JusticaConfig              : EntityConfigBase<Justica> { }
    public class GrupoAndamentoConfig       : EntityConfigBase<GrupoAndamento> { }
}
