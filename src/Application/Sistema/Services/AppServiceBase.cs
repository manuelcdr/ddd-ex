using PGLaw.Domain.Sistema.Interfaces.Repositories;
using System.Threading.Tasks;

namespace PGLaw.Application.Sistema.Services
{
    public class AppServiceBase
    {
        private readonly ISistemaUnitOfWork uoW;
        private readonly ISistemaCQRS sistemaCQRS;

        public AppServiceBase(ISistemaUnitOfWork uow, ISistemaCQRS sistemaCQRS)
        {
            this.uoW = uow;
            this.sistemaCQRS = sistemaCQRS;
        }

        protected ISistemaUnitOfWork UoW => uoW;
        protected ISistemaCQRS SistemaCQRS => sistemaCQRS;

        protected virtual int SaveChanges()
        {
            return UoW.SaveChanges();
        }
    }
}
