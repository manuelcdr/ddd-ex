using PGLaw.Domain.Sistema.Entitties;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Interfaces.Services
{
    public interface IMontagemDeMenusServices
    {
        IEnumerable<Menu> ObterArvoreDeAcessoDoUsuario(Guid usuarioId);
    }
}
