using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGLaw.Application.Contratos.Interfaces.Services;
using PGLaw.Application.Contratos.Models.Pessoas;
using PGLaw.Infra.Cross.Common.Enums;
using System;

namespace WebContratos.Controllers
{
    [Route("clientes")]
    [Authorize(Policy = "AcessoUrl")]
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
            if (ModelState.IsValid)
            {
                model.Pessoa.TipoPessoa = TipoPessoa.Juridica;
                pessoasAppServices.CriarCliente(model);
                return RedirectToAction("Index");
            }
            else
                return View("CreateJuridica", model);
        }

        [HttpGet("editar/{id:guid}")]
        public ActionResult Edit(Guid id, TipoPessoa tipo)
        {
            //var model;
            //if (tipo == TipoPessoa.Fisica)
            var model = pessoasAppServices.ObterCliente(id);
            //else
            //model = pessoasAppServices.ObterClientePessoaJuridica(id);

            return View("Edit" + model.TipoPessoa.ToString(), model);

        }

        [HttpPost("editar/pessoa-fisica")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPessoaFisica(ClienteVM model)
        {
            if (ModelState.IsValid)
            {
                model.Pessoa.TipoPessoa = TipoPessoa.Fisica;
                pessoasAppServices.AtualizarCliente(model);
                return RedirectToAction("Index");
            }
            else
                return View("EditFisica", model);
        }

        [HttpPost("editar/pessoa-juridica")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPessoaJuridica(ClienteVM model)
        {
            if (ModelState.IsValid)
            {
                model.Pessoa.TipoPessoa = TipoPessoa.Juridica;
                pessoasAppServices.AtualizarCliente(model);
                return RedirectToAction("Index");
            }
            else
                return View("EditJuridica", model);
        }
    }
}