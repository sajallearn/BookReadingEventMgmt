using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using BookReadingEventManagement2.Models;
using System.Web.Routing;

namespace BookReadingEventManagement2.AuthData
{
    public class AuthAttribute:ActionFilterAttribute,IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            UserViewModel User = (UserViewModel)filterContext.HttpContext.Session["User"];
            if (User == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login"}));
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
           
        }
    }
}