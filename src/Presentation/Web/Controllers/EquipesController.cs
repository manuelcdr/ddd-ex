using PGLaw.Application.Juridico.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EquipesController : Controller
    {
        private readonly IPessoasAppServices pessoasAppServices;

        public EquipesController(IPessoasAppServices pessoasAppServices)
        {
            this.pessoasAppServices = pessoasAppServices;
        }

        // GET: Equipes
        public ActionResult Index()
        {
            var listaEquipes = pessoasAppServices.ObterTodasEquipes();
            return View(listaEquipes);
        }

        // GET: Equipes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Equipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipes/Create
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

        // GET: Equipes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Equipes/Edit/5
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

        // GET: Equipes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Equipes/Delete/5
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
    }
}