using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs.Relashionships
{
    public class EquipeClienteConfig : IEntityTypeConfiguration<EquipeCliente>
    {
        public void Configure(EntityTypeBuilder<EquipeCliente> builder)
        {
            builder.HasKey(ec => new { ec.ClienteId, ec.EquipeId });

            builder.HasOne(ec => ec.Cliente)
                .WithMany(c => c.EquipesClientes)
                .HasForeignKey(ec => ec.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ec => ec.Equipe)
                .WithMany(c => c.EquipesClientes)
                .HasForeignKey(ec => ec.EquipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
