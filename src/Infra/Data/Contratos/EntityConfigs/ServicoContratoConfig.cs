using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;
using PGLaw.Infra.Data.Base;
using System.Reflection.Emit;

namespace PGLaw.Infra.Data.Contratos.EntityConfigs
{
    public class ServicoContratoConfig : EntityConfigBase<ServicoContrato>
    {
        public override void Configure(EntityTypeBuilder<ServicoContrato> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Observacao).HasColumnType("nvarchar(max)");

            //builder.HasKey(pp => new { pp.ContratoId });

            HasOneWithManyCascade<Contrato>();
            HasOne<TipoServico>();
            HasOne<FormaPagamento>();

        }
    }
}
