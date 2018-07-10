using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Juridico.EntityConfigs;
using PGLaw.Infra.Data.Juridico.EntityConfigs.Relashionships;

namespace PGLaw.Infra.Data.Juridico.Context
{
    public class JuridicoContext : DbContextBase
    {
        public JuridicoContext() : base("JuridicoConnection") { }

        public DbSet<Processo> Processos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProcessoConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            modelBuilder.ApplyConfiguration(new AreaOfensoraConfig());
            modelBuilder.ApplyConfiguration(new FamiliaOfensoraConfig());
            modelBuilder.ApplyConfiguration(new CausaRealConfig());
            modelBuilder.ApplyConfiguration(new MotivoAcionamentoConfig());
            modelBuilder.ApplyConfiguration(new JusticaConfig());
            modelBuilder.ApplyConfiguration(new OrgaoConfig());
            modelBuilder.ApplyConfiguration(new TipoAcaoConfig());
            modelBuilder.ApplyConfiguration(new ProcessoPessoaConfig());
            modelBuilder.ApplyConfiguration(new ForumConfig());
            modelBuilder.ApplyConfiguration(new TipoRelacaoConfig());
            modelBuilder.ApplyConfiguration(new GrupoAndamentoConfig());
            modelBuilder.ApplyConfiguration(new TipoAndamentoConfig());

            modelBuilder.ApplyConfiguration(new ClienteAreaOfensoraConfig());
            modelBuilder.ApplyConfiguration(new ClienteCausaRealConfig());
            modelBuilder.ApplyConfiguration(new ClienteMotivoAcionamentoConfig());
            modelBuilder.ApplyConfiguration(new PessoaClienteConfig());
            
            modelBuilder.ApplyConfiguration(new PedidoConfig());
            modelBuilder.ApplyConfiguration(new TipoPedidoConfig());
            modelBuilder.ApplyConfiguration(new RiscoConfig());
            modelBuilder.ApplyConfiguration(new ResultadoPedidoConfig());
            modelBuilder.ApplyConfiguration(new CausaRealPedidoConfig());
            ModelBuilder.ApplyConfiguration(new AndamentoConfig());
        }

    }
}
