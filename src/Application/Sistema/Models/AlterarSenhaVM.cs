//using PGLaw.Apresentacao.Web.App.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Sistema.Models
{
    public class AlterarSenhaVM
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string SenhaAtual { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha", Description = "A senha deve conter letras maiúsculas e minúsculas, numeros e caracter especial")]
        public string NovaSenha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NovaSenha")]
        [Display(Name = "Confirmar Nova Senha")]
        public string ConfirmacaoNovaSenha { get; set; }
    }
}
