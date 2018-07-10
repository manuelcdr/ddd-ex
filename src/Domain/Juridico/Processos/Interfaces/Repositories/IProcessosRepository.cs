using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Juridico.Common.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Processos.Interfaces.Repositories
{
    public interface IProcessosRepository : IProcessosRepositoryCQRS
    {

    }

    public interface IProcessosRepositoryCQRS
    {
        Processo ObterProcessoCompleto(Guid pessoaId, Guid id);
        IEnumerable<Processo> BuscarProcessos(Guid pessoaId, string pesquisa);
        IEnumerable<Forum> ObterForumPorCidade(int cidadeId);

        IEnumerable<FamiliaOfensora> ObterFamiliasOfensorasPorClienteAtivos(Guid clienteId);
        IEnumerable<AreaOfensora> ObterAreasOfensorasPorClienteEFamiliaAtivos(Guid clienteId, Guid familiaOfensoraId);
        IEnumerable<MotivoAcionamento> ObterMotivosAcionamentosPorClienteAtivos(Guid clienteId);
        IEnumerable<CausaReal> ObterCausasReiasPorClienteAtivos(Guid clienteId);
        IEnumerable<TipoPedido> ObterTiposDePedidosAtivos(int justicaId);
        IEnumerable<ProcessoPessoa> ObterPessoasDoProcesso(Guid processoId);
        IEnumerable<Pedido> ObterPedidosDoProcesso(Guid processoId);
    }
}
