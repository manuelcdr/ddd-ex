using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PGLaw.Application.Contratos.Interfaces.Services;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Models;
using PGLaw.Infra.Cross.Identity.Extensions;
using PGLaw.Infra.Cross.Identity.Models;
using PGLaw.Infra.Cross.Identity.Services;
using PGLaw.Presentation.WebContratos.Controllers.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PGLaw.Presentation.WebContratos.Controllers
{
    [Route("usuarios")]
    [Authorize(Policy = "AcessoUrl")]
    public class UsuariosController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;
        private readonly ISistemaAppServices sistemaAppServices;
        private readonly IPessoasAppServices pessoasAppServices;
        private readonly IControleDeAcessoAppServices controleDeAcessoServices;

        public UsuariosController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            IHostingEnvironment env,
            ISistemaAppServices sistemaAppServices,
            IPessoasAppServices pessoasAppServices,
            IControleDeAcessoAppServices controleDeAcessoServices
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            this._env = env;
            this.sistemaAppServices = sistemaAppServices;
            this.pessoasAppServices = pessoasAppServices;
            this.controleDeAcessoServices = controleDeAcessoServices;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            var models = sistemaAppServices.ObterTodosUsuarios();
            models.OrderBy(x => x.Nome);
            return View(models);
        }

        [HttpGet("novo")]
        public ActionResult Create()
        {
            GerarViewsBagsDeSelect();
            ViewBag.Novo = true;

            var model = new RegistrarVM();
            model.Senha = GerarSenha();

            return View("Create", model);
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegistrarVM model)
        {
            if (!ModelState.IsValid)
            {
                GerarViewsBagsDeSelect();
                return View(model);
            }

            var result = controleDeAcessoServices.AdicionarUsuario(model);

            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public ActionResult Edit(Guid id)
        {
            GerarViewsBagsDeSelect();

            var model = sistemaAppServices.ObterUsuario(id);
            var editModel = model.ObterEditModel();

            editModel.NovaSenha = GerarSenha();
            editModel.GerarNovaSenha = false;

            return View("Edit", editModel);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditarUsuarioVM model)
        {
            if (!ModelState.IsValid)
            {
                GerarViewsBagsDeSelect();
                return View(model);
            }

            var result = controleDeAcessoServices.AtualizarUsuario(model);

            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        private string GerarSenha()
        {
            return "X" + Guid.NewGuid().ToString().Split('-')[0] + "#";
        }

        private void GerarViewsBagsDeSelect()
        {
            var niveis = sistemaAppServices.ObterTodosNiveisDeAcesso();
            var select = new SelectList(niveis, "Id", "Nome");
            ViewBag.NiveisDeAcesso = select;
        }
    }
}
