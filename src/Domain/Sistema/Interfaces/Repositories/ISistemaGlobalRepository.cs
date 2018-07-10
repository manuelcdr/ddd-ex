using PGLaw.Domain.Core.Interfaces.Repositories;

namespace PGLaw.Domain.Sistema.Interfaces.Repositories
{
    public interface ISistemaGlobalRepository : IGlobalRepository, ISistemaCQRS
    {
    }

    public interface ISistemaCQRS : IGlobalRepositoryRead
    {
    }
}
