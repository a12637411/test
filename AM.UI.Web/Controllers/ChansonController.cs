using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class ChansonController : Controller
    {
        IServiceChanson sc;
        IServiceArtiste sa;
        public ChansonController(IServiceChanson sc, IServiceArtiste sa)
        {
            this.sc = sc;
            this.sa = sa;
        }
    
        // GET: ChansonController
        public ActionResult Index()
        {
            return View(sc.GetMany().OrderBy(c=>c.VuesYoutube));
        }

        // GET: ChansonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChansonController/Create
        public ActionResult Create()
        {
            ViewBag.ArtisteFk = new SelectList(sa.GetMany(), "ArtisteId", "FullName");
            return View();
        }

        // POST: ChansonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chanson collection)
        {
            try
            {
                sc.Add(collection);
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChansonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChansonController/Edit/5
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

        // GET: ChansonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChansonController/Delete/5
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
