using Microsoft.AspNetCore.Identity;
using PGLaw.Application.Sistema.Models;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Sistema.Interfaces.Services
{
    public interface ISistemaAppServices
    {
        // menu
        void AdicionarMenu(MenuVM model);
        void AtualizarMenu(MenuVM model);
        MenuVM ObterMenuPorId(Guid id);
        IEnumerable<MenuVM> ObterTodosMenus();
        IEnumerable<MenuVM> ObterTodosMenusFerramentas();


        // nivel de acesso
        void AdicionarNivelDeAcesso(NivelDeAcessoVM model);
        void AtualizarNivelDeAcesso(NivelDeAcessoVM model);
        NivelDeAcessoVM ObterNivelDeAcesso(Guid id);
        IEnumerable<NivelDeAcessoVM> ObterTodosNiveisDeAcesso();
        IEnumerable<UsuarioVM> ObterTodosUsuariosAtivos();


        // usuario
        UsuarioVM ObterUsuario(Guid id);
        IEnumerable<UsuarioVM> ObterTodosUsuarios();

        void GerarDadosIniciaisDoSistema(Guid usuarioId);
    }
}
