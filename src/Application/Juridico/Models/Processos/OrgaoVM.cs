using PGLaw.Application.Juridico.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class OrgaoVM : TipoVM<int>
    {
        [Required]
        [Display(Name = "Justiça")]
        public int JusticaId { get; set; }

        [Display(Name = "Descrição Reduzida")]
        public string DescricaoReduzida { get; set; }
    }
}
