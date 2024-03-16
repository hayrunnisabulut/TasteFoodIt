using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class SliderInfoController : Controller
    {
        // GET: SliderInfo
        TasteContext context = new TasteContext();
        public ActionResult SliderInfoList()
        {
            var values = context.SliderInfos.ToList();
            ViewBag.v = values.Count();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSliderInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSliderInfo(SliderInfo sliderInfo)
        {
            context.SliderInfos.Add(sliderInfo);
            context.SaveChanges();
            return RedirectToAction("SliderInfoList");
        }

        public ActionResult DeleteSliderInfo(int id)
        {
            var value = context.SliderInfos.Find(id);
            context.SliderInfos.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SliderInfoList");

        }

        [HttpGet]
        public ActionResult UpdateSliderInfo(int id)
        {
            var value = context.SliderInfos.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSliderInfo(SliderInfo sliderInfo)
        {
            var value = context.SliderInfos.Find(sliderInfo.SliderInfoId);
            value.Title = sliderInfo.Title;
            value.Info = sliderInfo.Info;
            value.ImageUrl = sliderInfo.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("SliderInfoList");
        }
    }
}