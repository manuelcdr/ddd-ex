using PGLaw.Domain.Core.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Entitties;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Interfaces.Repositories
{
    public interface INivelDeAcessoRepository
    {
        IEnumerable<NivelDeAcesso> ObterPorUsuario(Guid usuarioId);
        Guid[] ObterNiveisDeAcessoIdsPorUsuario(Guid usuarioId);
    }
}
