using PGLaw.Infra.Cross.AspNetMvc.Attributes;
using PGLaw.Infra.Cross.Common.Utils;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Sistema.Models
{
    public class RegistrarVM : UsuarioVM
    {
        public RegistrarVM() 
        {
            Id = SequentialGuidGenerator.Generate();
        }

        [Required]
        public new string Nome { get; set; }

        [Required]
        [EmailAddress]
        public new string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [CpfValidator]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

    }
}
