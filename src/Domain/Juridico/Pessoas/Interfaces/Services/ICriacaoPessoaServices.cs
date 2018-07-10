using PGLaw.Domain.Juridico.Pessoas.Entities;

namespace PGLaw.Domain.Juridico.Pessoas.Interfaces.Services
{
    public interface IManterPessoasServices
    {
        void CriarPessoa(Pessoa pessoa);
        void CriarCliente(Cliente cliente);

        void AtualizarCliente(Cliente cliente);
        void AtualizarPessoa(Pessoa pessoa);
    }
}
