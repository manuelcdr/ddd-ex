using PGLaw.Domain.Sistema.Entitties;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Sistema.Interfaces.Repositories
{
    public interface IUsuariosRepository : IUsuariosRepositoryCQRS
    {
        // niveis de acesso
        Guid[] ObterNiveisDeAcessoIdsPorUsuario(Guid usuarioId);
        void AtualizarRelacionametoUsuarioNivelDeAcessoPorNivelDeAcesso(Guid nivelDeAcessoId, params Guid[] usuariosIds);
        void AtualizarRelacionametoUsuarioNivelDeAcessoPorUsuario(Guid usuarioId, params Guid[] niveisDeAcessosIds);
        void AtualizarRelacionametoMenuNivelDeAcesso(Guid nivelDeAcessoId, params Guid[] menusIds);
        
        // menus
        IEnumerable<Menu> ObterMenusPorNiveisDeAcessos(params Guid[] niveisDeAcessosIds);
        IEnumerable<Menu> ObterMenusPais(params Guid[] menusFilhosIds);
    }

    public interface IUsuariosRepositoryCQRS
    {
        IEnumerable<Usuario> ObterUsuariosDoNivelDeAcesso(Guid nivelDeAcessoId);
        IEnumerable<Menu> ObterMenusDoNivelDeAcesso(Guid nivelDeAcessoId);
        IEnumerable<Menu> ObterMenusFilhos(Guid menuPaiId);
        IEnumerable<Menu> ObterMenusFerramentaAtivos();
        IEnumerable<Menu> ObterMenusDeAcessoDoUsuario(Guid usuarioId);
        IEnumerable<Usuario> ObterUsuariosAtivos();
        IEnumerable<NivelDeAcesso> ObterNiveisDeAcessoDoUsuario(Guid usuarioId);
        NivelDeAcesso ObterNivelDeAcessoCompleto(Guid id);
        Usuario ObterUsuarioCompleto(Guid id);
    }
}
