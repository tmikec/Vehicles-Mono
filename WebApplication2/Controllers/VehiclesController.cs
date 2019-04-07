using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class VehiclesController : Controller
    {
        VehiclesEntities db = new VehiclesEntities();
        
        public ActionResult Index()
        {

            return View(db.VehicleMakes.ToList()); // Index prikazuje tablicu koju iscitava iz databaze
        }
        [HttpGet] // HttpGet dobiva request za kreiranje entiteta
        public ActionResult Create()
        {
            return View(new VehicleMake());
        }
        [HttpPost] // HttpPost salje request za kreiranje entiteta databazi
        public ActionResult Create(VehicleMake vehicle)
        {
            if (ModelState.IsValid)
            {
                db.VehicleMakes.Add(vehicle);
              db.SaveChanges(); // Spremanje entiteta u databazu te povratak na Index stranicu
                return RedirectToAction("Index");
                    }
            else { return View(vehicle); }
        }
        public ActionResult Details(int? id) // id moze biti null
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Ako je id null prikazuje se Bad Request
            }
            VehicleMake vehicle = db.VehicleMakes.Find(id); // Pretrazivanje po id-u iz databaze
            if (vehicle == null)
            {
                return HttpNotFound(); // Ako je id null prikazuje se HttpNotFound 
            }
            return View(vehicle);
        }
    }

}