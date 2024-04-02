using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ProfileController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult Index()
        {

            ViewBag.username = Session["username"];
            ViewBag.userid = Session["userid"];
            return View();
        }

        [HttpGet]
        public ActionResult UpdatePassword(int id)
        {
            var value = context.Admins.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdatePassword(Admin admin)
        {
            var value = context.Admins.Find(admin.AdminId);
            value.Password = admin.Password;
            value.UserName = admin.UserName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}