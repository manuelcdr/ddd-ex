using PGLaw.Domain.Juridico.Processos.Entitties;

namespace PGLaw.Domain.Juridico.Processos.Validations
{
    public class ProcessoValidator
    {
        public ProcessoValidator()
        {

        }

        public bool PodeCadastrar(Processo processo)
        {
            if (!processo.EhValido())
                return false;

            return true;
        }
    }
}
