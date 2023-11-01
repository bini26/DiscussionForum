using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DiscussionForum
{

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public string[] Roles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthenticated = base.AuthorizeCore(httpContext);

            if (!isAuthenticated)
            {
                return false;
            }

            // Check if the user has the required roles
            foreach (var role in Roles)
            {
                if (!httpContext.User.IsInRole(role))
                {
                    return false;
                }
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // Redirect to login if not authenticated
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
            else
            {
                // Redirect to access denied page or show a message
                filterContext.Result = new ViewResult { ViewName = "AccessDenied" };
            }
        }
    }
}

