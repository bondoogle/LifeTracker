using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LifeTracker.Models;

namespace LifeTracker.Controllers
{
    public class HomeController : CustomController
    {
        public ActionResult Index()
        {
            var user = VerifyUser();
            ViewBag.UserName = user.UserName;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }               
    }
}