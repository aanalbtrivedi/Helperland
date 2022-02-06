using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelperlandWebsite.Models;
using System.Web.Security;

namespace HelperlandWebsite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new HelperlandEntities())
            {
                bool isValid = context.User.Any(x => x.Email == model.Email && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email,false);
                    return RedirectToAction("Index", "Users");
                }
                ModelState.AddModelError("", "Invalid");
                return View();
            }
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {
            using(var context = new HelperlandEntities())
            {
                context.Configuration.ValidateOnSaveEnabled = false;
                context.User.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Become_a_helper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Become_a_helper(User model)
        {
            using (var context = new HelperlandEntities())
            {
                context.Configuration.ValidateOnSaveEnabled = false;
                context.User.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}