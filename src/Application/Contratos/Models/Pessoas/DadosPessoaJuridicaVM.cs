using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PGLaw.Application.Contratos.Models.Pessoas
{
    public class DadosPessoaJuridicaVM
    {
        [Required]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "inscrição Municipal")]
        public string inscricaoMunicipal { get; set; }

        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "E-mail Financeiro")]
        public string EmailFinanceiro { get; set; }
    }
}
