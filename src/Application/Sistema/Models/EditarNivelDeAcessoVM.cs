using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Sistema.Models
{
    public class EditarNivelDeAcessoVM
    {
        public EditarNivelDeAcessoVM()
        {
            MenusSelecionados = new int[] { };
            UsuariosSelecionados = new string[] { };
        }

        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public int[] MenusSelecionados { get; set; }
        public string[] UsuariosSelecionados { get; set; }
    }
}
