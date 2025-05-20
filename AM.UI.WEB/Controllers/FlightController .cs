using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;
using AM.ApplicationCore.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight _sf;
        private readonly IServicePlane _sp;

        public FlightController(IServiceFlight sf, IServicePlane sp)
        {
            _sf = sf;
            _sp = sp;
        }

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(_sf.GetAll().ToList());
            else
                return View(_sf.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
        }


        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var flight = _sf.GetById(id);
            if (flight == null)
                return NotFound();

            return View(flight);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.planeFK = new SelectList(_sp.GetMany(), "PlaneId", "Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null && PilotImage.Length > 0)
                {
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    Directory.CreateDirectory(uploadPath); // ensure the directory exists

                    var filePath = Path.Combine(uploadPath, PilotImage.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }

                    collection.Pilot = PilotImage.FileName;
                }

                _sf.Add(collection);
                _sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.planeFK = new SelectList(_sp.GetMany(), "PlaneId", "Information");
                return View(collection);
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var flight = _sf.GetById(id);
            if (flight == null)
                return NotFound();

            ViewBag.planeFK = new SelectList(_sp.GetMany(), "PlaneId", "Information", flight.PlaneFK);
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection, IFormFile PilotImage)
        {
            try
            {
                var existingFlight = _sf.GetById(id);
                if (existingFlight == null)
                    return NotFound();

                if (PilotImage != null && PilotImage.Length > 0)
                {
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, PilotImage.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }

                    collection.Pilot = PilotImage.FileName;
                }
                else
                {
                    collection.Pilot = existingFlight.Pilot; // retain old image if no new image uploaded
                }

                _sf.Update(collection);
                _sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.planeFK = new SelectList(_sp.GetMany(), "PlaneId", "Information", collection.PlaneFK);
                return View(collection);
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            var flight = _sf.GetById(id);
            if (flight == null)
                return NotFound();

            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var flight = _sf.GetById(id);
                if (flight == null)
                    return NotFound();

                _sf.Delete(flight);
                _sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sort flights
        public ActionResult Sort()
        {
            return View("Index", _sf.SortFlights());
        }
    }
}
