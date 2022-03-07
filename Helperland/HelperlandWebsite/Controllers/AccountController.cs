using HelperlandWebsite.CommonUse;
using HelperlandWebsite.Data;
using HelperlandWebsite.Models;
using HelperlandWebsite.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace HelperlandWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        private String Message = "Default Message";

        public AccountController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult Signup()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            ViewBag.HasError = false;
            ViewBag.Success = false;
            ViewBag.ErrorMessage = "Please enter valid details";
            ViewBag.SuccessMessage = "User is successfully registered!";

            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.Email = user.Email;
            user.UserTypeId = StaticValue.CustomerType;
            user.Mobile = user.Mobile;
            user.Password = user.Password;
            user.CreatedDate = DateTime.Now.Date;

            // Entry to database
            _helperlandContext.Users.Add(user);
            _helperlandContext.SaveChanges();


            if (ViewBag.HasError == true)
            {
                ViewBag.ErrorMessage = GetErrorMessage();
                ViewBag.HasError = true;
            }
            else
            {
                ViewBag.Success = true;
                ModelState.Clear();
            }
            return View();

            
        }

        public IActionResult Cust_Signup()
        {
            Cust_SignupViewModel cust_SignupViewModel = new Cust_SignupViewModel();
            return View(cust_SignupViewModel);
        }

        [HttpPost]
        public IActionResult Cust_Signup(Cust_SignupViewModel cust_SignupViewModel)
        {
            ViewBag.HasError = false;
            ViewBag.Success = false;
            ViewBag.ErrorMessage = "Please enter valid details";
            ViewBag.SuccessMessage = "User is successfully registered!";

            User user = new User();
            user.FirstName = cust_SignupViewModel.FirstName;
            user.LastName = cust_SignupViewModel.LastName;
            user.Email = cust_SignupViewModel.Email;
            user.UserTypeId = StaticValue.CustomerType;
            user.Mobile = cust_SignupViewModel.MobileNumber;
            user.Password = cust_SignupViewModel.Password;
            user.CreatedDate = DateTime.Now.Date;

            // Entry to database
            _helperlandContext.Users.Add(user);
            _helperlandContext.SaveChanges();


            if (ViewBag.HasError == true)
            {
                ViewBag.ErrorMessage = GetErrorMessage();
                ViewBag.HasError = true;
            }
            else
            {
                ViewBag.Success = true;
                ModelState.Clear();
            }
            return View();


        }

        public IActionResult SP_Signup()
        {
            User user = new User();
            return View();
        }

        [HttpPost]
        public IActionResult SP_Signup(User user)
        {
            _helperlandContext.Users.Add(user);
            _helperlandContext.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (IsValidUser(loginViewModel))
                {
                    HttpContext.Session.SetString("email", loginViewModel.Email);
                    return RedirectToAction("Book_now", "BookService");

                }
                else
                {
                    ViewBag.IsLoginOpen = true;
                    ViewBag.HasError = true;
                    ViewBag.ErrorMessage = GetErrorMessage();
                    return View();
                }
            }
            else
            {
                ViewBag.IsLoginOpen = true;
                ViewBag.HasError = true;
                ViewBag.ErrorMessage = "Please enter valid details";
                return View();
            }
        }
        public string GetErrorMessage()
        {
            return Message;
        }
        public Boolean IsUserEmailExists(string _email)
        {
            User result = _helperlandContext.Users.Where(u => u.Email == _email).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            Message = _email + " is not registered yet!";
            return false;
        }
        public Boolean IsValidUser(LoginViewModel loginViewModel)
        {
            if (IsUserEmailExists(loginViewModel.Email))
            {
                try
                {
                    User result = _helperlandContext.Users.Where(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password).FirstOrDefault();
                    if (result != null)
                    {
                        return true;
                    }
                    else
                    {
                        Message = "Username or Password is invalid";
                        return false;
                    }
                }
                catch
                {
                    Message = "Internal Server Error";
                    return false;
                }

            }
            else
            {
                return false;
            }

        }


        public IActionResult CustomerResgistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerResgistration(UserResgistrtionViewModel userResgistrtionViewModel)
        {
            ViewBag.HasError = false;
            ViewBag.Success = false;
            ViewBag.ErrorMessage = "Please enter valid details";
            ViewBag.SuccessMessage = "User is successfully registered!";
            

            if (ModelState.IsValid)
            {

                if (AddUser(userResgistrtionViewModel,StaticValue.CustomerType))
                {
                    ViewBag.Success = true;
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.ErrorMessage = GetErrorMessage();
                    ViewBag.HasError = true;
                }

                return View();
            }
            else
            {
                ViewBag.HasError = true;
                return View();
            }
        }
        public Boolean IsUserExists(string _email)
        {
            User result = _helperlandContext.Users.Where(u => u.Email == _email).FirstOrDefault();
            if (result != null)
            {
                Message = "Someone is already registred with " + _email;
                return true;
            }
            return false;
        }
        public Boolean AddUser(UserResgistrtionViewModel _userRegistrationViewModel, int _userTypeId)
        {
            if (!IsUserExists(_userRegistrationViewModel.Email))
            {
                try
                {
                    // User model
                    User user = new User();
                    user.FirstName = _userRegistrationViewModel.FirstName;
                    user.LastName = _userRegistrationViewModel.LastName;
                    user.Email = _userRegistrationViewModel.Email;
                    user.UserTypeId = _userTypeId;
                    user.Mobile = _userRegistrationViewModel.MobileNumber;
                    user.Password = _userRegistrationViewModel.Password;
                    user.CreatedDate = DateTime.Now.Date;

                    // Entry to database
                    _helperlandContext.Users.Add(user);
                    _helperlandContext.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public IActionResult SP_Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SP_Registration(UserResgistrtionViewModel userRegistrationViewModel)
        {

            ViewBag.HasError = false;
            ViewBag.Success = false;
            ViewBag.ErrorMessage = "Please enter valid details";
            ViewBag.SuccessMessage = "User is successfully registered!";
            

            if (ModelState.IsValid)
            {
                if (AddUser(userRegistrationViewModel,StaticValue.SP_Type))
                {
                    ViewBag.Success = true;
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.ErrorMessage = GetErrorMessage();
                    ViewBag.HasError = true;
                }
                return View();
            }
            else
            {
                ViewBag.HasError = true;
                return View();
            }

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        //[HttpPost]
        //[Route("ForgotPassword")]
        //public ActionResult ForgotPassword(Models.ForgotPassword model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var isExist = IsEmailExist(model.Email);
        //        if (isExist == false)
        //        {
        //            ModelState.AddModelError("Email", "Email Does not exist");
        //            return View(model);
        //        }
        //        UserTable obj = dbobj.UserTable.Where(x => x.Email == model.Email).FirstOrDefault();
        //        string pwd = Membership.GeneratePassword(6, 2);
        //        obj.Password = Crypto.Hash(pwd);
        //        dbobj.SaveChanges();
        //        SendPassword(obj.Email, pwd);
        //        TempData["Success"] = "New password has been sent to your email";
        //    }
        //    return RedirectToAction("ForgotPassword");
        //}

        //[NonAction]
        //public void SendPassword(string emailID, string pwd)
        //{
        //    var fromEmail = new MailAddress("");//temp@gmail.com
        //    var toEmail = new MailAddress(emailID);
        //    var fromEmailPassword = "";//abc123
        //    string subject = "Note Marketplace - Forgot Password";

        //    string body = "Hello," +
        //        "<br/><br/>We have generated a new password for you" +
        //        "<br/><br/>Password: " + pwd +
        //        "<br/><br/>Regards,<br/>Notes Marketplace";

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
        //    };

        //    using (var message = new MailMessage(fromEmail, toEmail)
        //    {
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true
        //    })
        //    smtp.Send(message);
        //}
    }

}
