using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using PGLaw.Domain.Contratos.Pessoas.Entitties;
using PGLaw.Domain.Contratos.Pessoas.Interfaces.Repositories;

namespace PGLaw.Domain.Contratos.Pessoas.Validations
{
    public class PessoaValidator
    {
        private readonly IContratoGlobalRepository ContratoRepository;
        private readonly IPessoasRepository pessoaRepository;

        public PessoaValidator(IContratoGlobalRepository ContratoRepository, IPessoasRepository pessoaRepository)
        {
            this.ContratoRepository = ContratoRepository;
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
