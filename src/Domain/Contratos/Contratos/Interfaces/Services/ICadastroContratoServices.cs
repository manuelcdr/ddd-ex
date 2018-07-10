using PGLaw.Domain.Contratos.Contratos.Entitties;
//using PGLaw.Domain.Contratos.Contratos.Entitties.Relashionships;
using PGLaw.Infra.Cross.Common.Enums;
using System;

namespace PGLaw.Domain.Contratos.Contratos.Interfaces.Services
{

    public interface ICadastroContratoServices
    {
        void CriarContrato(Contrato contrato);
        void AtualizaContrato(Contrato contrato);
        void ExcluirContrato(Guid id);
        void ExcluirServicoContrato(Guid id);
        void ExcluirDocumentoContrato(Guid id);
        
        void CriarServicoContrato(ServicoContrato servicocontrato);
        void AtualizarServicoContrato(ServicoContrato servicocontrato);
        void CadastrarServicoNoContrato(Guid Id, Guid contratoId, Guid tiposervicoId, Guid formapagamentoId, decimal? valor, string observacao);
        void CadastrarDocumentoNoContrato(Guid Id, Guid contratoId, string nomearquivo, string nomeoriginal);

    }
}
