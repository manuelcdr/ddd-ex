using PGLaw.Application.Juridico.Models.Common;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class CausaRealVM : TipoDesativavelVM
    {
        bool Consumidor { get; set; }
        bool Trabalhista { get; set; }
    }
}
