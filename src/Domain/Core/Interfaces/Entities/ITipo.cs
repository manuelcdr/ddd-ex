namespace PGLaw.Domain.Core.Interfaces.Entities
{
    public interface ITipo<TKey> : IDefaultEntity<TKey>
    {
        string Descricao { get; }
    }
}
