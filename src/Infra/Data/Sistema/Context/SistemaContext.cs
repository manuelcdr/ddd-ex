using Microsoft.EntityFrameworkCore;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Sistema.EntityConfigs;

namespace PGLaw.Infra.Data.Sistema.Context
{
    public class SistemaContext : DbContextBase
    {
        public SistemaContext()
            : base("DefaultConnection") { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MenuConfig());
            modelBuilder.ApplyConfiguration(new NivelDeAcessoConfig());
            modelBuilder.ApplyConfiguration(new MenuNivelDeAcessoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioNivelDeAcessoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
        }
    }
}
