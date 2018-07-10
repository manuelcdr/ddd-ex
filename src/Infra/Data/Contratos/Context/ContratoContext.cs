using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Contratos.Pessoas.Entitties;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Contratos.EntityConfigs;

namespace PGLaw.Infra.Data.Contratos.Context
{
    public class ContratoContext : DbContextBase
    {

        public ContratoContext() : base("ContratoConnection") { }

        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DocumentoContrato> DocumentosContrato { get; set; }
        public DbSet<ServicoContrato> ServicosContrato { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContratoConfig());

            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new PessoaConfig());

            modelBuilder.ApplyConfiguration(new GerenciaConfig());
            modelBuilder.ApplyConfiguration(new IndiceReajusteConfig());
            modelBuilder.ApplyConfiguration(new TipoConfig());
            modelBuilder.ApplyConfiguration(new VigenciaConfig());
            modelBuilder.ApplyConfiguration(new TipoServicoConfig());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfig());
            modelBuilder.ApplyConfiguration(new DocumentoContratoConfig());
            modelBuilder.ApplyConfiguration(new ServicoContratoConfig());

        }

    }
}
