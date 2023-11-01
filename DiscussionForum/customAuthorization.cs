using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace DiscussionForum
{
    public class customAuthorization : AuthorizeAttribute
    {
        //       public override void OnAuthorization(AuthorizationContext filterContext)
        //       {



        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated &&
                string.Equals(controllerName, "Admin", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(actionName, "AdminLogin", StringComparison.OrdinalIgnoreCase))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Admin", action = "AdminLogin" }));

            }

        }  
    }
            
        }
    