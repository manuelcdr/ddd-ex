using PGLaw.Domain.Contratos.Pessoas.Entitties;

namespace PGLaw.Domain.Contratos.Pessoas.Interfaces.Services
{
    public interface IManterPessoasServices
    {
        void CriarPessoa(Pessoa pessoa);
        void CriarCliente(Cliente cliente);

        void AtualizarCliente(Cliente cliente);
        void AtualizarPessoa(Pessoa pessoa);
    }
}