using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class LocationController : Controller
    {
         // GET: Location
        TasteContext context = new TasteContext();
        public ActionResult LocationList()
        {
            var values = context.Locations.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
            return RedirectToAction("LocationList");
        }

        public ActionResult DeleteLocation(int id)
        {
            var value = context.Locations.Find(id);
            context.Locations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("LocationList");

        }

        [HttpGet]
        public ActionResult UpdateLocation(int id)
        {
            var value = context.Locations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateLocation(Location location)
        {
            var value = context.Locations.Find(location.LocationId);
            value.Title = location.Title;
            value.Description = location.Description;
            context.SaveChanges();
            return RedirectToAction("LocationList");
        }
    }
}