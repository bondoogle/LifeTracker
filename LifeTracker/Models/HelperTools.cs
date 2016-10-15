using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeTracker.Models
{
    public class HelperTools
    {
    }

    public abstract class CustomController : Controller
    {
        protected DAL.UserRepository _userrepo;
        protected string _useremail { get { return HttpContext.User.Identity.Name; } }

        public CustomController()
        {
            _userrepo = new DAL.UserRepository(new Models.DB.Context());
        }

        protected DB.User VerifyUser()
        {
            var user = _userrepo.GetUser(_useremail);
            if (user == null)
            {
                var u = new DB.User();
                u.Email = _useremail;
                u.DateCreated = DateTime.Now;
                u.Active = true;
                _userrepo.AddUser(u);
                _userrepo.Save();

                user = u;
            }

            return user;
        }

        protected override void Dispose(bool disposing)
        {
            _userrepo.Dispose();
            base.Dispose(disposing);
        }
    }
}