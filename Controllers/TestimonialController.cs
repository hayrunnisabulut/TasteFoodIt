using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class TestimonialController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Testimonial()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial p)
        {
            context.Testimonials.Add(p);
            context.SaveChanges();
            return RedirectToAction("Testimonial");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Testimonial");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial p)
        {
            var value = context.Testimonials.Find(p.TestimonialId);
            value.ImageUrl = p.ImageUrl;
            value.NameSurname = p.NameSurname;
            value.Description = p.Description;
            value.Title = p.Title;
            context.SaveChanges();
            return RedirectToAction("Testimonial");
        }
    }
}