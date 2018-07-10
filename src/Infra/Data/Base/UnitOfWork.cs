using Microsoft.EntityFrameworkCore;
using PGLaw.Domain.Core.Interfaces.Repositories;

namespace PGLaw.Infra.Data.Base
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Commit()
        {
            context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            context.Database.RollbackTransaction();
        }
    }
}
