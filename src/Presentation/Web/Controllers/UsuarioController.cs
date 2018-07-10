using PGLaw.Infra.Cross.Identity.Models;
using System.Threading.Tasks;
using System.IO;
using PGLaw.Presentation.Web.Controllers.Base;
using Microsoft.AspNetCore.Identity;
using PGLaw.Infra.Cross.Identity.Services;
using Microsoft.Extensions.Logging;
using PGLaw.Presentation.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Sistema.Models;
using PGLaw.Infra.Cross.Identity.Extensions;
using PGLaw.Infra.Cross.Identity.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using PGLaw.Application.Sistema.Interfaces.Services;
using System.Linq;

namespace PGLaw.Apresentacao.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IUser _user;
        private readonly IHostingEnvironment _env;
        private readonly ISistemaAppServices appServices;
        private readonly IControleDeAcessoAppServices controleDeAcessoAppServices;

        public UsuarioController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            IUser user,
            IHostingEnvironment env,
            ISistemaAppServices appServices,
            IControleDeAcessoAppServices controleDeAcessoAppServices
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            this._user = user;
            this._env = env;
            this.appServices = appServices;
            this.controleDeAcessoAppServices = controleDeAcessoAppServices;
        }

        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        ////[DesabilitarValidarTrocarSenhaActionFilter]
        //public ActionResult Registrar()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        ////[DesabilitarValidarTrocarSenhaActionFilter]
        //public async Task<ActionResult> Registrar(RegistrarVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { Id = model.Id, UserName = model.Email, Email = model.Email };
        //        var result = await _userManager.CreateAsync(user, model.Senha);
        //        if (result.Succeeded)
        //        {
        //            var usuario = await _userManager.FindByEmailAsync(model.Email);

        //            if (usuario.PodeSeLogar())
        //                _signInManager.ApplicationSigIn(user, false);

        //            return RedirectToAction("Index", "Home");
        //        }
        //        AddErrors(result);
        //    }

        //    return View(model);
        //}

        [AllowAnonymous]
        //[DesabilitarValidarTrocarSenhaActionFilter(Order = 0)]
        public ActionResult Login(string returnUrl)
        {


            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogarDireto(string email)
        {
#if DEBUG
            var result = controleDeAcessoAppServices.Login(email, "senhaSuperSecretaMirabolante");
            return RedirectToAction("Index", "Home");
#endif

            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[DesabilitarValidarTrocarSenhaActionFilter]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = controleDeAcessoAppServices.Login(model.Email, model.Senha);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut || result.IsNotAllowed)
                    AddErrors("", "Acesso Negado");
                else
                    AddErrors("", "Dados de acesso inválidos!");

                return View(model);
            }

            // tudo certo!
            return RedirectToAction("Index", "Home");
        }

        //[DesabilitarValidarTrocarSenhaActionFilter]
        public ActionResult AlterarSenha(string mensagem)
        {
            ViewBag.Mensagem = mensagem;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[DesabilitarValidarTrocarSenhaActionFilter]
        public async Task<ActionResult> AlterarSenha(AlterarSenhaVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = controleDeAcessoAppServices.TrocarSenha(UsuarioId, model);

            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Usuario");
        }

        public async Task<ActionResult> AlterarImagemProfile(List<IFormFile> files)
        {
            bool isSavedSuccessfully = false;

            var allowedExtensions = new[] { "png", "jpeg", "jpg", "gif" };

            foreach (var formFile in files)
            {
                string _extension = Path.GetExtension(formFile.FileName);
                string _folder = Path.Combine(_env.ContentRootPath, "/Content/Images/pessoas/profile");
                string _fullPath = Path.Combine(_folder, _user.Id + ".jpeg");

                if (!Directory.Exists(_folder))
                    Directory.CreateDirectory(_folder);

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(_fullPath, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                    }
                }
            }
            return Json(new { Message = string.Empty });
        }

        #region métodos privados

        private bool VerificarSePrecisaDeDadosIniciais()
        {
            //var menus = appServices.ObterTodosMenus();
            //var niveis = appServices.ObterTodosNiveisDeAcesso();
            //return (menus?.Count() <= 0 && niveis?.Count() <= 0);
            return false;
        }

        #endregion

    }
}