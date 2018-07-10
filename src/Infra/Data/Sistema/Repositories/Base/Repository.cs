using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Core.Interfaces.Entities;
using PGLaw.Domain.Core.Interfaces.Repositories;
using PGLaw.Infra.Data.Sistema.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PGLaw.Infra.Data.Sistema.Repositories.Base
{
    public abstract class Repository<T> : IRepositoryFull<T> where T : class, IDefaultEntity, new()
    {
        protected readonly SistemaContext Ctx;
        protected readonly DbSet<T> DbSet;

        public Repository(SistemaContext context)
        {
            Ctx = context;
            DbSet = context.Set<T>();
        }

        public virtual int SaveChanges()
        {
            return Ctx.SaveChangesAsync().Result;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await Ctx.SaveChangesAsync();
        }

        public virtual void Adicionar(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual IEnumerable<T> Buscar(Expression<Func<T, bool>> expression)
        {
            return DbSet.AsNoTracking().Where(expression);
        }

        public virtual void Excluir(Guid id)
        {
            var entity = new T { Id = id };
            DbSet.Remove(entity);
        }

        public virtual T ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return DbSet.AsNoTracking();
        }

        #region entidades adicionais

        private DbSet<T2> Set<T2>() where T2 : class
        {
            return Ctx.Set<T2>();
        }

        public virtual void Adicionar<T2>(T2 entity) where T2 : class
        {
            Set<T2>().Add(entity);
        }

        public virtual void Atualizar<T2>(T2 entity) where T2 : class
        {
            Set<T2>().Update(entity);
        }

        public virtual IEnumerable<T2>Buscar<T2>(Expression<Func<T2, bool>> expression) where T2 : class
        {
            return Set<T2>().AsNoTracking().Where(expression);
        }

        public virtual T2 ObterPorId<T2>(Guid id) where T2 : class, IDefaultEntity
        {
            return Set<T2>().AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<T2> ObterTodos<T2>() where T2 : class
        {
            return Set<T2>().AsNoTracking();
        }

        public virtual void Excluir<T2>(Guid id) where T2 : class, IDefaultEntity, new()
        {
            var entity = new T2 { Id = id };
            Set<T2>().Remove(entity);
        }

        #endregion
    }
}
