using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Sistema.Models
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool LembrarSenha { get; set; }
    }
}
