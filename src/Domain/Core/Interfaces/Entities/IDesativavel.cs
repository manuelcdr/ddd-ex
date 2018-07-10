namespace PGLaw.Domain.Core.Interfaces.Entities
{
    public interface IDesativavel
    {
        bool Ativo { get; }

        void Inativar();

        void Ativar();
    }
}
