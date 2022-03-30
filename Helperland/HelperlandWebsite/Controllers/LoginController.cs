using HelperlandWebsite.Models;
using HelperlandWebsite.ViewModels;
using HelperlandWebsite.CommonUse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelperlandWebsite.Data;
using MimeKit;
using MimeKit.Utils;

namespace HelperlandWebsite.Controllers
{
    public class LoginController : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        public string _msg;
        public string _email = "email";
        public string sendemail;
        public LoginController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            User user = _helperlandContext.Users.Where(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString(StaticValue.EmailSV, loginViewModel.Email);
                if(user.UserTypeId == 1)
                {
                    return RedirectToAction("CustomerDashboard", "Customer");
                }
                else if(user.UserTypeId == 2)
                {
                    return RedirectToAction("UpcomingServices", "ServiceProvider");
                }
                else 
                { 
                    return RedirectToAction("ServiceRequest", "AdminPanel");
                }
            }
            else 
            {
                User chkEmail = _helperlandContext.Users.Where(u => u.Email == loginViewModel.Email).FirstOrDefault();
                if(chkEmail == null)
                {
                    _msg = "Register this " + loginViewModel.Email;
                    ViewBag.message = _msg;
                    return View();
                }
                else
                {
                    _msg = "Either mail or Password is wrong.";
                    ViewBag.message = _msg;
                    return View();
                }

            }

        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
                //email = ViewBag.email;
                User user = _helperlandContext.Users.Where(u => u.Email == forgotPasswordViewModel.Email).FirstOrDefault();
                
                if (user != null)
                {
                    HttpContext.Session.SetString(_email, forgotPasswordViewModel.Email);
                    sendMail(forgotPasswordViewModel.Email);
                }
                
            }
            return RedirectToAction("ForgotPassword");
        }

        public IActionResult Index()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test", "aanalbtrivedi@gmail.com"));
            message.To.Add(new MailboxAddress("180540107173", "180540107173@darshan.ac.in"));
            message.Subject = "Test mail in asp.net";
            message.Body = new TextPart("plain")
            {
                Text = "Hello world mail"
            };
            using(var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("aanalbtrivedi@gmail.com","JAYMATAJI");
                client.Send(message);
                client.Disconnect(true);
            }
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
   
        public IActionResult ResetPassword()
        {
            //ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            //email = ViewBag.email;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            string getmail;
            if (ModelState.IsValid)
            {
                //ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
                //email = ViewBag.email;
                getmail = HttpContext.Session.GetString(_email);
                User user = _helperlandContext.Users.Where(u => u.Email == getmail).FirstOrDefault();
                user.Password = resetPasswordViewModel.newPassword;
                _helperlandContext.Users.Update(user);
                _helperlandContext.SaveChanges();
            }
            return View();
        }
        public void sendMail(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("180540107173", "180540107173@darshan.ac.in"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "Reset your Password";

            var builder = new BodyBuilder();
            builder.TextBody = @"Reset your Passwordtextbody";

            //Set the html version of the message text
            builder.HtmlBody = string.Format(@"<p>To change your Passwordhtmlbody, </p>
            <a href=""http://localhost:20179/Login/ResetPassword"">Click here</a>");
            message.Body = builder.ToMessageBody();
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("180540107173@darshan.ac.in", "trivedi.a.b.");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();
            }
        }
    
    }
}
