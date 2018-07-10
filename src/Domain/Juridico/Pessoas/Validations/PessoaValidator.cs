using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Pessoas.Interfaces.Repositories;

namespace PGLaw.Domain.Juridico.Pessoas.Validations
{
    public class PessoaValidator
    {
        private readonly IJuridicoGlobalRepository juridicoRepository;
        private readonly IPessoasRepository pessoaRepository;

        public PessoaValidator(IJuridicoGlobalRepository juridicoRepository, IPessoasRepository pessoaRepository)
        {
            this.juridicoRepository = juridicoRepository;
            this.pessoaRepository = pessoaRepository;
        }

        public bool PodeAdicionar(Pessoa pessoa)
        {
            if (!pessoa.EhValido())
                return false;

            if (ExisteOutraPessoaComMesmoDocumento(pessoa))
                return false;

            return true;
        }

        public bool PodeAtualizar(Pessoa pessoa)
        {
            if (!pessoa.EhValido())
                return false;

            if (ExisteOutraPessoaComMesmoDocumento(pessoa))
                return false;

            return true;
        }

        private bool ExisteOutraPessoaComMesmoDocumento(Pessoa pessoa)
        {
            var pessoaDB = pessoaRepository.ObterPessoaPorDocumento(pessoa.DocumentoPrincipal);

           
            if (pessoaDB != null && pessoaDB.Id != pessoa.Id)
            {
                pessoa.AdicionarErro("CPF/CNPJ", "Já existe uma pessoa cadastrada com esse documento");
                return true;
            }

            return false;
        }
    }
}
