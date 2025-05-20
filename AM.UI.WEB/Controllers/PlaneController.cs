using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class PlaneController : Controller
    {
        IServiceFlight sf;
        IServicePlane sp;

        public PlaneController(IServiceFlight sf, IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }

        // GET: PlaneController
        public ActionResult Index()
        {
            return View(sp.GetMany());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            return View(sp.GetById(id));
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane collection)
        {
            try
            {   //ajout dans la base de données
                sp.Add(collection);
                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int id)
        {

            var plane = sp.GetById(id);
            if (plane == null)
            {
                return NotFound();
            }
            return View(plane);
        }

        // POST: PlaneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Plane plane)
        {
            if (id != plane.PlaneId)
            {
                return NotFound();
            }
            try
            {

                sp.Update(plane);
                sp.Commit();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(plane);
            }
        }

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sp.GetById(id));
        }

        // POST: PlaneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Plane collection)
        {
            try
            {
                sp.Delete(sp.GetById(id));

                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}