using DomainModels.Entities;
using DomainModels.ViewModels;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Controllers
{
    public class AccountController : BaseController
    {

       // IUnitOfWork uow;
        
        public AccountController(IUnitOfWork _uow) :base(_uow)
        {
            uow = _uow;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                UserViewModel user = uow.AuthenticateRepository.ValidateUser(model);

                if(user != null)
                {

                    string data = JsonConvert.SerializeObject(user);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, data);
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(cookie);


                    if(user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
                else
                {
                    ViewBag.Fmsg = "The Email or Password provided is incorrect!";
                }

            }
           
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User model)
        {
            try
            {
              
                Role r2 = new Role { Name = "User", Description = "End User" };
                model.Roles.Add(r2);
               
                uow.UserRepository.Add(model);
                uow.SaveChanges();
                return RedirectToAction("UserList");                
                                                                         
            }
            catch (Exception)
            {
                throw;
            }
        
          
        }

        public ActionResult UnAuthorize()
        {
            return View();
        }


        public ActionResult UserList()
        {
            IEnumerable<User> data = uow.UserRepository.GetAll();
            return View(data);
           
        }

        public ActionResult Edit(int Id)
        {

            User user = uow.UserRepository.GetById(Id);
           
            if (user != null)
            {
                return View("SignUp", user);
            }
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            try
            {
                if (ModelState.IsValid)
                {                 
                    uow.UserRepository.Update(model);
                    uow.SaveChanges();
                    return RedirectToAction("UserList");

                }
            }
            catch (Exception)
            {
                throw;
            }
            return View();


        }

        public ActionResult Delete(int Id)
        {
            User user = uow.UserRepository.GetById(Id);

            if (user != null)
            {
                uow.UserRepository.DeleteById(Id);
                uow.SaveChanges();
                return RedirectToAction("UserList");
            }

            else
            {
                return RedirectToAction("UserList");
            }          
        }

    }
}