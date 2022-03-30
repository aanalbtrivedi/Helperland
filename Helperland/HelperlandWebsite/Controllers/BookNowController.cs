using HelperlandWebsite.CommonUse;
using HelperlandWebsite.Data;
using HelperlandWebsite.Models;
using HelperlandWebsite.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.Controllers
{
    public class BookNowController : Controller
    {
        public int userId;
        public string email;
        public int? serreqId;
        private readonly HelperlandContext _helperlandContext;

        public BookNowController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult BookNow()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public IActionResult BookNow(Book_nowViewModel bookService)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            ViewBag.userId = user.UserId;
            userId = ViewBag.userId;
            
            ServiceRequest serviceRequest = new ServiceRequest();
            serviceRequest.UserId = userId;
            serviceRequest.ServiceId = bookService.ServiceId;
            serviceRequest.ServiceStartDate = bookService.Cleandate;
            serviceRequest.ZipCode = bookService.PostalCode;
            serviceRequest.ServiceHourlyRate = bookService.ServiceHourlyRate;
            serviceRequest.ServiceHours = bookService.Hours;
            serviceRequest.ExtraHours = bookService.ExtraHours;
            serviceRequest.SubTotal = bookService.SubTotal;
            serviceRequest.Discount = bookService.Discount;
            serviceRequest.TotalCost = bookService.TotalPayment;
            serviceRequest.Status = bookService.Status;
            serviceRequest.Comments = bookService.Comments;
            serviceRequest.HasPets = bookService.Pets;
            _helperlandContext.ServiceRequests.Add(serviceRequest);
            _helperlandContext.SaveChanges();
            serreqId = serviceRequest.ServiceRequestId;

            UserAddress checkAddres = _helperlandContext.UserAddresses.Where(u => u.AddressId == bookService.AddressID).FirstOrDefault();
            ServiceRequestAddress serviceRequestAddress = new ServiceRequestAddress();
            serviceRequestAddress.AddressLine1 = checkAddres.AddressLine1;
            serviceRequestAddress.AddressLine2 = checkAddres.AddressLine2;
            serviceRequestAddress.City = checkAddres.City;
            serviceRequestAddress.PostalCode = checkAddres.PostalCode;
            serviceRequestAddress.Mobile = checkAddres.Mobile;
            serviceRequestAddress.State = checkAddres.State;
            serviceRequestAddress.ServiceRequestId = serreqId;
            serviceRequestAddress.Email = email;

            _helperlandContext.ServiceRequestAddresses.Add(serviceRequestAddress);
            _helperlandContext.SaveChanges();

            var item = _helperlandContext.Users.Where(s => s.UserTypeId == 2).ToList();
            foreach (var ser in item)
            {
                sendMail(ser.Email);
            }
            return RedirectToAction("BookNow");
            
        }


        public IActionResult GetAddress()
        {
            //userId = ViewBag.userId;
            //ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            //email = ViewBag.email;
            //User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            //userId = user.UserId;

            var addresslistdata = ListAddress();
            return View(addresslistdata);
        }

        [HttpPost]
        public IActionResult GetAddress(Book_nowViewModel getadd)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            ViewBag.userId = user.UserId;
            UserAddress userAddress = new UserAddress();
            userId = ViewBag.userId;
            userAddress.UserId = userId;
            userAddress.AddressLine1 = getadd.AddressLine1;
            userAddress.AddressLine2 = getadd.AddressLine2;
            userAddress.City = getadd.City;
            userAddress.PostalCode = getadd.PostalCodeUser;
            userAddress.Mobile = getadd.Mobile;
            userAddress.Email = email;
            user.ZipCode = getadd.PostalCodeUser;
            _helperlandContext.UserAddresses.Add(userAddress);
            _helperlandContext.SaveChanges();
            ModelState.Clear();
            return View();
        }
        public List<ListAddressViewModel> ListAddress()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            ViewBag.userId = user.UserId;
            userId = ViewBag.userId;

            var serviceschk = new List<ListAddressViewModel>();

            var item = _helperlandContext.UserAddresses.Where(s => s.UserId.Equals(userId)).ToList();
            foreach (var ser in item)
            {
                serviceschk.Add(new ListAddressViewModel()
                {
                    AddressId = ser.AddressId,
                    AddressLine1 = ser.AddressLine1,
                    AddressLine2 = ser.AddressLine2,
                    City = ser.City,
                    PostalCodeUser = ser.PostalCode,
                    Mobile = ser.Mobile
                });
            }
            return serviceschk;
        }

        public void sendMail(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("180540107173", "180540107173@darshan.ac.in"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "New Service Request";

            var builder = new BodyBuilder();
            builder.TextBody = @"New Service Request is booked";

            //Set the html version of the message text
            builder.HtmlBody = string.Format(@"<p>New Service Request is Booked by</p>" + email);
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
