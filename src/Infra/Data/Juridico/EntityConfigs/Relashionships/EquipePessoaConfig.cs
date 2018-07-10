using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs.Relashionships
{
    public class EquipePessoaConfig : IEntityTypeConfiguration<EquipePessoa>
    {
        public void Configure(EntityTypeBuilder<EquipePessoa> builder)
        {
            builder.HasKey(ep => new { ep.PessoaId, ep.EquipeId });

            builder.HasOne(ep => ep.Equipe)
                .WithMany(e => e.EquipesPessoas)
                .HasForeignKey(ep => ep.EquipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ep => ep.Pessoa)
                .WithMany(p => p.EquipePessoa)
                .HasForeignKey(ep => ep.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
