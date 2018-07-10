using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Contratos.Models.Pessoas
{
    public class PessoaJuridicaVM : PessoaVM
    {
        [Display(Name = "Nome Fantasia")]
        public new string Nome { get; set; }

        private new DadosPessoaFisicaVM DadosPessoaFisica;
    }
}
