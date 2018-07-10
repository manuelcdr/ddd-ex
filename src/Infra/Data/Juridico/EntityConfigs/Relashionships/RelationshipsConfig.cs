using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Juridico.EntityConfigs.Relashionships
{
    public class ProcessoPessoaConfig : EntityConfigBase<ProcessoPessoa>
    {
        public override void Configure(EntityTypeBuilder<ProcessoPessoa> builder)
        {
            base.Configure(builder);
            builder.HasKey(pp => new { pp.PessoaId, pp.ProcessoId, pp.TipoRelacaoId });
            ManyToMany<Processo, Pessoa>();
            HasOne<TipoRelacao>();
        }
    }

    public class ClienteAreaOfensoraConfig      : RelashionshipEntityConfig<ClienteAreaOfensora, Cliente, AreaOfensora> { }
    public class ClienteCausaRealConfig         : RelashionshipEntityConfig<ClienteCausaReal, Cliente, CausaReal> { }
    public class ClienteMotivoAcionamentoConfig : RelashionshipEntityConfig<ClienteMotivoAcionamento, Cliente, MotivoAcionamento> { }
    public class PessoaClienteConfig            : RelashionshipEntityConfig<PessoaCliente, Pessoa, Cliente> { }
}
