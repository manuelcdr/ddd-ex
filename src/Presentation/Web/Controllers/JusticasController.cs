using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Models.Processos;
using PGLaw.Presentation.Web.Controllers.Base;
using System;

namespace PGLaw.Apresentacao.Web.Controllers
{
    [Route("justicas")]
    [Authorize(Policy = "AcessoUrl")]
    public class JusticasController : BaseController
    {
        private readonly IAuxiliaresAppServices auxiliaresAppServices;

        public JusticasController(IAuxiliaresAppServices auxiliaresAppServices)
        {
            this.auxiliaresAppServices = auxiliaresAppServices;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            var models = auxiliaresAppServices.ObterTodos<JusticaVM>();
            return View(models);
        }

        [HttpGet("criar")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("criar")]
        public ActionResult Create(JusticaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            auxiliaresAppServices.Adicionar<JusticaVM>(model);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public ActionResult Edit(int id)
        {
            var model = auxiliaresAppServices.ObterModel<JusticaVM>(id);
            return View(model);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JusticaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            auxiliaresAppServices.Atualizar(model);
            return RedirectToAction("Index");
        }
    }
}
