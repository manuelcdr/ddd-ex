using FluentValidation;
using FluentValidation.Results;
using PGLaw.Domain.Core.Interfaces.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PGLaw.Domain.Core.Entities
{
    [NotMapped]
    public abstract class AutoValidator<T> : AbstractValidator<T>, IEntity where T : class
    {
        protected AutoValidator()
        {
            ValidationResult = new ValidationResult();
        }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool EhValido();

        public void AdicionarErros(params ValidationFailure[] erros)
        {
            foreach(var erro in erros)
            {
                ValidationResult.Errors.Add(erro);
            }
        }

        public void AdicionarErro(string nomePropriedade, string mensagem)
        {
            var erro = new ValidationFailure(nomePropriedade, mensagem);
            ValidationResult.Errors.Add(erro);
        }
    }
}
