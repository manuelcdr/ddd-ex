using PGLaw.Infra.Cross.AspNetMvc.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Pessoas
{
    public class DadosPessoaFisicaVM
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [CpfValidator]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        public string RG { get; set; }

        [Display(Name = "Orgão Emissor")]
        public string OrgaoEmissorRG { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Telefone Comercial")]
        public string TelefoneComercial { get; set; }

        [Display(Name = "Data Nascimento")]
        public DateTime? DataNascimento { get; set; }
    }
}
