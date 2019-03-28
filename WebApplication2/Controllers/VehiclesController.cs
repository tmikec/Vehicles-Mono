using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class VehiclesController : Controller
    {
        VehiclesEntities db = new VehiclesEntities();
        
        public ActionResult Index()
        {

            return View(db.VehicleMakes.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new VehicleMake());
        }
        [HttpPost]
        public ActionResult Create(VehicleMake vehicle)
        {
            if (ModelState.IsValid)
            {
                db.VehicleMakes.Add(vehicle);
              db.SaveChanges();
                return RedirectToAction("Index");
                    }
            else { return View(vehicle); }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicle = db.VehicleMakes.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }
    }

}