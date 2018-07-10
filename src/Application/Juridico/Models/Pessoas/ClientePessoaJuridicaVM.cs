using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Pessoas
{
    public class ClientePessoaJuridicaVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Required]
        [Display(Name = "Segmento Jurídico")]
        public string Segmento { get; set; }

        [Required]
        [Display(Name = "Área de Atuação")]
        public string Atuacao { get; set; }

        [Required]
        [Display(Name = "UF")]
        public string UF { get; set; }

        public PessoaJuridicaVM Pessoa { get; set; }
    }
}
