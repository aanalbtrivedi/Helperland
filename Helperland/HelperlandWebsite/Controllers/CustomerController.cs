using HelperlandWebsite.CommonUse;
using HelperlandWebsite.Data;
using HelperlandWebsite.Models;
using HelperlandWebsite.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.Controllers
{
    public class CustomerController : Controller
    {
        public int userId;
        public string email;
        public string sendemail;
        public int saveUserId;
        public int? SPId;
        public string _Msg;
        private readonly HelperlandContext _helperlandContext;
        public CustomerController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CustomerDashboard()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;

            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                var listServices = ListServices();
                return View(listServices);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult CustomerDashboard(CustomerDashboardViewModel dataSchedule)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            if (dataSchedule.dltSerReq != 0)
            {
                ServiceRequest dltReq = _helperlandContext.ServiceRequests.Where(u => u.ServiceRequestId == dataSchedule.ServiceRequestId).FirstOrDefault();
                ServiceRequestAddress dltReqAdd = _helperlandContext.ServiceRequestAddresses.Where(u => u.ServiceRequestId == dataSchedule.ServiceRequestId).FirstOrDefault();
                dltReq.Status = 2;
                _helperlandContext.ServiceRequestAddresses.Update(dltReqAdd);
                _helperlandContext.SaveChanges();
               

                var tempId = dltReq.ServiceProviderId;
                User item = _helperlandContext.Users.Where(u => u.UserId == tempId).FirstOrDefault();
                sendemail = item.Email;
                sendemailCancel(sendemail, dataSchedule.ServiceRequestId);
                return View();
            }
            else
            {
                ServiceRequest updateSchedule = _helperlandContext.ServiceRequests.Where(u => u.ServiceRequestId == dataSchedule.ServiceRequestId).FirstOrDefault();
                updateSchedule.ServiceStartDate = dataSchedule.StartingDate;
                _helperlandContext.ServiceRequests.Update(updateSchedule);
                _helperlandContext.SaveChanges();
                ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(s => s.ServiceRequestId == dataSchedule.ServiceRequestId).FirstOrDefault();
                var tempId = serviceRequest.ServiceProviderId;
                User item = _helperlandContext.Users.Where(u => u.UserId == tempId).FirstOrDefault();
                sendemail = item.Email;
                sendMail(sendemail, dataSchedule.ServiceRequestId, dataSchedule.StartingDate);
                
                return View();
            }
        }

        public List<CustomerDashboardViewModel> ListServices()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;
            ViewBag.name = user.LastName;

            var serviceschk = new List<CustomerDashboardViewModel>();

            var item = _helperlandContext.ServiceRequests.Where(s => s.UserId.Equals(userId) && (s.Status == 1 || s.Status == 4)).ToList();
            foreach (var ser in item)
            {
                serviceschk.Add(new CustomerDashboardViewModel()
                {
                    ServiceRequestId = ser.ServiceRequestId,
                    StartingDate = ser.ServiceStartDate,
                    ServiceHours = ser.ServiceHours,
                    Payment = ser.TotalCost,
                    ServiceProviderId = ser.ServiceProviderId,
                });
                SPId = ser.ServiceProviderId;
                
                User userSP = _helperlandContext.Users.Where(u => u.UserId == ser.ServiceProviderId).FirstOrDefault();
                if(userSP != null)
                {
                    ViewBag.SPfname = userSP.FirstName;
                    ViewBag.SPlname = userSP.LastName;
                }
            }

            return serviceschk;
        }

        
        [HttpGet]
        public IActionResult CustomerHistory()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;


            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                var listServiceHistory = ListServiceRequest();
                return View(listServiceHistory);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }           
        }
        
        [HttpPost]
        public IActionResult CustomerHistory(CustomerHistoryViewModel ratingData)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(u => u.ServiceRequestId == ratingData.ServiceRequestId).FirstOrDefault();
            ViewBag.userId = user.UserId;
            userId = ViewBag.userId;

            Rating rating = new Rating();
            rating.ServiceRequestId = ratingData.ServiceRequestId;
            rating.RatingFrom = userId;
            rating.RatingTo = (int)serviceRequest.ServiceProviderId;
            rating.Comments = ratingData.Comments;
            rating.RatingDate = DateTime.Now.Date;
            rating.OnTimeArrival = ratingData.OnTimeArrival;
            rating.Friendly = ratingData.Friendly;
            rating.QualityOfService = ratingData.QualityOfService;
            rating.Ratings = ratingData.Ratings;
            _helperlandContext.Ratings.Add(rating);
            _helperlandContext.SaveChanges();

            return View();
        }

        public List<CustomerHistoryViewModel> ListServiceRequest()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;
            ViewBag.name = user.LastName;

            var serviceschk = new List<CustomerHistoryViewModel>();

            var item = _helperlandContext.ServiceRequests.Where(s => s.UserId.Equals(userId) && (s.Status == 2 || s.Status == 3)).ToList();
            foreach (var hist in item)
            {
                if (hist.ServiceProviderId != null)
                {
                    User userSP = _helperlandContext.Users.Where(u => u.UserId == hist.ServiceProviderId).FirstOrDefault();

                    serviceschk.Add(new CustomerHistoryViewModel()
                    {
                        ServiceRequestId = hist.ServiceRequestId,
                        StartingDate = hist.ServiceStartDate,
                        ServiceHours = hist.ServiceHours,
                        Payment = hist.TotalCost,
                        ServiceProviderId = hist.ServiceProviderId,
                        Status = hist.Status,
                        FirstName = userSP.FirstName,
                        LastName = userSP.LastName
                    });
                }
                else
                {
                    serviceschk.Add(new CustomerHistoryViewModel()
                    {
                        ServiceRequestId = hist.ServiceRequestId,
                        StartingDate = hist.ServiceStartDate,
                        ServiceHours = hist.ServiceHours,
                        Payment = hist.TotalCost,
                        ServiceProviderId = hist.ServiceProviderId,
                        Status = hist.Status,
                    });
                }
            }
            return serviceschk;
        }

        [HttpGet]
        public IActionResult MySettings()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;

            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                ViewBag.name = user.LastName;

                MysettingsViewModel msv = new MysettingsViewModel();
                User showUser = _helperlandContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
                msv.Firstname = showUser.FirstName;
                msv.Lastname = showUser.LastName;
                msv.Emailaddress = showUser.Email;
                msv.MobileNumber = showUser.Mobile;
                msv.Birthdate = showUser.DateOfBirth;
                msv.LanguageId = showUser.LanguageId; 
                return View(msv);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult MySettings(MysettingsViewModel Settings)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User userchk = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            ViewBag.userId = userchk.UserId;
            userId = ViewBag.userId;

            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
                //ViewBag.userId = user.UserId;
                user.FirstName = Settings.Firstname;
                user.LastName = Settings.Lastname;
                user.Mobile = Settings.MobileNumber;
                user.LanguageId = Settings.LanguageId;
                user.Email = email;
                user.DateOfBirth = Settings.Birthdate;
                _helperlandContext.Users.Update(user);
                _helperlandContext.SaveChanges();
                ModelState.Clear();
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public List<ListAddressViewModel> ListAddress()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;

            var addr = new List<ListAddressViewModel>();

            var item = _helperlandContext.UserAddresses.Where(s => s.UserId.Equals(userId)).ToList();
            foreach (var ad in item)
            {
                addr.Add(new ListAddressViewModel()
                {
                    AddressId = ad.AddressId,
                    AddressLine1 = ad.AddressLine1,
                    AddressLine2 = ad.AddressLine2,
                    City = ad.City,
                    Mobile = ad.Mobile,
                    PostalCodeUser = ad.PostalCode
                });
            }
            return addr;
        }

        public IActionResult GetAddressCust()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            var addresslistdata = ListAddress();
            return View(addresslistdata);
        }
        
        [HttpPost]
        public IActionResult GetAddressCust(ListAddressViewModel Data)
        {
            if(Data.chkforDelete != 0)
            {
                UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == Data.AddressId).FirstOrDefault();
                _helperlandContext.UserAddresses.Remove(userAddress);
                _helperlandContext.SaveChanges();
            }
            else if (Data.chkforUpdate != 0)
            {
                UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == Data.AddressId).FirstOrDefault();
                userAddress.AddressLine1 = Data.AddressLine1;
                userAddress.AddressLine2 = Data.AddressLine2;
                userAddress.PostalCode = Data.PostalCodeUser;
                userAddress.City = Data.City;
                userAddress.Mobile = Data.Mobile;
                _helperlandContext.UserAddresses.Update(userAddress);
                _helperlandContext.SaveChanges();
            }
            else if(Data.chkforAdd != 0)
            {
                ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
                email = ViewBag.email;
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                UserAddress userAddress = new UserAddress();
                userId = ViewBag.userId;
                userAddress.UserId = userId;
                userAddress.AddressLine1 = Data.AddressLine1;
                userAddress.AddressLine2 = Data.AddressLine2;
                userAddress.City = Data.City;
                userAddress.PostalCode = Data.PostalCodeUser;
                userAddress.Mobile = Data.Mobile;
                userAddress.Email = email;
                _helperlandContext.UserAddresses.Add(userAddress);
                _helperlandContext.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }
        
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChngPasswordViewModel ChangePassword)
        {
            ViewBag.Message = "ljsnxdlash";
            //ChngPasswordViewModel cpvm = new ChngPasswordViewModel();
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email && u.Password == ChangePassword.oldPassword).FirstOrDefault();
            if(user != null)
            {
                user.Password = ChangePassword.newPassword;
                _helperlandContext.Users.Update(user);
                _helperlandContext.SaveChanges();
                ModelState.Clear();
                _Msg = "Your Password is  changed.view";
            }
            else
            {
                _Msg = "Your old Password is wrong.";
               
            }
            //ViewBag.Message = _Msg;
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        public void sendMail(string email, int id, DateTime dateTime)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("180540107173", "180540107173@darshan.ac.in"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "Service Request is rescheduled";

            var builder = new BodyBuilder();
            builder.TextBody = @"Service Request is rescheduled";

            //Set the html version of the message text
            builder.HtmlBody = string.Format(@"<p>Service Request </p>" + id + "<p> is rescheduled by customer." +
                        " New date and time are </p>" + dateTime);
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

        public void sendemailCancel(string email, int id)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("180540107173", "180540107173@darshan.ac.in"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "Service Request is Cancelled";

            var builder = new BodyBuilder();
            builder.TextBody = @"Service Request is Cancelled";

            //Set the html version of the message text
            builder.HtmlBody = string.Format(@"<p>Service Request </p>" + id + "<p> has been cancelled by customer.");
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
