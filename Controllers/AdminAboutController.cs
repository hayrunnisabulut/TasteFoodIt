using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminAboutController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult About()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutId);
            value.Description = about.Description;
            value.Title = about.Title;
            value.ImageUrl = about.ImageUrl;     
            context.SaveChanges();
            return RedirectToAction("About");
        }
    }
}