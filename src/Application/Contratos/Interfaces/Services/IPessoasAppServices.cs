using PGLaw.Application.Contratos.Models.Pessoas;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Contratos.Interfaces.Services
{
    public interface IPessoasAppServices
    {
        IEnumerable<ClienteVM> ObterTodosClientes();
        ClienteVM ObterCliente(Guid id);

        ClientePessoaFisicaVM ObterClientePessoaFisica(Guid id);
        ClientePessoaJuridicaVM ObterClientePessoaJuridica(Guid id);

        void CriarPessoa(PessoaVM model);

        void CriarCliente(ClienteVM model);

        void CriarClientePessoaFisica(ClientePessoaFisicaVM model);
        void CriarClientePessoaJuridica(ClientePessoaJuridicaVM model);

        void AtualizarCliente(ClienteVM model);
        void AtualizarClientePessoaFisica(ClientePessoaFisicaVM model);
        void AtualizarClientePessoaJuridica(ClientePessoaJuridicaVM model);
    }
}
