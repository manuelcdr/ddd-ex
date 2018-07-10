using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Core.Interfaces.Entities;
//using PGLaw.Domain.Contratos.Common.Entities;
using PGLaw.Domain.Contratos.Pessoas.Entitties.Relashionships;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.Interfaces.Repositories;
using PGLaw.Infra.Data.Base;
using PGLaw.Infra.Data.Contratos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;

namespace PGLaw.Infra.Data.Contratos.Repositories
{
    public class ContratosRepository : RepositoryBase, IContratosRepository
    {
        public ContratosRepository(ContratoContext context) : base(context)
        {
        }

        #region metodos privados
        private IEnumerable<Guid> ObterClienteIds(Guid pessoaId)
        {
            var clienteIds = Buscar<PessoaCliente>(x => x.PessoaId == pessoaId).Select(x => x.PessoaId);
            return clienteIds;
        }
        #endregion

        public IEnumerable<Contrato> BuscarContratosCompleto()
        {
            return Set<Contrato>()
                .Include(Contrato => Contrato.Tipo)
                .Include(Contrato => Contrato.Gerencia)
                .Include(Contrato => Contrato.Vigencia)
                .Include(Contrato => Contrato.IndiceReajuste)
                .Include(Contrato => Contrato.DocumentoContratos);
        }



        public IEnumerable<Contrato> BuscarContratosCompleto(Guid pessoaId)
        {

            return Set<Contrato>()
                .Include(Contrato => Contrato.Tipo)
                .Include(Contrato => Contrato.Gerencia)
                .Include(Contrato => Contrato.Vigencia)
                .Include(Contrato => Contrato.IndiceReajuste)
                .Where(contrato => contrato.ClienteId == pessoaId);
        }

        public IEnumerable<Contrato> BuscarContratos()
        {
            return Set<Contrato>();
        }

        public IEnumerable<Contrato> BuscarContratos(Guid pessoaId)
        {
            return Set<Contrato>()
                .Where(contrato => contrato.ClienteId == pessoaId);
        }

        public Contrato ObterContrato(Guid id)
        {
            var contrato = Set<Contrato>()
                .Include(ct => ct.Tipo)
                .Include(ct => ct.Gerencia)
                .Include(ct => ct.Vigencia)
                .Include(ct => ct.IndiceReajuste)
                .Where(ct => ct.Id == id).SingleOrDefault();

            var Servicos = ObterServicosDoContrato(contrato.Id);
            var Documentos = ObterDocumentosDoContrato(contrato.Id);

            contrato.ServicoContratos.AddRange(Servicos);
            contrato.DocumentoContratos.AddRange(Documentos);

            return contrato;
        }

        public IEnumerable<Tipo> BuscarTipos()
        {
            return Set<Tipo>();
        }

        public IEnumerable<Gerencia> BuscarGerencias()
        {
            return Set<Gerencia>();
        }

        public IEnumerable<IndiceReajuste> BuscarIndicesReajuste()
        {
            return Set<IndiceReajuste>();
        }

        public IEnumerable<Vigencia> BuscarVigencias()
        {
            return Set<Vigencia>();
        }

        public IEnumerable<FormaPagamento> BuscarFormasPagamento()
        {
            return Set<FormaPagamento>();
        }

        public IEnumerable<TipoServico> BuscarTiposServicos()
        {
            return Set<TipoServico>();
        }

        //public BuscarPorStatus(string status)
        //{
        //    return Set<Contrato>()
        //    .Where(p => p.StatusId == contratoId)
        //    .Distinct()
        //    .AsNoTracking();
        //}

        public IEnumerable<ServicoContrato> ObterServicosDoContrato(Guid contratoId)
        {
            return Set<ServicoContrato>()
                .Include(p => p.TipoServico)
                .Include(p => p.FormaPagamento)
                .Where(p => p.ContratoId == contratoId)
                .Distinct()
                .AsNoTracking();
        }

        public IEnumerable<DocumentoContrato> ObterDocumentosDoContrato(Guid contratoId)
        {
            return Set<DocumentoContrato>()                
                .Where(p => p.ContratoId == contratoId)
                .Distinct()
                .AsNoTracking();
        }

    }
}