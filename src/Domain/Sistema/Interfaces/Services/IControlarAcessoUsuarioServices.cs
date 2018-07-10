using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Infra.Cross.Common.Enums;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Interfaces.Services
{
    public interface IControlarAcessoUsuarioServices
    {
        //bool UsuarioPodeAcessarUrl(Guid usuarioId, string url);
        //IEnumerable<NivelDeAcesso> ObterNiveisDeAcessoDoUsuario(Guid usuarioId);
        //IEnumerable<Menu> ObterMenusAutorizadosDoUsuario(Guid usuarioId);
        //void AtualizarDadosDeAcessoUsuario(Guid id, DiasDaSemana diasDaSemana, bool trocarSenha, bool ativo);

        void AtualizarNivelDeAcessoUsuario(Guid id, params Guid[] niveisDeAcesso);
    }
}
