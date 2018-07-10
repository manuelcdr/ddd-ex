using PGLaw.Domain.Core.Interfaces.Repositories;
using PGLaw.Domain.Juridico.Outros.Entitties;

namespace PGLaw.Domain.Juridico.Outros.Interfaces.Repositories
{
    public interface IForumRepository : IRepositoryRead<Forum>, IRepositoryWrite<Forum>
    {
    }
}
