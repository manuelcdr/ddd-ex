using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Infra.Cross.Common.Enums;
using System;

namespace PGLaw.Domain.Juridico.Processos.Interfaces.Services
{
    public interface ICadastroProcessoServices
    {
        void CadastrarProcesso(Processo processo);
        void CadastrarPessoaNoProcesso(Guid processoId, Guid relacaoId, string nome, TipoPessoa tipo, string documento);
        void CadastrarPedidoNoProcesso(Guid processoId, Guid tipoPedido, Guid RiscoId, decimal valorPedido, decimal valorProvisao);
    }
}
