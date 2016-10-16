using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using LifeTracker.Models;

namespace LifeTracker
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
        
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {

            base.OnAuthentication(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            base.OnAuthenticationChallenge(filterContext);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            base.HandleUnknownAction(actionName);
        }


        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void Execute(RequestContext requestContext)
        {
            base.Execute(requestContext);
        }

        protected override void EndExecuteCore(IAsyncResult asyncResult)
        {
            base.EndExecuteCore(asyncResult);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
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