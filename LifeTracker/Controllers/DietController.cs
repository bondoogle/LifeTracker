using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeTracker.Controllers
{
    public class DietController : Controller
    {
        // GET: Diet
        public ActionResult Index()
        {
            return View();
        }
    }
}