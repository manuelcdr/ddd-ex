using PGLaw.Domain.Core.Interfaces.Repositories;

namespace PGLaw.Domain.Contratos.Common.Interfaces.Repositories
{
    public interface IContratoGlobalRepository : IGlobalRepository, IContratoCQRS
    {
    }

    public interface IContratoCQRS : IGlobalRepositoryRead
    {
    }
}
