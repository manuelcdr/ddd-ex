using System;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class PreCadastroProcessoVM
    {
        [Required]
        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }

        [Required]
        [Display(Name = "Instância")]
        public byte NumeroInstancia { get; set; }

        [Required]
        [Display(Name = "Número Instância")]
        public string NumeroNInstancia { get; set; }

        [Required]
        [Display(Name = "Tipo de Processo")]
        public string TipoProcesso { get; set; }

        [Required]
        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }
    }
}
