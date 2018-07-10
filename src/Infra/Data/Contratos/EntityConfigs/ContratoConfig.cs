using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;
using PGLaw.Infra.Data.Base;


namespace PGLaw.Infra.Data.Contratos.EntityConfigs
{
    public class ContratoConfig : EntityConfigBase<Contrato>
    {
        public override void Configure(EntityTypeBuilder<Contrato> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Objeto).HasColumnType("nvarchar(max)");

            HasOne<Tipo>();
            HasOne<Gerencia>();
            HasOne<IndiceReajuste>();
            HasOne<Vigencia>();
            
            //HasOneWithMany<DocumentoContrato>();
            //HasOneWithMany<ServicoContrato>();
        }
    }
}
