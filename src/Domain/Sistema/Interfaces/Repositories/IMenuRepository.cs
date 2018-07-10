using PGLaw.Domain.Core.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Entitties;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> ObterMenusPorNiveisDeAcessos(params Guid[] niveisDeAcessosIds);
        IEnumerable<Menu> ObterMenusFilhos(Guid menuPaiId);
    }
}
