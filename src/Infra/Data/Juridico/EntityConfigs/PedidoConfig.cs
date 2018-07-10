using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class PedidoConfig : EntityConfigBase<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);
            HasOneWithMany<Processo>();
            HasOne<TipoPedido>("Tipo");
            HasOne<ResultadoPedido>("Resultado");
            HasOne<Risco>();
            HasOne<CausaRealPedido>("CausaReal");
        }

    }
}
