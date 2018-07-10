using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Models;
using PGLaw.Presentation.Web.Controllers.Base;

namespace PGLaw.Apresentacao.Web.Controllers
{
    [Route("niveis-de-acessos")]
    [Authorize(Policy = "AcessoUrl")]
    public class NiveisDeAcessosController : BaseController
    {
        private readonly ISistemaAppServices _appServices;

        public NiveisDeAcessosController(ISistemaAppServices appServices)
        {
            _appServices = appServices;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            var models = _appServices.ObterTodosNiveisDeAcesso();
            models.OrderBy(x => x.Nome);
            return View(models);
        }

        [HttpGet("novo")]
        public ActionResult Create()
        {
            MontarSelectsItems();
            ViewBag.Novo = true;
            return View("CreateEdit", new NivelDeAcessoVM());
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NivelDeAcessoVM model)
        {
            if (!ModelState.IsValid)
            {
                MontarSelectsItems();
                ViewBag.Novo = true;
                return View("CreateEdit", model);
            }

            _appServices.AdicionarNivelDeAcesso(model);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public ActionResult Edit(Guid id)
        {
            MontarSelectsItems();
            var model = _appServices.ObterNivelDeAcesso(id);
            return View("CreateEdit", model);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NivelDeAcessoVM model)
        {
            if (!ModelState.IsValid)
            {
                MontarSelectsItems();
                return View("CreateEdit", model);
            }

            _appServices.AtualizarNivelDeAcesso(model);
            return RedirectToAction("Index");
        }

        private void MontarSelectsItems()
        {
            var usuarios = _appServices.ObterTodosUsuariosAtivos();
            var menus = _appServices.ObterTodosMenusFerramentas();
            ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nome");
            ViewBag.Menus = new SelectList(menus, "Id", "Titulo");
        }
    }
}
