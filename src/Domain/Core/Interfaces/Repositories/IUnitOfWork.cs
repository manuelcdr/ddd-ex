using System.Threading.Tasks;

namespace PGLaw.Domain.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        int SaveChanges();
    }
}
