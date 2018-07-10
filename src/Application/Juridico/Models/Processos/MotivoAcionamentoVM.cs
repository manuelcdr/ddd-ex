using PGLaw.Application.Juridico.Models.Common;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class MotivoAcionamentoVM : TipoDesativavelVM
    {
        bool Consumidor { get; set; }
        bool Trabalhista { get; set; }
    }
}
