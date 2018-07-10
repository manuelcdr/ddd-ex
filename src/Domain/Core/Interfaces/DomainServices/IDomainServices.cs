using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Core.Interfaces.DomainServices
{
    public interface IDomainServicesRead<T>
    {
        T ObterPorId(Guid id);
    }

    public interface IDomainServicesReadAll<T> : IDomainServicesRead<T>
    {
        IEnumerable<T> ObterTodos();
    }

    public interface IDomainServiceWrite<T>
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Excluir(Guid id);
    }

    public interface IDomainServicesFull<T> : IDomainServiceWrite<T>, IDomainServicesReadAll<T>
    {
    }
}
