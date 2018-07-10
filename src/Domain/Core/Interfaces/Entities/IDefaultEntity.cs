using System;

namespace PGLaw.Domain.Core.Interfaces.Entities
{
    public interface IDefaultEntity
    {
        object GetId();
    }

    public interface IDefaultEntity<TKey> : IDefaultEntity
    {
        TKey Id { get; }
    }
}
