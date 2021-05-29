using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Security
{
    public class CustomAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public string Roles {get; set;}

        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (!filterContext.RequestContext.HttpContext.User.IsInRole(Roles))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                { Controller = "Account", Action = "UnAuthorize", area = "" }));
            }
        }
    }
}