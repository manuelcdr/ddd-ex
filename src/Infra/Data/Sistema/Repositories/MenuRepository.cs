using System;
using System.Linq;
using System.Collections.Generic;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Infra.Data.Sistema.Context;
using PGLaw.Infra.Data.Sistema.Repositories.Base;

namespace PGLaw.Infra.Data.Sistema.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(SistemaContext context) : base(context)
        {
        }

        public IEnumerable<Menu> ObterMenusFilhos(Guid menuPaiId)
        {
            return Buscar(c => c.MenuPaiId == menuPaiId);
        }

        public IEnumerable<Menu> ObterMenusPorNiveisDeAcessos(params Guid[] niveisDeAcessosIds)
        {
            return Buscar<MenuNivelDeAcesso>(x => niveisDeAcessosIds.Any(id => id == x.NivelDeAcessoId)).Select(x => x.Menu);
        }
    }
}
