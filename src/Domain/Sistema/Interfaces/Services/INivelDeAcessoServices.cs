using PGLaw.Domain.Core.Interfaces.DomainServices;
using PGLaw.Domain.Sistema.Entitties;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Interfaces.Services
{
    public interface INivelDeAcessoServices
    {
        void Adicionar(Guid id, string nome, string detalhes, IEnumerable<Guid> usuariosIds, IEnumerable<Guid> menusIds);
        void Atualizar(Guid id, string nome, string detalhes, IEnumerable<Guid> usuariosIds, IEnumerable<Guid> menusIds);
    }
}
