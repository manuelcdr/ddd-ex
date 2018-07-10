using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Infra.Data.Sistema.Context;

namespace PGLaw.Infra.Data.Sistema.Repositories
{
    public class SistemaUnitOfWork : ISistemaUnitOfWork
    {
        private readonly SistemaContext context;

        public SistemaUnitOfWork(SistemaContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public void Commit()
        {
            context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            context.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
