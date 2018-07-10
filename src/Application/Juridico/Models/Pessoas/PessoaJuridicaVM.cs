using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Pessoas
{
    public class PessoaJuridicaVM
    {
        public PessoaJuridicaVM()
        {
            Id = SequentialGuidGenerator.Generate();
            DadosPessoaJuridica = new DadosPessoaJuridicaVM();
        }

        public Guid Id { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Site")]
        public string Url { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        public DadosPessoaJuridicaVM DadosPessoaJuridica { get; set; }
    }
}
