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
    public class CustomerSignUpController : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        public CustomerSignUpController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult CustomerSignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerSignUp(Cust_SignupViewModel cust_SignupViewModel)
        {
            User check = _helperlandContext.Users.Where(u => u.Email == cust_SignupViewModel.Email).FirstOrDefault();
            if (check == null)
            {
                User user = new User();
                user.FirstName = cust_SignupViewModel.FirstName;
                user.LastName = cust_SignupViewModel.LastName;
                user.Email = cust_SignupViewModel.Email;
                user.UserTypeId = StaticValue.CustomerType;
                user.Mobile = cust_SignupViewModel.MobileNumber;
                user.Password = cust_SignupViewModel.Password;
                user.CreatedDate = DateTime.Now.Date;
                _helperlandContext.Users.Add(user);
                _helperlandContext.SaveChanges();
                ViewBag.Message = "User Registered Succussfully.";
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
