using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jinx.J002.FrontEndZone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LanhuMedia()
        {
            return View();
        }

        public ActionResult MovieList()
        {
            return View();
        }

        public ActionResult MovieIndex()
        {
            return View();
        }

        public ActionResult MovieSearch()
        {
            return View();
        }

        public ActionResult NavigateBar()
        {
            return View();
        }

        public ActionResult CelebIndex()
        {
            return View();
        }
    }
}