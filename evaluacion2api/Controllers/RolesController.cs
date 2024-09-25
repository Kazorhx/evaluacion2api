using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace evaluacion2api.Controllers
{
    public class RolesController : Controller
    {
        // GET: RolosController
        public async ActionResult Index(T)
        {
            return View();
        }

        // GET: RolosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolosController/Create
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

        // GET: RolosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolosController/Edit/5
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

        // GET: RolosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolosController/Delete/5
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
