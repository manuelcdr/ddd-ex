using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs.Relashionships
{
    public class PessoaClienteConfig : EntityConfigBase<PessoaCliente>
    {
        public override void Configure(EntityTypeBuilder<PessoaCliente> builder)
        {
            base.Configure(builder);
            ManyToManyAndKeys<Pessoa, Cliente>();
        }
    }
}
