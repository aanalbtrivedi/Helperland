using HelperlandWebsite.Data;
using HelperlandWebsite.Models;
using HelperlandWebsite.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.Controllers
{
    public class CustomerController : Controller
    {
        public int userId;
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
            var listServices = ListServices();
            return View(listServices);
        }

        [HttpPost]
        public IActionResult CustomerDashboard(CustomerDashboardViewModel dataSchedule)
        {
            if (dataSchedule.StartingDate != null)
            {
                ServiceRequest ckId = _helperlandContext.ServiceRequests.Where(u => u.ServiceRequestId == dataSchedule.ServiceRequestId & u.UserId == dataSchedule.UserId).FirstOrDefault();
                ServiceRequest serviceRequest = new ServiceRequest();
                //serviceRequest.UserId = userID;
                serviceRequest.ServiceStartDate = dataSchedule.StartingDate;
                _helperlandContext.ServiceRequests.Add(serviceRequest);
                _helperlandContext.SaveChanges();
                return View();
            }
            return View();

        }

        public List<CustomerDashboardViewModel> ListServices()
        {
            var services = new List<CustomerDashboardViewModel>();
            var servicereq = _helperlandContext.ServiceRequests.ToList();
            if (servicereq?.Any() == true)
            {
                foreach (var ser in servicereq)
                {
                    services.Add(new CustomerDashboardViewModel()
                    {
                        ServiceRequestId = ser.ServiceRequestId,
                        StartingDate = ser.ServiceStartDate,
                        ServiceHours = ser.ServiceHours,
                        Payment = ser.TotalCost,
                        ServiceProviderId = ser.ServiceProviderId
                    });

                }
            }
            return services;

        }

        [HttpGet]
        public IActionResult CustomerHistory()
        {
            var listServiceHistory = ListServiceRequest();
            return View(listServiceHistory);
        }
        public List<CustomerHistoryViewModel> ListServiceRequest()
        {
            var servicehist = new List<CustomerHistoryViewModel>();
            var servicehistory = _helperlandContext.ServiceRequests.ToList();
            if (servicehistory?.Any() == true)
            {
                foreach (var hist in servicehistory)
                {
                    servicehist.Add(new CustomerHistoryViewModel()
                    {
                        ServiceRequestId = hist.ServiceRequestId,
                        StartingDate = hist.ServiceStartDate,
                        ServiceHours = hist.ServiceHours,
                        Payment = hist.TotalCost,
                        ServiceProviderId = hist.ServiceProviderId,
                        Status = hist.Status
                    });
                }
            }
            return servicehist;
        }

        [HttpGet]
        public IActionResult MySettings()
        {
            MysettingsViewModel msv = new MysettingsViewModel();
            msv.UserId = 6;
            userId = msv.UserId;
            User user = _helperlandContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            msv.Firstname = user.FirstName;
            msv.Lastname = user.LastName;
            msv.Emailaddress = user.Email;
            msv.MobileNumber = user.Mobile;
            user.DateOfBirth = msv.Birthdate;
            user.LanguageId = msv.LanguageId;
            return View(msv);
        }

        [HttpPost]
        public IActionResult MySettings(MysettingsViewModel Settings)
        {
            User user = new User();
            user.FirstName = Settings.Firstname;
            user.LastName = Settings.Lastname;
            user.Mobile = Settings.MobileNumber;
            user.LanguageId = Settings.LanguageId;
            //user.Email = Settings.Emailaddress;
            _helperlandContext.Users.Update(user);
            _helperlandContext.SaveChanges();
            return View();
        }

        public List<ListAddressViewModel> ListAddress()
        {
            var addr = new List<ListAddressViewModel>();
            var addresses = _helperlandContext.UserAddresses.ToList();
            if (addresses?.Any() == true)
            {
                foreach (var ad in addresses)
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
            }
            return addr;
        }

        public IActionResult GetAddressCust()
        {
            var addresslistdata = ListAddress();
            return View(addresslistdata);
        }
        
        [HttpPost]
        public IActionResult GetAddressCust(ListAddressViewModel chngAddress)
        {
            if (chngAddress.AddressId != 0)
            {
                UserAddress checkAddres = _helperlandContext.UserAddresses.Where(u => u.AddressId == chngAddress.AddressId).FirstOrDefault();
                ServiceRequestAddress serviceRequestAddress = new ServiceRequestAddress();

                serviceRequestAddress.AddressLine1 = checkAddres.AddressLine1;
                //serviceRequestAddress.AddressLine2 = checkAddres.AddressLine2;
                serviceRequestAddress.City = checkAddres.City;
                serviceRequestAddress.PostalCode = checkAddres.PostalCode;
                serviceRequestAddress.Mobile = checkAddres.Mobile;
                //serviceRequestAddress.ServiceRequestId = serreqId;
                //serviceRequestAddress.Email = checkAddres.Email;
                _helperlandContext.ServiceRequestAddresses.Add(serviceRequestAddress);
                _helperlandContext.SaveChanges();
                ModelState.Clear();
                return View();
            }

            else if (chngAddress.AddressLine1 != null)
            {
                UserAddress userAddress = new UserAddress();

                userAddress.UserId = userId;
                userAddress.AddressLine1 = chngAddress.AddressLine1;
                //userAddress.AddressLine2 = listAddressViewModel.AddressLine2;
                userAddress.City = chngAddress.City;
                userAddress.PostalCode = chngAddress.PostalCodeUser;
                userAddress.Mobile = chngAddress.Mobile;
                _helperlandContext.UserAddresses.Add(userAddress);
                _helperlandContext.SaveChanges();
                ModelState.Clear();
                return View();

            }
            return View();
        }
        
        public IActionResult ChangePassword()
        {
            return View();
        }
    
    }
}
