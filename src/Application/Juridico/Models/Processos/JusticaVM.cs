using PGLaw.Application.Juridico.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class JusticaVM : TipoVM<int>
    {
        [Display(Name = "Descrição Reduzida")]
        public string DescricaoReduzida { get; set; }
    }
}
