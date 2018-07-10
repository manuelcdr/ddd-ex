using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class PessoaJuridicaConfig : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
        }
    }
}
