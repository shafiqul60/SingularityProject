﻿using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Security;

namespace UI.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorizationFilter(Roles ="Admin")]
    public class BaseController : Controller
    {
        protected IUnitOfWork uow;

        public BaseController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
            
        }
    }
}