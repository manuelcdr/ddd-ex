using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGLaw.Application.Contratos.Interfaces.Services;
using PGLaw.Application.Contratos.Models.Contratos;
using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize(Policy = "AcessoUrl")]

    public class ContratosController : Controller
    {
        private readonly IContratosAppServices contratosAppServices;
        private readonly IPessoasAppServices pessoasAppServices;

        public ContratosController(IContratosAppServices contratosAppServices, IPessoasAppServices pessoasAppServices)
        {
            this.contratosAppServices = contratosAppServices;
            this.pessoasAppServices = pessoasAppServices;
        }

        // GET: Contratos
        public ActionResult Teste()
        {
            return View();
        }

        // GET: Contratos
        public ActionResult Index()
        {

            var listaContratos = contratosAppServices.BuscarContratosCompleto();
            return View(listaContratos);
        }

        // GET: Contratos/Edit/5
        [HttpGet("/Contratos/Filter")]
        public ActionResult Filter(string Status)
        {
            var listaContratos = contratosAppServices.BuscarContratosCompleto();
            return PartialView("_ListaContratos", listaContratos);
            //return View();
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contratos/Create
        [HttpGet("/Contratos/Create/")]
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(contratosAppServices.BuscarTipos(), "Id", "Descricao");
            ViewBag.Gerencia = new SelectList(contratosAppServices.BuscarGerencias(), "Id", "Descricao");
            ViewBag.IndiceReajuste = new SelectList(contratosAppServices.BuscarIndicesReajuste(), "Id", "Descricao");
            ViewBag.Vigencia = new SelectList(contratosAppServices.BuscarVigencias(), "Id", "Descricao");
            ViewBag.FomaPagamento = new SelectList(contratosAppServices.BuscarFormasPagamento(), "Id", "Descricao");
            ViewBag.TipoServico = new SelectList(contratosAppServices.BuscarTiposServicos(), "Id", "Descricao");

            return PartialView("_EditContrato", new ContratoVM());
            //return View();
        }


        // POST: Contratos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Contratos/Edit/5
        [HttpGet("/Contratos/Edit/{id}")]
        public ActionResult Edit(Guid id)
        {
            ViewBag.Tipo = new SelectList(contratosAppServices.BuscarTipos(), "Id", "Descricao");
            ViewBag.Gerencia = new SelectList(contratosAppServices.BuscarGerencias(), "Id", "Descricao");
            ViewBag.IndiceReajuste = new SelectList(contratosAppServices.BuscarIndicesReajuste(), "Id", "Descricao");
            ViewBag.Vigencia = new SelectList(contratosAppServices.BuscarVigencias(), "Id", "Descricao");
            ViewBag.FomaPagamento = new SelectList(contratosAppServices.BuscarFormasPagamento(), "Id", "Descricao");
            ViewBag.TipoServico = new SelectList(contratosAppServices.BuscarTiposServicos(), "Id", "Descricao");


            var Contrato = contratosAppServices.ObterContrato(Guid.Parse(id.ToString()));
            return PartialView("_EditContrato", Contrato);
            //return View();
        }

        //[HttpPost]
        //public JsonResult Upload()
        //{
        //    bool isEmpty = true;
        //    foreach (IFormFile fileName in Request.Form.Files)
        //    {
        //        // File file = Request.Form.Files[fileName];
        //        isEmpty = false;
        //    }
        //    if (isEmpty)
        //    {
        //        return Json("Error ");
        //    }
        //    else
        //    {
        //        return Json(Request.Form.Files);
        //    }
        //}

        [HttpPost]
        public IActionResult Upload(List<IFormFile> file)
        {
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Contratos");



            foreach (IFormFile fileName in Request.Form.Files)
            {
                // File file = Request.Form.Files[fileName];
            }
            return RedirectToAction("Index");
        }

        [HttpPost("/Contratos/EditContrato/")]
        [ValidateAntiForgeryToken]
        public ActionResult EditContrato(ContratoVM model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files != null)
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Form.Files.Count; i++)
                        {
                            if (model.DocumentoContratos != null)
                            {
                                // configurar nome do arquivo com o mesmo guid da chave primaria
                                if (model.DocumentoContratos != null)
                                {
                                    Guid DocumentoGuid = SequentialGuidGenerator.Generate();
                                    model.DocumentoContratos[i].Id = DocumentoGuid;
                                    model.DocumentoContratos[i].NomeArquivo = DocumentoGuid.ToString().ToUpper() + Request.Form.Files[i].FileName.Substring(Request.Form.Files[i].FileName.LastIndexOf('.'));
                                }

                                // full path to file in temp location
                                var filePath = Path.Combine(
                                        Directory.GetCurrentDirectory(), "wwwroot", "Contratos",
                                        model.Id.ToString());

                                if (!Directory.Exists(filePath))
                                {
                                    Directory.CreateDirectory(filePath);
                                }

                                filePath = Path.Combine(filePath, model.DocumentoContratos[i].NomeArquivo);

                                if (Request.Form.Files[i].Length > 0)
                                {
                                    using (var stream = new FileStream(filePath, FileMode.Create))
                                    {
                                        Request.Form.Files[i].CopyTo(stream);
                                    }
                                }


                            }
                        }
                    }
                }

                if (model.Id == Guid.Empty)
                    contratosAppServices.CriarContrato(model);
                else
                    contratosAppServices.AtualizaContrato(model);

                var listaContratos = contratosAppServices.BuscarContratosCompleto();
                return PartialView("_ListaContratos", listaContratos);
            }
            else
            {
                var listaContratos = contratosAppServices.BuscarContratosCompleto();
                return PartialView("_ListaContratos", listaContratos);
            }
        }

        // POST: Contratos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Contratos/Delete/5
        [HttpGet("/Contratos/Delete/{id}")]
        public ActionResult Delete(Guid id)
        {            
            contratosAppServices.ExcluirContrato(id);

            return RedirectToAction("Index");
        }

        // POST: Contratos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }




    }
}