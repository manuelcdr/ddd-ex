using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Contratos.Models.Pessoas
{
    public class ClienteVM
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

        public string Nome { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string Documento { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public PessoaVM Pessoa { get; set; }
    }
}
