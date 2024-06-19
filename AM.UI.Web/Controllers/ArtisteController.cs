using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.Web.Controllers
{
    public class ArtisteController : Controller
    {
        IServiceArtiste sa;
        public ArtisteController(IServiceArtiste sa)
        {
            this.sa = sa;
        }
    
        // GET: ArtisteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArtisteController/Details/5
        public ActionResult Details(int id)
        {
            return View(sa.GetById(id));
        }

        // GET: ArtisteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtisteController/Create
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

        // GET: ArtisteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtisteController/Edit/5
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

        // GET: ArtisteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtisteController/Delete/5
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
