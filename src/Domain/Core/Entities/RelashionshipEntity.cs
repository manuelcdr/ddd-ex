using PGLaw.Domain.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PGLaw.Domain.Core.Entities
{
    public class RelashionshipEntity<T> : RelashionshipEntity<T, Guid> where T : class
    {
    }

    public class RelashionshipEntity<T, TKey> : AutoValidator<T>, IRelashionshipEntity where T : class
    {
        protected RelashionshipEntity()
        {
        }

        public override bool EhValido()
        {
            foreach (var prop in ObterPropriedadesChaves())
                if (prop.GetValue(this) == null)
                    return false;

            return true;
        }


        #region verificações

        public override bool Equals(object obj)
        {
            var compareTo = obj as T;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            foreach (var prop in ObterPropriedadesChaves())
            {
                if (prop.GetValue(this) != prop.GetValue(compareTo))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 1851351;

            foreach(var prop in ObterPropriedadesChaves())
                hashCode = hashCode * -151351 + EqualityComparer<TKey>.Default.GetHashCode((TKey)prop.GetValue(this));

            return hashCode;
        }

        private IEnumerable<PropertyInfo> ObterPropriedadesChaves()
        {
            var type = typeof(T);
            var props = type.GetProperties()
                .Where(x => x.PropertyType == typeof(TKey) && x.Name.ToLower().Contains("id"));

            return props;
        }

        #endregion
    }
}
