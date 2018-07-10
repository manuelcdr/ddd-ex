using PGLaw.Domain.Core.Interfaces.Repositories;

namespace PGLaw.Domain.Juridico.Common.Interfaces.Repositories
{
    public interface IJuridicoGlobalRepository : IGlobalRepository, IJuridicoCQRS
    {
    }

    public interface IJuridicoCQRS : IGlobalRepositoryRead
    {   
    }
}
