using System;
using System.Collections.Generic;
using System.Linq;
using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Entitties.Relashionships;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Infra.Data.Sistema.Context;
using PGLaw.Infra.Data.Sistema.Repositories.Base;

namespace PGLaw.Infra.Data.Sistema.Repositories
{
    public class NivelDeAcessoRepository : Repository<NivelDeAcesso>, INivelDeAcessoRepository
    {
        public NivelDeAcessoRepository(SistemaContext context) : base(context) { }

        public Guid[] ObterNiveisDeAcessoIdsPorUsuario(Guid usuarioId)
        {
            return Buscar<UsuarioNivelDeAcesso>(x => x.UsuarioId == usuarioId).Select(x => x.NivelDeAcessoId).ToArray();
        }

        public IEnumerable<NivelDeAcesso> ObterPorUsuario(Guid usuarioId)
        {
            return Buscar<UsuarioNivelDeAcesso>(x => x.UsuarioId == usuarioId).Select(x => x.NivelDeAcesso);
        }
    }
}
