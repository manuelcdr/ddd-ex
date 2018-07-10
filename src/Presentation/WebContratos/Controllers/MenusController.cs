using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Sistema.Interfaces.Services;
using PGLaw.Application.Sistema.Models;
using PGLaw.Presentation.WebContratos.Controllers.Base;

namespace PGLaw.Apresentacao.WebContratos.Controllers
{
    [Route("menus")]
    [Authorize(Policy = "AcessoUrl")]
    public class MenusController : BaseController
    {
        private readonly ISistemaAppServices _appServices;

        public MenusController(ISistemaAppServices appServices)
        {
            _appServices = appServices;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            var menus = _appServices.ObterTodosMenus();
            menus.OrderBy(x => string.IsNullOrEmpty(x.CaminhoAcesso) ? x.Titulo : x.CaminhoAcesso);

            return View(menus);
        }

        [HttpGet("novo/raiz")]
        [ActionName("CreateRaiz")]
        public ActionResult Create()
        {
            var menu = new MenuVM();
            menu.DefinirTipo(MenuTipo.Raiz);

            return View("Create", menu);
        }

        [HttpGet("{menuPaiId}/novo/filho/{tipo:alpha}")]
        [ActionName("CreateFilho")]
        public ActionResult Create(Guid menuPaiId, MenuTipo tipo)
        {
            var model = new MenuVM();
            model.DefinirTipo(tipo);

            var pai = _appServices.ObterMenuPorId(menuPaiId);
            model.MenuPaiId = pai.Id;
            model.MenuPai = pai;
            model.MenuPaiTitulo = pai.Titulo;

            return View("Create", model);
        }


        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _appServices.AdicionarMenu(model);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public ActionResult Edit(Guid id)
        {
            var model = _appServices.ObterMenuPorId(id);

            //ViewBag.MenusFilhos = model.MenusFilhos;
            return View(model);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _appServices.AtualizarMenu(model);
            return RedirectToAction("Index");
        }
    }
}