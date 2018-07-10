using PGLaw.Application.Juridico.Models.Common;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class AreaOfensoraVM : TipoVM
    {
        public string ProductNumber { get; set; }
        public int FamiliaOfensoraId { get; set; }

        public int PlClienteId { get; set; }
        public int CentroCustoClienteId { get; set; }
        public int AreaInterfaceClienteId { get; set; }
    }
}
