using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace evaluacion2api.DTOS
{
    public class DTOS : Controller
    {
        // GET: DTOS
        public ActionResult Index()
        {
            return View();
        }

        // GET: DTOS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DTOS/Create
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

        // GET: DTOS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DTOS/Edit/5
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

        // GET: DTOS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DTOS/Delete/5
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
