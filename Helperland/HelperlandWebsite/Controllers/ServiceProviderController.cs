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
    public class ServiceProviderController : Controller
    {
        public int userId;
        public int? SerReqId;
        public int? demo;
        public string email;
        public bool IsBlocked;
        private readonly HelperlandContext _helperlandContext;
        public ServiceProviderController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult UpcomingServices()
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
        public IActionResult UpcomingServices(UpcomingServiceViewModel check)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(u => u.ServiceRequestId == check.ServiceRequestId).FirstOrDefault();
            if (check.chkCancel == 1)
            {
                serviceRequest.Status = 1;
                _helperlandContext.ServiceRequests.Update(serviceRequest);
                _helperlandContext.SaveChanges();
            }
            else if(check.chkCompleted == 1)
            {
                serviceRequest.Status = 3;
                _helperlandContext.ServiceRequests.Update(serviceRequest);
                _helperlandContext.SaveChanges();
            }
            return View();
        }
        public IActionResult NewServiceRequests()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;


            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                var listRequests = ListServicesReq();
                return View(listRequests);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
       
        [HttpPost]
        public IActionResult NewServiceRequests(NewServiceRequestsViewModels dataAccept)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;
            ServiceRequest SerReqId = _helperlandContext.ServiceRequests.Where(u => u.ServiceRequestId == dataAccept.ServiceRequestId).FirstOrDefault();
            SerReqId.Status = 4;
            SerReqId.ServiceProviderId = userId;
            _helperlandContext.ServiceRequests.Update(SerReqId);
            _helperlandContext.SaveChanges();

            var item = _helperlandContext.Users.Where(s => s.UserTypeId == 2 && s.UserId != userId).ToList();
            foreach (var ser in item)
            {
                sendMail(ser.Email,SerReqId.ServiceRequestId);
            }
            return View();
        }
        public IActionResult ServiceHistory()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;

            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                var ServHist = ListServiceHist();
                return View(ServHist);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
        public IActionResult MySettings()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;

            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                SPMySettingsViewModel spmsv = new SPMySettingsViewModel();
                spmsv.UserId = userId;
                spmsv.Firstname = user.FirstName;
                spmsv.Lastname = user.LastName;
                spmsv.Emailaddress = user.Email;
                spmsv.MobileNumber = user.Mobile;
                user.DateOfBirth = spmsv.Birthdate;
                //user.LanguageId = spmsv.LanguageId;
                UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.UserId == userId).FirstOrDefault();
                spmsv.City = userAddress.City;
                spmsv.PostalCode = userAddress.PostalCode;
                spmsv.Streetname = userAddress.AddressLine1;
                spmsv.AddressLine2 = userAddress.AddressLine2;
                spmsv.MobileNumber = userAddress.Mobile;
                return View(spmsv);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        [HttpPost]
        public IActionResult MySettings(SPMySettingsViewModel saveChngs)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;

            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;

                if (ModelState.IsValid)
                {
                    User updateUser = _helperlandContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
                    //User user = new User();
                    updateUser.FirstName = saveChngs.Firstname;
                    updateUser.LastName = saveChngs.Lastname;
                    updateUser.Email = saveChngs.Emailaddress;
                    updateUser.Mobile = saveChngs.MobileNumber;
                    updateUser.NationalityId = saveChngs.NationalityId;
                    updateUser.Gender = saveChngs.Gender;
                    updateUser.UserProfilePicture = saveChngs.UserProfilePicture;
                    _helperlandContext.Users.Update(updateUser);
                    _helperlandContext.SaveChanges();

                    UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.UserId == userId).FirstOrDefault();
                    userAddress.AddressLine1 = saveChngs.Streetname;
                    userAddress.AddressLine2 = saveChngs.AddressLine2;
                    userAddress.PostalCode = saveChngs.PostalCode;
                    userAddress.City = saveChngs.City;
                    userAddress.Email = email;
                    _helperlandContext.UserAddresses.Update(userAddress);
                    _helperlandContext.SaveChanges();
                }
                return View();
            }

            else
            {
                return RedirectToAction("Login","Login");
            }
        }

        public IActionResult SPChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SPChangePassword(SPChngPasswordViewModel saveChngs)
        {
            
            bool Success = false;
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;
            User userPwd = _helperlandContext.Users.Where(x => x.UserId == userId && x.Password == saveChngs.oldPassword).FirstOrDefault();
            if(userPwd != null)
            {
                user.Password = saveChngs.Password;
                _helperlandContext.Users.Update(userPwd);
                _helperlandContext.SaveChanges();
                Success = true;
            }
            else
            {
                Success = false;
            }
            return Json(new { Success = Success });
            //return View();
        }

        public List<UpcomingServiceViewModel> ListServices()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;

            var services = new List<UpcomingServiceViewModel>();
            var servicereq = _helperlandContext.ServiceRequests.ToList();

            var item = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId.Equals(userId) && (s.Status == 4)).ToList();

                foreach (var ser in item)
                {
                    ServiceRequestAddress serviceRequestAddress = _helperlandContext.ServiceRequestAddresses.Where(u => u.ServiceRequestId == ser.ServiceRequestId).FirstOrDefault();

                    services.Add(new UpcomingServiceViewModel()
                    {
                        ServiceRequestId = ser.ServiceRequestId,
                        StartingDate = ser.ServiceStartDate,
                        ServiceHours = ser.ServiceHours,
                        Payment = ser.TotalCost,
                        City = serviceRequestAddress.City,
                        PostalCode = serviceRequestAddress.PostalCode,
                        AddressLine1 = serviceRequestAddress.AddressLine1,
                        AddressLine2 = serviceRequestAddress.AddressLine2,
                    });
                }
            
            return services;
        }
        public List<NewServiceRequestsViewModels> ListServicesReq()
        {
            var services = new List<NewServiceRequestsViewModels>();
            var item = _helperlandContext.ServiceRequests.Where(s => s.Status.Equals(1)).ToList();

                foreach (var ser in item)
                {
                ServiceRequestAddress serviceRequestAddress = _helperlandContext.ServiceRequestAddresses.Where(u => u.ServiceRequestId == ser.ServiceRequestId).FirstOrDefault();
                services.Add(new NewServiceRequestsViewModels()
                {
                    ServiceRequestId = ser.ServiceRequestId,
                    StartingDate = ser.ServiceStartDate,
                    ServiceHours = ser.ServiceHours,
                    Payment = ser.TotalCost,
                    City = serviceRequestAddress.City,
                    PostalCode = serviceRequestAddress.PostalCode,
                    AddressLine1 = serviceRequestAddress.AddressLine1,
                    AddressLine2 = serviceRequestAddress.AddressLine2,
                    
                });
            }

            return services;
        }                
        public List<SPServiceHistoryViewModel> ListServiceHist()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;

            var services = new List<SPServiceHistoryViewModel>();

            var item = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId.Equals(userId) && (s.Status == 3)).ToList();

                foreach (var ser in item)
                {
                ServiceRequestAddress serviceRequestAddress = _helperlandContext.ServiceRequestAddresses.Where(u => u.ServiceRequestId == ser.ServiceRequestId).FirstOrDefault();
                services.Add(new SPServiceHistoryViewModel()
                {
                    ServiceRequestId = ser.ServiceRequestId,
                    StartingDate = ser.ServiceStartDate,
                    ServiceHours = ser.ServiceHours,
                    City = serviceRequestAddress.City,
                    PostalCode = serviceRequestAddress.PostalCode,
                    AddressLine1 = serviceRequestAddress.AddressLine1,
                    AddressLine2 = serviceRequestAddress.AddressLine2,
                });
                } 
            return services;
        }

        public IActionResult BlockUser()
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;

            if (email != null)
            {
                User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
                ViewBag.userId = user.UserId;
                userId = ViewBag.userId;
                var listusers = ListServiceCustomer();
                return View(listusers);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult BlockUser(BlockUserViewModel datablock)
        {
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            ViewBag.userId = user.UserId;
            userId = ViewBag.userId;
            FavoriteAndBlocked checkfab = _helperlandContext.FavoriteAndBlockeds.Where(u => u.UserId == userId).FirstOrDefault();

            if(checkfab == null)
            {
                FavoriteAndBlocked favoriteAndBlocked = new FavoriteAndBlocked();
                favoriteAndBlocked.IsBlocked = datablock.IsBlocked;
                favoriteAndBlocked.TargetUserId = datablock.TargetUserId;
                favoriteAndBlocked.UserId = userId;
                _helperlandContext.Add(favoriteAndBlocked);
                _helperlandContext.SaveChanges();
            }
            else
            {
                checkfab.IsBlocked = datablock.IsBlocked;
                _helperlandContext.Update(checkfab);
                _helperlandContext.SaveChanges();
            }
            return View();
        }
        public List<BlockUserViewModel> ListServiceCustomer()
        {
            var checkname = "";
            ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            email = ViewBag.email;
            User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            userId = user.UserId;
            var services = new List<BlockUserViewModel>();
            var item = _helperlandContext.ServiceRequests.Where(s => s.ServiceProviderId.Equals(userId)).ToList();
            foreach (var ser in item)
            {
                User username = _helperlandContext.Users.Where(u => u.UserId == ser.UserId).FirstOrDefault();
                //FavoriteAndBlocked userblock = _helperlandContext.FavoriteAndBlockeds.Where(u => u.UserId == ser.UserId).FirstOrDefault();
                if (username.FirstName != checkname)
                {
                    services.Add(new BlockUserViewModel()
                    {
                        UserId = username.UserId,
                        FirstName = username.FirstName,
                        LastName = username.LastName
                    });
                    //if (userblock != null)
                    //{
                    //    ViewBag.IsBlocked = userblock.IsBlocked;
                    //}
                }
                checkname = username.FirstName;
            }
            return services;
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public void sendMail(string email,int id)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("180540107173", "180540107173@darshan.ac.in"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "Service Request is no more available";

            var builder = new BodyBuilder();
            builder.TextBody = @"Service Request is no more available";

            //Set the html version of the message text
            builder.HtmlBody = string.Format(id + @"<p>Service Request is no more available</p>");
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
