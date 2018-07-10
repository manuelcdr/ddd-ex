
using AutoMapper;
using PGLaw.Application.Contratos.Interfaces.Services;
using PGLaw.Application.Contratos.Models.Contratos;
using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Repositories;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Services;
using PGLaw.Domain.Contratos.Pessoas.Interfaces.Repositories;
using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PGLaw.Application.Contratos.Services
{
    public class ContratosAppServices : AppServiceBase, IContratosAppServices
    {
        private readonly IPessoasRepositoryCQRS pessoasCQRS;
        private readonly IContratosRepositoryCQRS contratosCQRS;
        private readonly ICadastroContratoServices cadastroContratoServices;
        //private readonly IEnderecosRepositoryCQRS enderecosRepositoryCQRS;

        public ContratosAppServices(
            IContratoUnitOfWork uow,
            IContratoCQRS repositoryRead,
            IPessoasRepositoryCQRS pessoasCQRS,
            IContratosRepositoryCQRS contratosCQRS,
            //IEnderecosRepositoryCQRS enderecosRepositoryCQRS,
            ICadastroContratoServices cadastroContratoServices)
            : base(uow, repositoryRead)
        {
            this.pessoasCQRS = pessoasCQRS;
            this.contratosCQRS = contratosCQRS;
            //this.enderecosRepositoryCQRS = enderecosRepositoryCQRS;
            this.cadastroContratoServices = cadastroContratoServices;
        }

        public IEnumerable<ContratoVM> BuscarContratosCompleto()
        {
            var contratos = contratosCQRS.BuscarContratosCompleto();
            var models = Mapper.Map<IEnumerable<ContratoVM>>(contratos);
            return models;
        }

        public IEnumerable<ContratoVM> BuscarContratosCompleto(Guid pessoaId)
        {
            var contratos = contratosCQRS.BuscarContratosCompleto(pessoaId);
            var models = Mapper.Map<IEnumerable<ContratoVM>>(contratos);
            return models;
        }


        public IEnumerable<ContratoVM> BuscarContratosPorStatus(string status)
        {
            var contratos = contratosCQRS.BuscarContratos();
            var models = Mapper.Map<IEnumerable<ContratoVM>>(contratos).Where(c => c.StatusContrato == status);
            return models;
        }

        public ContratoVM ObterContrato(Guid id)
        {
            var contrato = contratosCQRS.ObterContrato(id);
            var model = Mapper.Map<ContratoVM>(contrato);
            return model;
        }

        public IEnumerable<TipoVM> BuscarTipos()
        {
            var tipos = contratosCQRS.BuscarTipos();
            var models = Mapper.Map<IEnumerable<TipoVM>>(tipos);
            return models;
        }

        public IEnumerable<GerenciaVM> BuscarGerencias()
        {
            var gerencia = contratosCQRS.BuscarGerencias();
            var models = Mapper.Map<IEnumerable<GerenciaVM>>(gerencia);
            return models;
        }

        public IEnumerable<IndiceReajusteVM> BuscarIndicesReajuste()
        {
            var indice = contratosCQRS.BuscarIndicesReajuste();
            var models = Mapper.Map<IEnumerable<IndiceReajusteVM>>(indice);
            return models;
        }

        public IEnumerable<VigenciaVM> BuscarVigencias()
        {
            var vigencia = contratosCQRS.BuscarVigencias();
            var models = Mapper.Map<IEnumerable<VigenciaVM>>(vigencia);
            return models;
        }

        public IEnumerable<FormaPagamentoVM> BuscarFormasPagamento()
        {
            var FormasPagamento = contratosCQRS.BuscarFormasPagamento();
            var models = Mapper.Map<IEnumerable<FormaPagamentoVM>>(FormasPagamento);
            return models;
        }

        public IEnumerable<TipoServicoVM> BuscarTiposServicos()
        {
            var TiposServicos = contratosCQRS.BuscarTiposServicos();
            var models = Mapper.Map<IEnumerable<TipoServicoVM>>(TiposServicos);
            return models;
        }

        //public string BuscarPorStatus(string status)
        //{
        //    var TiposServicos = contratosCQRS.BuscarTiposServicos();
        //    var models = Mapper.Map<IEnumerable<TipoServicoVM>>(TiposServicos);
        //    return models;
        //}

        public void ConfigurarDocoumentoContratoNomeArquivo(ref DocumentoContratoVM model)
        {
            if (model != null)
            {

                if (model.Id == Guid.Empty)
                {
                    Guid DocumentoGuid = SequentialGuidGenerator.Generate();
                    model.Id = DocumentoGuid;
                    model.NomeArquivo = DocumentoGuid.ToString();

                }
            }
        }

        public void AtualizaContrato(ContratoVM model)
        {
            if (model.ServicoContratos != null)
            {
                foreach (var servicocontratoVM in model.ServicoContratos)
                {
                    if (servicocontratoVM.Id == Guid.Empty)
                    {
                        servicocontratoVM.Id = SequentialGuidGenerator.Generate();
                        cadastroContratoServices
                            .CadastrarServicoNoContrato(
                            servicocontratoVM.Id,
                            model.Id,
                            servicocontratoVM.TipoServicoId,
                            servicocontratoVM.FormaPagamentoId,
                            servicocontratoVM.Valor,
                            servicocontratoVM.Observacao);
                    }
                }
            }

            if (model.DocumentoContratos != null)
            {
                foreach (var documentocontratoVM in model.DocumentoContratos)
                {

                    //if (documentocontratoVM.Id == Guid.Empty)
                    //{
                        //Guid DocumentoGuid = SequentialGuidGenerator.Generate();
                        //documentocontratoVM.Id = DocumentoGuid;
                        //documentocontratoVM.NomeArquivo = DocumentoGuid.ToString();
                        cadastroContratoServices
                            .CadastrarDocumentoNoContrato(
                            documentocontratoVM.Id,
                            model.Id,
                            documentocontratoVM.NomeArquivo,
                            documentocontratoVM.NomeOriginal);
                    //}

                    //documentocontratoVM.Id = SequentialGuidGenerator.Generate();
                    //documentocontratoVM.ContratoId = model.Id;
                }
            }
            var contrato = Map<Contrato>(model);
            cadastroContratoServices.AtualizaContrato(contrato);

            SaveChanges();
        }

        public void CriarContrato(ContratoVM model)
        {
            model.Id = SequentialGuidGenerator.Generate();

            if (model.ServicoContratos != null)
            {
                foreach (var servicocontratoVM in model.ServicoContratos)
                {
                    servicocontratoVM.Id = SequentialGuidGenerator.Generate();
                    servicocontratoVM.ContratoId = model.Id;
                }
            }

            if (model.DocumentoContratos != null)
            {
                foreach (var documentocontratoVM in model.DocumentoContratos)
                {
                    //documentocontratoVM.Id = SequentialGuidGenerator.Generate();
                    documentocontratoVM.ContratoId = model.Id;
                }
            }
            var contrato = Map<Contrato>(model);
            cadastroContratoServices.CriarContrato(contrato);

            SaveChanges();
        }

        public void ExcluirContrato(Guid id)
        {
            var contrato = contratosCQRS.ObterContrato(id);            

            if(contrato.ServicoContratos != null)
            {
                foreach(ServicoContrato item in contrato.ServicoContratos)
                {
                    cadastroContratoServices.ExcluirServicoContrato(item.Id);
                    SaveChanges();
                }
            }

            if (contrato.DocumentoContratos != null)
            {
                foreach (DocumentoContrato item in contrato.DocumentoContratos)
                {
                    cadastroContratoServices.ExcluirDocumentoContrato(item.Id);
                    SaveChanges();
                }
            }

            cadastroContratoServices.ExcluirContrato(id);
            SaveChanges();
        }


    }
}