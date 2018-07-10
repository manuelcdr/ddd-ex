using PGLaw.Application.Juridico.Models;
using PGLaw.Application.Juridico.Models.Common;
using PGLaw.Application.Juridico.Models.Processos;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Juridico.Interfaces.Services
{
    public interface IProcessosAppServices : IAppServices
    {
        void CadastrarProcesso(PosCadastroProcessoVM model);

        ProcessoVM ObterProcesso(Guid pessoaId, Guid processoId);
        IEnumerable<ProcessoVM> BuscarProcessos(Guid pessoaId, string pesquisa);

        IEnumerable<TipoRelacaoVM> ObterTiposRelacoes();

        IEnumerable<JusticaVM> ObterJusticas();
        IEnumerable<OrgaoVM> ObterNaturezas(int JusticaId);
        IEnumerable<TipoAcaoVM> ObterTiposAcoes(int OrgaoId);

        IEnumerable<EstadoVM> ObterEstados();
        IEnumerable<CidadeVM> ObterCidades(int EstadoId);
        IEnumerable<ForumVM> ObterForuns(int CidadeId);

        IEnumerable<FamiliaOfensoraVM> ObterFamiliasOfensorasAtivas(Guid ClienteId);
        IEnumerable<AreaOfensoraVM> ObterAreasOfensorasAtivas(Guid ClienteId, Guid FamiliaOfensoraId);
        IEnumerable<MotivoAcionamentoVM> ObterMotivosAcionamentosAtivos(Guid ClienteId);
        IEnumerable<CausaRealVM> ObterCausasReaisAtivas(Guid ClienteId);
       
        IEnumerable<TipoPedidoVM> ObterTiposPedidosAtivos(int justicaId);
        IEnumerable<RiscoVM> ObterRiscos();
    }
}
