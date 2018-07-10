using PGLaw.Domain.Contratos.Contratos.Entitties;

namespace PGLaw.Domain.Contratos.Contratos.Validations
{
    public class ContratoValidator
    {
        public ContratoValidator()
        {

        }

        public bool PodeCadastrar(Contrato contrato)
        {
            if (!contrato.EhValido())
                return false;

            return true;
        }

        public bool PodeAtualizar(Contrato contrato)
        {
            if (!contrato.EhValido())
                return false;

            return true;
        }
    }
}
