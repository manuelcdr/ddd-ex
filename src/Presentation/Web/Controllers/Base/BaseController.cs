using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PGLaw.Apresentacao.Web.Controllers;
using PGLaw.Infra.Cross.Identity.Extensions;
using PGLaw.Infra.Cross.Identity.Interfaces;
using System;

namespace PGLaw.Presentation.Web.Controllers.Base
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        //private readonly IUser Usuario;

        //public BaseController(IUser usuario)
        //{
        //    this.Usuario = usuario;
        //}

        protected Guid UsuarioId => Guid.Parse(User.GetUserId());

        #region Helpers

        protected void AddErrors(string campo, string mensagem)
        {
            ModelState.AddModelError(campo, mensagem);
        }

        protected void AddErrors(string campo, params string[] mensagens)
        {
            foreach (var msg in mensagens)
            {
                ModelState.AddModelError(campo, msg);
            }
        }

        protected void AddErrors(params string[] mensagens)
        {
            foreach (var msg in mensagens)
            {
                ModelState.AddModelError(string.Empty, msg);
            }
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        protected IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
