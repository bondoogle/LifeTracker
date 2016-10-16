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
            if (!User.Identity.IsAuthenticated)
                return Json(new { Status = "401", Message = "Unauthorized request" });

            
            if(form.ChoreName == null || form.ChoreType == null)
            {
                if (HttpContext.Request.IsAjaxRequest())
                {
                    return Json(new { result = "failure", error = "invalid_values" });
                }
            }

            var user = VerifyUser();
            var c = new DB.Chore();
            c.ChoreName = form.ChoreName;
            try {
                c.ChoreType = (DB.ChoreType)Enum.Parse(typeof(DB.ChoreType), form.ChoreType);
            }catch(Exception ex)
            {
                return Json(new { result = "failure", error = "invalid_chore_type" });
            }
            c.ChoreDescription = form.ChoreDescription;
            //c.DateCreated = DateTime.Now;
            user.Chores.Add(c);
            _userrepo.Save();
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new { result="success", newchore=c });
            }
            else
            {
                return RedirectToAction("Chores");
            }
        }
        
        public ActionResult RemoveChore(int choreid)
        {
            if (!User.Identity.IsAuthenticated)
                return Json(new { Status = "401", Message = "Unauthorized request" });


            if (choreid <= 0)
            {
                if (HttpContext.Request.IsAjaxRequest())
                {
                    return Json(new { result = "failure", error = "invalid_values" });
                }
            }

            var user = VerifyUser();

            var c = _userrepo.GetUserChore(user, choreid);
            //c.DateCreated = DateTime.Now;
            user.Chores.Remove(c);
            _userrepo.Save();
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new { result = "success", oldchoreid=c.ChoreId});
            }
            else
            {
                return RedirectToAction("Chores");
            }
        }
        //TODO: Still need to add Edit, View, and Delete of Chores


        //TODO: Still need to add Add, Edit, View, and Delete of Projects

        //TODO: Still need to add Add, Edit, View, and Delete of Timers
        public ActionResult TimeTracker()
        {
            return View();
        }

        //TODO: Still need to add Settings page
        public ActionResult Settings()
        {
            return View();
        }
    }
}