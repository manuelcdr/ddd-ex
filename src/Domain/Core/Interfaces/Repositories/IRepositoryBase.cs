using PGLaw.Domain.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PGLaw.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase
    {
        void Adicionar<T>(T entidade) where T : class;
        void Atualizar<T>(T entidade) where T : class;
        void AtualizarComReferencias<T>(T entidade) where T : class;
        void Excluir<T>(object id) where T : class;

        IEnumerable<T> ObterTodos<T>() where T : class;
        T ObterPorId<T>(object id) where T : class;
        IEnumerable<T> Buscar<T>(Expression<Func<T, bool>> predicate) where T : class;
        IEnumerable<T> ObterTodosAtivos<T>() where T : class, IDesativavel;

        object ObterPorId(Type type, object id);
        IEnumerable<object> ObterTodos(Type type);
        IEnumerable<object> ObterTodosAtivos(Type type);

        Task<int> SaveChanges();
    }
}
