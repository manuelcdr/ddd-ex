using PGLaw.Infra.Cross.Common.Extensions;
using PGLaw.Infra.Cross.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Infra.Cross.AspNetMvc.Attributes
{
    public class CpfValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ValidadorDeCPF.Validar((value as string).ApenasNumeros());
        }
    }
}
