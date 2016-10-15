using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LifeTracker.Models;

namespace LifeTracker.Controllers
{
    public class ProjectManagerController : CustomController
    {
        // GET: ProjectManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chores()
        {
            var user = VerifyUser();
            ViewBag.UserName = user.UserName;

            var result = new ChoreModels();
            result.Chores = _userrepo.GetUserChores(user);

            return View(Json(result));
        }

        public ActionResult AddChore(FormViewModels.AddChoreFormModel form)
        {
            var user = VerifyUser();
            var c = new DB.Chore();
            c.ChoreName = form.ChoreName;
            c.ChoreType = (DB.ChoreType)Enum.Parse(typeof(DB.ChoreType), form.ChoreType);
            c.ChoreDescription = form.ChoreDescription;
            c.DateCreated = DateTime.Now;
            user.Chores.Add(c);
            _userrepo.Save();
            return RedirectToAction("Chores");
        }
            
        public ActionResult TimeTracker()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }
    }
}