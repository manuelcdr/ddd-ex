using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Domain.Sistema.Interfaces.Services;
using PGLaw.Presentation.Web.Controllers.Base;
using System.Linq;

namespace PGLaw.Apresentacao.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISistemaAppServices appServices;
        private readonly IDadosIniciaisServices dadosIniciais;

        public HomeController(ISistemaAppServices appServices, IDadosIniciaisServices dadosIniciais)
        {
            this.appServices = appServices;
            this.dadosIniciais = dadosIniciais;
        }

        [Route("")]
        [Route("Home")]
        public ActionResult Index()
        {
            if (!appServices.ObterTodosMenus().Any())
                return RedirectToAction("DadosIniciais");

            return View();
        }

        public ActionResult Error()
        {
            return View("Error404");
        }

        public ActionResult DadosIniciais()
        {
            return View();
        }

        public ActionResult GerarDadosIniciais()
        {
            appServices.GerarDadosIniciaisDoSistema(UsuarioId);
            return Ok();
        }
    }
}