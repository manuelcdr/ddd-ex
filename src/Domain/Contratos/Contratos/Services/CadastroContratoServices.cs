using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using PGLaw.Domain.Contratos.Pessoas.Entitties;
using PGLaw.Domain.Contratos.Pessoas.Interfaces.Repositories;
using PGLaw.Domain.Contratos.Pessoas.Services;
using PGLaw.Domain.Contratos.Contratos.Entitties;
//using PGLaw.Domain.Contratos.Contratos.Entitties.Relashionships;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Repositories;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Services;
using PGLaw.Domain.Contratos.Contratos.Validations;
using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Domain.Contratos.Contratos.Services
{
    public class CadastroContratoServices : DomainServicesBase, ICadastroContratoServices
    {
        private readonly IContratosRepository contratosRepository;
        private readonly ContratoValidator contratoValidator;

        public CadastroContratoServices(
            ContratoValidator contratoValidator,
            IContratosRepository contratosRepository,
            IContratoGlobalRepository repository)
            : base(repository)
        {
            this.contratoValidator = contratoValidator;
            this.contratosRepository = contratosRepository;

        }

        public void CadastrarContrato(Contrato contrato)
        {
            if (contratoValidator.PodeCadastrar(contrato))
            {
                Repository.Adicionar(contrato);
            }
        }

        public void AtualizaContrato(Contrato contrato)
        {
            if (contratoValidator.PodeAtualizar(contrato))
                Repository.Atualizar(contrato);
        }

        public void CriarContrato(Contrato contrato)
        {
            if (contrato.EhValido())
                Repository.Adicionar(contrato);
        }

        public void ExcluirContrato(Guid id)
        {
                Repository.Excluir<Contrato>(id);
        }

        public void ExcluirServicoContrato(Guid id)
        {
            Repository.Excluir<ServicoContrato>(id);
        }

        public void ExcluirDocumentoContrato(Guid id)
        {
            Repository.Excluir<DocumentoContrato>(id);
        }

        public void CriarServicoContrato(ServicoContrato servicocontrato)
        {
            if (servicocontrato.EhValido())
                Repository.Adicionar(servicocontrato);
        }

        public void AtualizarServicoContrato(ServicoContrato servicocontrato)
        {
            if (servicocontrato.EhValido())
                Repository.Atualizar(servicocontrato);
        }

        public void CadastrarServicoNoContrato(Guid Id, Guid contratoId, Guid tiposervicoId, Guid formapagamentoId, decimal? valor, string observacao)
        {
            var servicocontrato = new ServicoContrato(Id, contratoId, tiposervicoId, formapagamentoId, valor, observacao);
            Repository.Adicionar(servicocontrato);
        }

        public void CadastrarDocumentoNoContrato(Guid Id, Guid contratoId, string nomearquivo, string nomeoriginal)
        {
            var documentoContrato = new DocumentoContrato(Id, contratoId, nomearquivo, nomeoriginal);
            Repository.Adicionar(documentoContrato);
        }
    }
}
