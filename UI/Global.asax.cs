using DomainModels.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using UI.Security;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                if (!ticket.Expired)
                {
                    UserViewModel model = JsonConvert.DeserializeObject<UserViewModel>(ticket.UserData);

                    CustomPrincipal user = new CustomPrincipal(model.UserName);

                    user.UserId = model.UserId;
                    user.UserName = model.UserName;
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.ContactNo = model.ContactNo;
                    user.Roles = model.Roles;

                    HttpContext.Current.User = user;

                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Account/Login");
                }
            }
        }

    }
}
