using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Infra.Data.Sistema.Context;
using PGLaw.Infra.Data.Sistema.Repositories.Base;

namespace PGLaw.Infra.Data.Sistema.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SistemaContext context) : base(context)
        {
        }
    }
}
