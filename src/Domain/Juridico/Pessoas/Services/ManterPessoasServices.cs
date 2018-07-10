using FluentValidation.Results;
using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Services;
using PGLaw.Domain.Juridico.Pessoas.Validations;

namespace PGLaw.Domain.Juridico.Pessoas.Services
{
    public class ManterPessoasServices : DomainServicesBase, IManterPessoasServices
    {
        private readonly IPessoasRepository pessoaRepository;
        private readonly PessoaValidator pessoaValidator;

        public ManterPessoasServices(
            IJuridicoGlobalRepository repository,
            IPessoasRepository pessoaRepository,
            PessoaValidator pessoaValidator)
            : base(repository)
        {
            this.pessoaRepository = pessoaRepository;
            this.pessoaValidator = pessoaValidator;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            if (cliente.EhValido() && pessoaValidator.PodeAtualizar(cliente.Pessoa))
            {
                Repository.AtualizarComReferencias(cliente);
                //Repository.Atualizar(cliente.Pessoa);
            }
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            if (pessoaValidator.PodeAtualizar(pessoa))
                Repository.Atualizar(pessoa);
        }

        public void CriarCliente(Cliente cliente)
        {
            if (cliente.EhValido() && pessoaValidator.PodeAdicionar(cliente.Pessoa))
                Repository.Adicionar(cliente);
        }

        public void CriarPessoa(Pessoa pessoa)
        {
            if (pessoaValidator.PodeAdicionar(pessoa))
            {
                Repository.Adicionar(pessoa);
            }
        }
    }
}
