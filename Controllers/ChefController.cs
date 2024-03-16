using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ChefController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ChefList()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateChef(Chef chef)
        {
            context.Chefs.Add(chef);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }

        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ChefList");

        }

        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateChef(Chef chef)
        {
            var value = context.Chefs.Find(chef.ChefId);
            value.NameSurname = chef.NameSurname;
            value.Description = chef.Description;
            value.ImageUrl = chef.ImageUrl;
            value.Title = chef.Title;
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
    }
}