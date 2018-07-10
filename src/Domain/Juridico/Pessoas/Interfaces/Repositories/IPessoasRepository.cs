using PGLaw.Domain.Juridico.Pessoas.Entities;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories
{
    public interface IPessoasRepository : IPessoasRepositoryCQRS
    {
    }

    public interface IPessoasRepositoryCQRS
    {
        Cliente ObterCliente(Guid id);
        IEnumerable<Cliente> ObterTodosClientes();
        IEnumerable<Pessoa> ObterPessoasPorId(params Guid[] ids);
        Pessoa ObterPessoaPorCPF(string cpf);
        Pessoa ObterPessoaPorCNPJ(string cnpj);
        Pessoa ObterPessoaPorDocumento(string documento);
    }
}
