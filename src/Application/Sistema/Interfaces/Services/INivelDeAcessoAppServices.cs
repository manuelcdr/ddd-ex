using PGLaw.Application.Sistema.Models;
using PGLaw.Domain.Sistema.Entitties;

namespace PGLaw.Application.Sistema.Interfaces.Services
{
    public interface INivelDeAcessoAppServices : IAppServiceCrudRead<NivelDeAcessoVM>, IAppServiceCrudWrite<NivelDeAcessoVM>
    {
    }
}
