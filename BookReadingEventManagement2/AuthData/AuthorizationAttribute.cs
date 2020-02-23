using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReadingEventManagement2.Models;

namespace BookReadingEventManagement2.AuthData
{
    public class AuthorizationAttribute:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool Authorize = false;
            UserViewModel User = (UserViewModel)httpContext.Session["User"];
            if(User.UserID == 0)
            {
                Authorize = true;
            }
            //            return base.AuthorizeCore(httpContext);
            return Authorize;
        }
    }
}