using PGLaw.Domain.Juridico.Common.Interfaces.Repositories;
using PGLaw.Infra.Data.Juridico.Context;

namespace PGLaw.Infra.Data.Juridico.Repositories
{
    public class JuridicoUnitOfWork : IJuridicoUnitOfWork
    {
        private readonly JuridicoContext context;

        public JuridicoUnitOfWork(JuridicoContext context)
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
