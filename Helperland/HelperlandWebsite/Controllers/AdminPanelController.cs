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
    public class AdminPanelController : Controller
    {
        public int id;
        private readonly HelperlandContext _helperlandContext;
        public AdminPanelController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult ServiceRequest()
        {
            var ListServiceRequest = ListServicesReq();
            ServiceRequestsAdminViewModel serviceRequestsAdminViewModel = new ServiceRequestsAdminViewModel();
            serviceRequestsAdminViewModel.ServiceId = 1;
             id = serviceRequestsAdminViewModel.ServiceId;
            ServiceRequestAddress serviceRequestAddress =
                _helperlandContext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == id).FirstOrDefault();
            serviceRequestsAdminViewModel.City = serviceRequestAddress.City;
            serviceRequestsAdminViewModel.PostalCode = serviceRequestAddress.PostalCode;
            serviceRequestsAdminViewModel.AddressLine1 = serviceRequestAddress.AddressLine1;
            ViewBag.City = serviceRequestsAdminViewModel.City;
            ViewBag.PostalCode = serviceRequestsAdminViewModel.PostalCode;
            ViewBag.AddressLine1 = serviceRequestsAdminViewModel.AddressLine1;
            return View(ListServiceRequest);
        }

        public IActionResult UserManagement(UserManagementViewModel data)
        {
            if (data.Mobile == null)
            {

                var ListUsers = ListUser();
                return View(ListUsers);
            }
            else
            {
                var showlist = new List<UserManagementViewModel>();
                var item = _helperlandContext.Users.Where(s => s.Mobile == data.Mobile).ToList();
                //var listis = item.ToList();

                return View(item);
            }
        }

        //[HttpPost]
        //public IActionResult UserManagement(UserManagementViewModel data)
        //{
        //    var showlist =  new List<UserManagementViewModel>();
        //    var item = _helperlandContext.Users.Where(s => s.Mobile == data.Mobile).ToList();
        //    //var listis = item.ToList();
        //    foreach (var ser in item)
        //    {
        //        showlist.Add(new UserManagementViewModel()
        //        {
        //            Firstname = data.Firstname,
        //            Mobile = data .Mobile,
        //            UserTypeId = data.UserTypeId,
        //        });
        //    }
        //        return View(showlist);   
        //}

        public List<UserManagementViewModel> ListUser()
        {
            var users = new List<UserManagementViewModel>();
            var userlist = _helperlandContext.Users.ToList();
            //var servicereqAdd = _helperlandContext.ServiceRequestAddresses.ToList();
            if (userlist?.Any() == true)
            {
                foreach (var ul in userlist)
                {
                    users.Add(new UserManagementViewModel()
                    {
                        //UserId = ul.UserId,
                        Firstname = ul.LastName,
                        CreatedDate = ul.CreatedDate,
                        UserTypeId = ul.UserTypeId,
                        Mobile = ul.Mobile
                    });
                }
            }
            return users;
        }
        public List<ServiceRequestsAdminViewModel> ListServicesReq()
        {
            var services = new List<ServiceRequestsAdminViewModel>();
            var servicereq = _helperlandContext.ServiceRequests.ToList();
            var servicereqAdd = _helperlandContext.ServiceRequestAddresses.ToList();
            if (servicereq?.Any() == true)
            {
                foreach (var ser in servicereq)
                {
                    services.Add(new ServiceRequestsAdminViewModel()
                    {
                        ServiceId = ser.ServiceRequestId,
                        StartingDate = ser.ServiceStartDate,
                        Hours = ser.ServiceHours,
                        NetAmount = ser.TotalCost,
                        GrossAmount = ser.TotalCost,
                        Discount = ser.Discount
                    });
                }
            }
            return services;
        }
    
        
    }
}
