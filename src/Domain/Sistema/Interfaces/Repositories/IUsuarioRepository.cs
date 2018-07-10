using PGLaw.Domain.Core.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Entitties;

namespace PGLaw.Domain.Sistema.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryRead<Usuario>, IRepositoryWrite<Usuario>
    {
    }
}
