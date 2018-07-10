using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Services;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Domain.Juridico.Processos.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Processos.Interfaces.Services;
using PGLaw.Domain.Juridico.Processos.Validations;
using PGLaw.Infra.Cross.Common.Enums;
using System;

namespace PGLaw.Domain.Juridico.Processos.Services
{
    public class CadastroProcessoServices : DomainServicesBase, ICadastroProcessoServices
    {
        private readonly ProcessoValidator processoValidator;
        private readonly IProcessosRepository processosRepository;
        private readonly IPessoasRepository pessoasRepository;

        public CadastroProcessoServices(
            ProcessoValidator processoValidator, 
            IProcessosRepository processosRepository, 
            IPessoasRepository pessoasRepository,
            IJuridicoGlobalRepository repository)
            : base(repository)
        {
            this.processoValidator = processoValidator;
            this.processosRepository = processosRepository;
            this.pessoasRepository = pessoasRepository;
        }

        public void CadastrarProcesso(Processo processo)
        {
            if (processoValidator.PodeCadastrar(processo))
            {
                Repository.Adicionar(processo);
            }
        }

        public void CadastrarPessoaNoProcesso(Guid processoId, Guid relacaoId, string nome, TipoPessoa tipo, string documento)
        {
            var pessoaExistente = pessoasRepository.ObterPessoaPorDocumento(documento);

            Guid? pessoaId = null;

            if (pessoaExistente != null)
            {
                pessoaId = pessoaExistente.Id;
                pessoaExistente.Nome = nome;
                Repository.Atualizar(pessoaExistente);
            }
            else
            {
                var pessoa = new Pessoa(nome, tipo, documento);
                pessoaId = pessoa.Id;
                Repository.Adicionar(pessoa);
            }

            var processoPessoa = new ProcessoPessoa(processoId, pessoaId.Value, relacaoId);
            Repository.Adicionar(processoPessoa);
        }

        public void CadastrarPedidoNoProcesso(Guid processoId, Guid tipoPedidoId, Guid riscoId, decimal valorPedido, decimal valorProvisao)
        {
            var pedido = new Pedido(processoId, tipoPedidoId, riscoId, valorPedido, valorProvisao);
            Repository.Adicionar(pedido);
        }
    }
}
