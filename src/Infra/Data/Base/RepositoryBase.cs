using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Core.Interfaces.Repositories;
using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PGLaw.Infra.Data.Base
{
    public abstract class RepositoryBase : IRepositoryBase
    {
        protected readonly DbContext Context;

        public RepositoryBase(DbContext context)
        {
            this.Context = context;
        }

        protected DbSet<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }

        public void Adicionar<T>(T entidade) where T : class
        {
            Set<T>().Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T : class
        {
            var entry = Context.Entry(entidade);
            entry.State = EntityState.Modified;
            Set<T>().Update(entidade);
        }

        public void AtualizarComReferencias<T>(T entidade) where T : class
        {
            var entry = Context.Entry(entidade);
            foreach (var refi in entry.References)
            {
                AtualizarReferencias(refi);
            }
            entry.State = EntityState.Modified;
            Set<T>().Update(entidade);
        }

        private void AtualizarReferencias(ReferenceEntry refi)
        {
            if (refi.TargetEntry != null)
            {
                refi.TargetEntry.State = EntityState.Modified;
                foreach (var refii in refi.TargetEntry.References)
                {
                    AtualizarReferencias(refii);
                }
            }
        }

        public void Excluir<T>(object id) where T : class
        {
            var entidade = Set<T>().Find(id);
            Set<T>().Remove(entidade);
        }

        public void ExcluirCascade<T>(object id) where T : class
        {
            var entidade = Set<T>().Find(id);
            Set<T>().Remove(entidade);
        }

        public IEnumerable<T> ObterTodos<T>() where T : class
        {
            return Set<T>();
        }

        public T ObterPorId<T>(object id) where T : class
        {
            return Set<T>().Find(id);
        }

        public IEnumerable<T> Buscar<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Set<T>()
                .Where(predicate)
                .Distinct()
                .AsNoTracking();
        }

        public IEnumerable<T> BuscarAtivos<T>(Expression<Func<T, bool>> predicate) where T : class, IDesativavel
        {
            return Set<T>()
                .Where(predicate)
                .Where(x => x.Ativo)
                .Distinct()
                .AsNoTracking();
        }

        public IEnumerable<T> ObterTodosAtivos<T>() where T : class, IDesativavel
        {
            return Set<T>()
                .Where(x => x.Ativo)
                .AsNoTracking();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public object ObterPorId(Type type, object id)
        {
            return ChamadorMetodo.ChamarMetodoGenerico(this, "ObterPorId", new Type[] { type }, id);
        }

        public IEnumerable<object> ObterTodos(Type type)
        {
            return ChamadorMetodo.ChamarMetodoGenerico(this, "ObterTodos", new Type[] { type }) as IEnumerable<object>;
        }

        public IEnumerable<object> ObterTodosAtivos(Type type)
        {
            return ChamadorMetodo.ChamarMetodoGenerico(this, "ObterTodosAtivos", new Type[] { type }) as IEnumerable<object>;
        }
    }
}
