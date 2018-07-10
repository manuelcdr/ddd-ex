using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Juridico.Common.Entitties;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Entities.Relashionships;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Domain.Juridico.Processos.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Juridico.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PGLaw.Infra.Data.Juridico.Repositories
{
    public class ProcessosRepository : RepositoryBase, IProcessosRepository
    {
        public ProcessosRepository(JuridicoContext context) : base(context)
        {
        }

        #region metodos privados

        private IEnumerable<Guid> ObterClienteIds(Guid pessoaId)
        {
            var clienteIds = Buscar<PessoaCliente>(x => x.PessoaId == pessoaId).Select(x => x.PessoaId);
            return clienteIds;
        }

        #endregion

        /// <summary>
        /// Busca apenas processos relacionados aos clientes da pessoa
        /// </summary>
        public IEnumerable<Processo> BuscarProcessos(Guid pessoaId, string pesquisa)
        {
            var clienteIds = ObterClienteIds(pessoaId);

            return Set<Processo>()
                .Include(p => p.Orgao)
                .Include(processo => processo.ProcessoPessoa)
                    .ThenInclude(processoPessoa => processoPessoa.Pessoa)
                .Include(processo => processo.ProcessoPessoa)
                    .ThenInclude(processoPessoa => processoPessoa.TipoRelacao)
                .Include(processo => processo.Cliente)
                    .ThenInclude(cliente => cliente.Pessoa)
                .Where(p =>
                    //clienteIds.Any(cId => cId == p.ClienteId) ||
                    // processo.NumeroInterno.ToString() == pesquisa ||
                    p.NumeroPrimeiraInstancia.ToLower().Contains(pesquisa) ||
                    p.NumeroSegundaInstancia.ToLower().Contains(pesquisa) ||
                    p.NumeroTerceiraInstancia.ToLower().Contains(pesquisa) ||
                    // processo.NumeroPasta == pesquisa ||
                    p.Cliente.Pessoa.Nome.ToLower().Contains(pesquisa) ||
                    p.ProcessoPessoa.Any(processoPessoa => processoPessoa.Pessoa.Nome.ToLower().Contains(pesquisa)));
        }

        public IEnumerable<Forum> ObterForumPorCidade(int cidadeId)
        {
            return Set<Forum>()
                .Where(f => f.Endereco.CidadeId == cidadeId)
                .AsNoTracking();
        }

        /// <summary>
        /// Obter Processo:
        /// - apenas relacionados aos clientes da pessoa
        /// </summary>
        public Processo ObterProcessoCompleto(Guid pessoaId, Guid id)
        {
            var clienteIds = ObterClienteIds(pessoaId);

            var processo = Set<Processo>()
                .Include(p => p.Cliente)
                    .ThenInclude(c => c.Pessoa)
                .Include(p => p.Orgao)
                .Include(p => p.Justica)
                .Include(p => p.Forum)
                .Include(p => p.FamiliaOfensora)
                .Include(p => p.AreaOfensora)
                .Include(p => p.CausaReal)
                .Include(p => p.Cidade)
                    .ThenInclude(c => c.Estado)
                .Include(p => p.Cliente)
                .Include(p => p.MotivoAcionamento)
                .Include(p => p.TipoAcao)
                .Include(p => p.Risco)

                .SingleOrDefault(
                    p => p.Id == id
                    //&& clienteIds.Any(cId => cId == p.ClienteId)
                );

            var pedidos = ObterPedidosDoProcesso(processo.Id);
            var pessoas = ObterPessoasDoProcesso(processo.Id);

            processo.Pedidos.AddRange(pedidos);
            processo.ProcessoPessoa.AddRange(pessoas);

            return processo;
        }

        public IEnumerable<FamiliaOfensora> ObterFamiliasOfensorasPorCliente(Guid clienteId)
        {
            var familias = Buscar<FamiliaOfensora>(x =>
                x.AreasOfensoras.Any(a =>
                    a.ClienteAreaOfensora.Any(ca =>
                        ca.ClienteId == clienteId)))
                .Distinct()
                .OrderBy(x => x.Descricao);

            return familias;
        }

        public IEnumerable<FamiliaOfensora> ObterFamiliasOfensorasPorClienteAtivos(Guid clienteId)
        {
            var familias = ObterFamiliasOfensorasPorCliente(clienteId)
                .Where(x => x.Ativo);

            return familias;
        }

        public IEnumerable<AreaOfensora> ObterAreasOfensorasPorClienteEFamilia(Guid clienteId, Guid familiaOfensoraId)
        {
            var areas = Buscar<AreaOfensora>(x =>
                    x.ClienteAreaOfensora.Any(ca => ca.ClienteId == clienteId) &&
                    x.FamiliaOfensoraId == familiaOfensoraId)
                .Distinct()
                .OrderBy(x => x.Descricao);

            return areas;
        }

        public IEnumerable<AreaOfensora> ObterAreasOfensorasPorClienteEFamiliaAtivos(Guid clienteId, Guid familiaOfensoraId)
        {
            var areas = ObterAreasOfensorasPorClienteEFamilia(clienteId, familiaOfensoraId)
                .Where(x => x.Ativo);

            return areas;
        }

        public IEnumerable<MotivoAcionamento> ObterMotivosAcionamentosPorClienteAtivos(Guid clienteId)
        {
            var motivos = BuscarAtivos<MotivoAcionamento>(x => x.ClienteMotivoAcionamento.Any(c => c.ClienteId == clienteId)).OrderBy(c => c.Descricao);
            return motivos;
        }

        public IEnumerable<CausaReal> ObterCausasReiasPorClienteAtivos(Guid clienteId)
        {
            var causas = BuscarAtivos<CausaReal>(x => x.ClienteCausaReal.Any(c => c.ClienteId == clienteId)).OrderBy(c => c.Descricao);
            return causas;
        }

        public IEnumerable<TipoPedido> ObterTiposDePedidosAtivos(int justicaId)
        {
            var tiposPedidos = BuscarAtivos<TipoPedido>(x => x.JusticaId == justicaId);
            return tiposPedidos;
        }

        public IEnumerable<ProcessoPessoa> ObterPessoasDoProcesso(Guid processoId)
        {
            return Set<ProcessoPessoa>()
                .Include(pp => pp.Pessoa)
                .Include(pp => pp.TipoRelacao)
                .Where(pp => pp.ProcessoId == processoId)
                .Distinct()
                .AsNoTracking();
        }

        public IEnumerable<Pedido> ObterPedidosDoProcesso(Guid processoId)
        {
            return Set<Pedido>()
                .Include(p => p.Resultado)
                .Include(p => p.CausaReal)
                .Include(p => p.Risco)
                .Include(p => p.Tipo)
                .Where(p => p.ProcessoId == processoId)
                .Distinct()
                .AsNoTracking();
        }
    }
}
