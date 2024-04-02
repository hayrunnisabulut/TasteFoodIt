using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = context.Admins.FirstOrDefault(x=> x.UserName==p.UserName && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName,false);
                Session["username"] = values.UserName;
                Session["userid"] = values.AdminId;
                ViewBag.v = Session["username"];
                return RedirectToAction("Index","Profile");
            }
            return View();
        }

    }
}