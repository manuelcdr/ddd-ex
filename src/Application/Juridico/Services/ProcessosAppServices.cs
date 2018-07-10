using System;
using System.Collections.Generic;
using AutoMapper;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Models;
using PGLaw.Application.Juridico.Models.Common;
using PGLaw.Application.Juridico.Models.Processos;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Enderecos.Entitties;
using PGLaw.Domain.Juridico.Enderecos.Interfaces;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Domain.Juridico.Processos.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Processos.Interfaces.Services;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Cross.Common.Enums;

namespace PGLaw.Application.Juridico.Services
{
    public class ProcessosAppServices : AppServiceBase, IProcessosAppServices
    {
        private readonly IPessoasRepositoryCQRS pessoasCQRS;
        private readonly IProcessosRepositoryCQRS processosCQRS;
        private readonly IEnderecosRepositoryCQRS enderecosRepositoryCQRS;
        private readonly ICadastroProcessoServices cadastroProcessoServices;

        public ProcessosAppServices(
            IJuridicoUnitOfWork uow, 
            IJuridicoCQRS repositoryRead, 
            IPessoasRepositoryCQRS pessoasCQRS,
            IProcessosRepositoryCQRS ProcessosCQRS,
            IEnderecosRepositoryCQRS enderecosRepositoryCQRS,
            ICadastroProcessoServices cadastroProcessoServices)     
            : base(uow, repositoryRead)
        {
            this.pessoasCQRS = pessoasCQRS;
            processosCQRS = ProcessosCQRS;
            this.enderecosRepositoryCQRS = enderecosRepositoryCQRS;
            this.cadastroProcessoServices = cadastroProcessoServices;
        }

        public IEnumerable<TipoRelacaoVM> ObterTiposRelacoes()
        {
            return ObterTodosAtivos<TipoRelacao, TipoRelacaoVM>();
        }

        public IEnumerable<ProcessoVM> BuscarProcessos(Guid pessoaId, string pesquisa)
        {
            var processos = processosCQRS.BuscarProcessos(pessoaId, pesquisa);
            var models = MapLista<ProcessoVM>(processos);
            return models;
        }

        public IEnumerable<JusticaVM> ObterJusticas()
        {
            return ObterTodosAtivos<Justica, JusticaVM>();
        }

        public IEnumerable<OrgaoVM> ObterNaturezas(int justicaId)
        {
            var entidades = RepositoryCQRS.Buscar<Orgao>(x => x.JusticaId == justicaId && x.Ativo);
            var models = MapLista<OrgaoVM>(entidades);
            return models;
        }

        public IEnumerable<TipoAcaoVM> ObterTiposAcoes(int orgaoId)
        {
            var entidades = RepositoryCQRS.Buscar<TipoAcao>(x => x.OrgaoId == orgaoId && x.Ativo);
            var models = MapLista<TipoAcaoVM>(entidades);
            return models;
        }

        public IEnumerable<EstadoVM> ObterEstados()
        {
            return ObterTodos<Estado, EstadoVM>();
        }

        public IEnumerable<CidadeVM> ObterCidades(int estadoId)
        {
            var entidades = enderecosRepositoryCQRS.ObterCidadesPorEstado(estadoId);
            var models = MapLista<CidadeVM>(entidades);
            return models;
        }

        public IEnumerable<ForumVM> ObterForuns(int cidadeId)
        {
            var entidades = processosCQRS.ObterForumPorCidade(cidadeId);
            var models = MapLista<ForumVM>(entidades);
            return models;
        }

        public IEnumerable<FamiliaOfensoraVM> ObterFamiliasOfensorasAtivas(Guid ClienteId)
        {
            var entidades = processosCQRS.ObterFamiliasOfensorasPorClienteAtivos(ClienteId);
            var models = MapLista<FamiliaOfensoraVM>(entidades);
            return models;
        }

        public IEnumerable<AreaOfensoraVM> ObterAreasOfensorasAtivas(Guid ClienteId, Guid FamiliaOfensoraId)
        {
            var entidades = processosCQRS.ObterAreasOfensorasPorClienteEFamiliaAtivos(ClienteId, FamiliaOfensoraId);
            var models = MapLista<AreaOfensoraVM>(entidades);
            return models;
        }

        public IEnumerable<MotivoAcionamentoVM> ObterMotivosAcionamentosAtivos(Guid ClienteId)
        {
            var entidades = processosCQRS.ObterMotivosAcionamentosPorClienteAtivos(ClienteId);
            var models = MapLista<MotivoAcionamentoVM>(entidades);
            return models;
        }

        public IEnumerable<CausaRealVM> ObterCausasReaisAtivas(Guid ClienteId)
        {
            var entidades = processosCQRS.ObterCausasReiasPorClienteAtivos(ClienteId);
            var models = MapLista<CausaRealVM>(entidades);
            return models;
        }

        public IEnumerable<RiscoVM> ObterRiscos()
        {
            return ObterTodos<Risco, RiscoVM>();
        }

        public ProcessoVM ObterProcesso(Guid pessoaId, Guid processoId)
        {
            var processo = processosCQRS.ObterProcessoCompleto(pessoaId, processoId);
            var model = Map<ProcessoVM>(processo);
            return model;
        }

        public IEnumerable<TipoPedidoVM> ObterTiposPedidosAtivos(int justicaId)
        {
            var entidades = processosCQRS.ObterTiposDePedidosAtivos(justicaId);
            var models = MapLista<TipoPedidoVM>(entidades);
            return models;
        }

        public void CadastrarProcesso(PosCadastroProcessoVM model)
        {
            var processo = Map<Processo>(model);

            cadastroProcessoServices.CadastrarProcesso(processo);

            foreach (var pedidoVM in model.ProcessoPedidos)
                cadastroProcessoServices
                    .CadastrarPedidoNoProcesso(
                    processo.Id,
                    pedidoVM.TipoId,
                    pedidoVM.RiscoId,
                    pedidoVM.ValorPedido,
                    pedidoVM.ValorProvisao);

            foreach (var pessoaVM in model.ProcessoPessoas)
                cadastroProcessoServices
                    .CadastrarPessoaNoProcesso(
                    processo.Id,
                    pessoaVM.TipoRelacaoId,
                    pessoaVM.Nome,
                    pessoaVM.TipoPessoa,
                    pessoaVM.Documento);
            
            SaveChanges();
        }
    }
}
