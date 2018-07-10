using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Models.Processos;
using PGLaw.Presentation.Web.Controllers.Base;
using System;

namespace PGLaw.Apresentacao.Web.Controllers
{
    [Route("orgaos")]
    [Authorize(Policy = "AcessoUrl")]
    public class OrgaosController : BaseController
    {
        private readonly IAuxiliaresAppServices auxiliaresAppServices;

        public OrgaosController(IAuxiliaresAppServices auxiliaresAppServices)
        {
            this.auxiliaresAppServices = auxiliaresAppServices;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            var models = auxiliaresAppServices.ObterTodos<OrgaoVM>();
            return View(models);
        }

        [HttpGet("criar")]
        [HttpGet("justicas/{justica}/orgaos/criar")]
        public ActionResult Create(int? justica)
        {
            MontarViewBags();

            if (justica.HasValue)
            {
                var model = new OrgaoVM()
                {
                    JusticaId = justica.Value
                };
                return View(model);
            }

            return View();
        }

        [HttpPost("criar")]
        [HttpPost("justicas/{justica}/orgaos/criar")]
        public ActionResult Create(OrgaoVM model)
        {
            if (!ModelState.IsValid)
            {
                MontarViewBags();
                return View(model);
            }

            auxiliaresAppServices.Adicionar<OrgaoVM>(model);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public ActionResult Edit(int id)
        {
            MontarViewBags();
            var model = auxiliaresAppServices.ObterModel<OrgaoVM>(id);
            return View(model);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrgaoVM model)
        {
            if (!ModelState.IsValid)
            {
                MontarViewBags();
                return View(model);
            }

            auxiliaresAppServices.Atualizar(model);
            return RedirectToAction("Index");
        }


        #region metodos privados

        public void MontarViewBags()
        {
            ViewBag.Justicas = new SelectList(auxiliaresAppServices.ObterTodos<JusticaVM>(), "Id", "DescricaoReduzida");
        }

        #endregion
    }
}
