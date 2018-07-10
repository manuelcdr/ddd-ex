using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Pessoas
{
    public class PessoaFisicaVM
    {
        public PessoaFisicaVM()
        {
            Id = SequentialGuidGenerator.Generate();
            DadosPessoaFisica = new DadosPessoaFisicaVM();
        }

        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Site")]
        public string Url { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        public DadosPessoaFisicaVM DadosPessoaFisica { get; set; }
    }
}
