using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebContratos.Controllers
{
    public class EnderecosController : Controller
    {

        // GET: Enderecos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Enderecos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Create
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

        // GET: Enderecos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Enderecos/Edit/5
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

        // GET: Enderecos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Enderecos/Delete/5
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