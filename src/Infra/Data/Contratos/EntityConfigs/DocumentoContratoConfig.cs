using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Contratos.EntityConfigs
{
    public class DocumentoContratoConfig : EntityConfigBase<DocumentoContrato>
    {
        public override void Configure(EntityTypeBuilder<DocumentoContrato> builder)
        {
            base.Configure(builder);
            //builder.HasKey(pp => new { pp.ContratoId});
            HasOneWithManyCascade<Contrato>();

            //ManyToMany<Contrato, DocumentoContrato>();

        }
    }
}
