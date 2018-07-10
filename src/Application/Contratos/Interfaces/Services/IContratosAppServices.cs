using PGLaw.Application.Contratos.Models;
using PGLaw.Application.Contratos.Models.Common;
using PGLaw.Application.Contratos.Models.Contratos;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Contratos.Interfaces.Services
{
    public interface IContratosAppServices
    {
        //void CadastrarContrato(ContratoVM model);

        ContratoVM ObterContrato(Guid id);

        IEnumerable<ContratoVM> BuscarContratosCompleto();
        IEnumerable<ContratoVM> BuscarContratosCompleto(Guid pessoaId);

        IEnumerable<ContratoVM> BuscarContratosPorStatus(string status);
        
        IEnumerable<TipoVM> BuscarTipos();
        IEnumerable<GerenciaVM> BuscarGerencias();
        IEnumerable<IndiceReajusteVM> BuscarIndicesReajuste();
        IEnumerable<VigenciaVM> BuscarVigencias();
        IEnumerable<FormaPagamentoVM> BuscarFormasPagamento();
        IEnumerable<TipoServicoVM> BuscarTiposServicos();
        //string BuscarPorStatus(string status);

        void ConfigurarDocoumentoContratoNomeArquivo(ref DocumentoContratoVM model);

        void AtualizaContrato(ContratoVM model);
        void CriarContrato(ContratoVM model);

        void ExcluirContrato(Guid id);



    }
}
