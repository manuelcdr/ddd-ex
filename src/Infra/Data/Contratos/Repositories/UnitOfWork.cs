using PGLaw.Domain.Contratos.Common.Interfaces.Repositories;
using PGLaw.Infra.Data.Contratos.Context;

namespace PGLaw.Infra.Data.Contratos.Repositories
{
    public class ContratoUnitOfWork : IContratoUnitOfWork
    {
        private readonly ContratoContext context;

        public ContratoUnitOfWork(ContratoContext context)
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
