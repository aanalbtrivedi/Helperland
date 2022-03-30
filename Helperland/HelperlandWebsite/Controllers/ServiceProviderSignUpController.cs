using HelperlandWebsite.CommonUse;
using HelperlandWebsite.Data;
using HelperlandWebsite.Models;
using HelperlandWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.Controllers
{
    public class ServiceProviderSignUpController : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        public ServiceProviderSignUpController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult ServiceProviderSignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ServiceProviderSignUp(UserResgistrtionViewModel userResgistrtionViewModel)
        {
            User check = _helperlandContext.Users.Where(u => u.Email == userResgistrtionViewModel.Email).FirstOrDefault();
            if (check == null)
            {
                User user = new User();
                user.FirstName = userResgistrtionViewModel.FirstName;
                user.LastName = userResgistrtionViewModel.LastName;
                user.Email = userResgistrtionViewModel.Email;
                user.UserTypeId = StaticValue.SP_Type;
                user.Mobile = userResgistrtionViewModel.MobileNumber;
                user.Password = userResgistrtionViewModel.Password;
                user.CreatedDate = DateTime.Now.Date;
                _helperlandContext.Users.Add(user);
                _helperlandContext.SaveChanges();
                ViewBag.Message = "Service Provider Registered Succussfully.";
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.Message = "This Email is already registered.";
                ModelState.Clear();
                return View();
            }
        }
    }
}
