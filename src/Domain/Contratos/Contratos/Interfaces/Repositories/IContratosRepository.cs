using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using System;
using System.Collections.Generic;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;

namespace PGLaw.Domain.Contratos.Contratos.Interfaces.Repositories
{

    public interface IContratosRepository : IContratosRepositoryCQRS
    {

    }

    public interface IContratosRepositoryCQRS
    {
        Contrato ObterContrato(Guid id);
        IEnumerable<Contrato> BuscarContratosCompleto();
        IEnumerable<Contrato> BuscarContratosCompleto(Guid pessoaId);

        IEnumerable<Contrato> BuscarContratos();
        IEnumerable<Contrato> BuscarContratos(Guid pessoaId);

        IEnumerable<Tipo> BuscarTipos();
        IEnumerable<Gerencia> BuscarGerencias();
        IEnumerable<IndiceReajuste> BuscarIndicesReajuste();
        IEnumerable<Vigencia> BuscarVigencias();
        IEnumerable<FormaPagamento> BuscarFormasPagamento();
        IEnumerable<TipoServico> BuscarTiposServicos();
        //string BuscarPorStatus();



    }
}
