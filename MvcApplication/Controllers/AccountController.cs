using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            var model= new Login();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (!ModelState.IsValid)  
            
            return View();
            string user = "admin", pwd = "admin";
            if(model.UserName==user && model.Password == pwd)
            {
                //?? -->NULL coalescing  operator
                string returnUrl = Request.QueryString["ReturnUrl"]??"~/";
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                Session["user"] = model;
                return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Bad username/password.");
                return View(model);
            }
        }
    }
}