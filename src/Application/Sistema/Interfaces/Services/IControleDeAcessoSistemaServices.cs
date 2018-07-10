using Microsoft.AspNetCore.Identity;
using PGLaw.Application.Sistema.Models;
using System;
using System.Collections.Generic;

namespace PGLaw.Application.Sistema.Interfaces.Services
{
    public interface IControleDeAcessoAppServices
    {
        IEnumerable<MenuVM> ObterArvoreDeAcessoPorUsuario(Guid usuarioId);
        IdentityResult TrocarSenha(Guid usuarioId, AlterarSenhaVM model);
        IdentityResult AdicionarUsuario(RegistrarVM model);
        IdentityResult AtualizarUsuario(EditarUsuarioVM model);
        SignInResult Login(string email, string senha);
    }
}
