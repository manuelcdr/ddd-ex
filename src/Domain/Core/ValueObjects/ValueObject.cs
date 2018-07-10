using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Core.Interfaces.ValueObjects;

namespace PGLaw.Domain.Core.ValueObjects
{
    public abstract class ValueObject<T> : AutoValidator<T>, IValueObject where T : class
    {
        public override abstract bool EhValido();
    }
}
