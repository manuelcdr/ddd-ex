using PGLaw.Domain.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PGLaw.Domain.Core.Interfaces.Repositories
{
    public interface IGlobalRepositoryRead
    {
        T ObterPorId<T>(object id) where T : class;
        IEnumerable<T> ObterTodos<T>() where T : class;
        IEnumerable<T> ObterTodosAtivos<T>() where T : class, IDesativavel;
        IEnumerable<T> Buscar<T>(Expression<Func<T, bool>> predicate) where T : class;

        object ObterPorId(Type type, object id);
        IEnumerable<object> ObterTodos(Type type);
        IEnumerable<object> ObterTodosAtivos(Type type);
    }

    public interface IGlobalRepositoryWrite
    {
        void Adicionar<T>(T entidade) where T : class;
        void Atualizar<T>(T entidade) where T : class;
        void AtualizarComReferencias<T>(T entidade) where T : class;
        void Excluir<T>(object id) where T : class;
    }

    public interface IGlobalRepository : IGlobalRepositoryRead, IGlobalRepositoryWrite
    {
    }
}
