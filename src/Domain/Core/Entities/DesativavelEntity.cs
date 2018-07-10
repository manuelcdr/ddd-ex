using PGLaw.Domain.Core.Interfaces.Entities;

namespace PGLaw.Domain.Core.Entities
{
    public class DesativavelEntity<T, TKey> : DefaultEntity<T, TKey>, IDesativavel where T : class
    {
        public bool Ativo { get; protected set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}
