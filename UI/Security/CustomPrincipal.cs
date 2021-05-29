using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace UI.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string UserName)
        {
            Identity = new GenericIdentity(UserName);
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }  

        public string[] Roles { get; set; }

        public IIdentity Identity { private set; get; }

        public bool IsInRole(string role)
        {
            if(Roles.Any(r=>role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}