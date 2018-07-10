using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Juridico.Interfaces.Services;
using PGLaw.Application.Juridico.Models.Pessoas;
using PGLaw.Infra.Cross.Common.Enums;
using System;

namespace Web.Controllers
{
    [Authorize(Policy = "AcessoUrl")]
    [Route("clientes")]
    public class ClientesController : Controller
    {
        private readonly IPessoasAppServices pessoasAppServices;

        public ClientesController(IPessoasAppServices pessoasAppServices)
        {
            this.pessoasAppServices = pessoasAppServices;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            var models = pessoasAppServices.ObterTodosClientes();
            return View(models);
        }

        [HttpGet("criar")]
        public ActionResult Create(string tipo)
        {
            return View("Create" + tipo);
        }

        [HttpPost("criar/pessoa-fisica")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePessoaFisica(ClienteVM model)
        {
            if (ModelState.IsValid)
            {
                model.Pessoa.TipoPessoa = TipoPessoa.Fisica;
                pessoasAppServices.CriarCliente(model);
                return RedirectToAction("Index");
            }
            else
                return View("CreateFisica", model);
        }

        [HttpPost("criar/pessoa-juridica")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePessoaJuridica(ClienteVM model)
        {
            if(model.Pessoa != null)
                model.Id = model.Pessoa.Id;


            if (ModelState.IsValid)
            {
                model.Pessoa.TipoPessoa = TipoPessoa.Juridica;
                pessoasAppServices.CriarCliente(model);
                return RedirectToAction("Index");
            }
            else
                return View("CreateJuridica", model);
        }

        [HttpGet("{id:guid}")]
        public ActionResult Edit(Guid id)
        {
            //return View("Test");
            var model = pessoasAppServices.ObterCliente(id);

            if (model.Pessoa.TipoPessoa == TipoPessoa.Fisica)
                return View("EditFisica", (ClientePessoaFisicaVM)model);
            else
                return View("EditJuridica", (ClientePessoaJuridicaVM)model);
        }

        [HttpPost("editar/pessoa-fisica")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPessoaFisica(ClientePessoaFisicaVM model)
        {
            if (ModelState.IsValid)
            {
                pessoasAppServices.AtualizarCliente(model);
                return RedirectToAction("Index");
            }
            else
                return View("EditFisica", model);
        }

        [HttpPost("editar/pessoa-juridica")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPessoaJuridica(ClientePessoaJuridicaVM model)
        {
            if (ModelState.IsValid)
            {
                pessoasAppServices.AtualizarCliente(model);
                return RedirectToAction("Index");
            }
            else
                return View("EditJuridica", model);
        }
    }
}