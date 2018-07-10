using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs
{
    public class PessoaFisicaConfig : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {

        }
    }
}
