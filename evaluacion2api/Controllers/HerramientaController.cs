using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace evaluacion2api.Controllers
{
    public class HerramientaController : Controller
    {
        // GET: HerramientaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HerramientaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HerramientaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HerramientaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HerramientaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HerramientaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HerramientaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HerramientaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
