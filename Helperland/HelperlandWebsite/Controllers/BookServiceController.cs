using Helperland.Utilities;
using HelperlandWebsite.CommonUse;
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
    public class BookServiceController : Controller
    {
        public int serreqId;
        public string exist;
        public string msg;
        private readonly HelperlandContext _helperlandContext;
        public int valid=0;
        public int userID = 6;
        public string Todaysdate;
        public decimal discount = 20;
        public string adduseradd;
        public string Postcode;
        public string email;


        public BookServiceController(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        
        public IActionResult Book_now()
        {
            //ViewBag.email = HttpContext.Session.GetString(StaticValue.EmailSV);
            //email = ViewBag.email;
            //User user = _helperlandContext.Users.Where(u => u.Email == email).FirstOrDefault();
            //ViewBag.userId = user.UserId;
            //userID = user.UserId;
            Book_nowViewModel book_NowViewModel = new Book_nowViewModel();
            return View(book_NowViewModel);
        }

        [HttpPost]
        public IActionResult Book_now(Book_nowViewModel bookings)
        {
            
            if(bookings.Cleandate != null && bookings.AddressID == 0 && bookings.AddressLine1 == null)
            {

                ServiceRequest serviceRequest = new ServiceRequest();
                serviceRequest.UserId = userID;
                serviceRequest.ServiceStartDate = bookings.Cleandate;
                serviceRequest.HasPets = bookings.Pets;
                serviceRequest.Comments = bookings.Comments;
                serviceRequest.CreatedDate = DateTime.Now.Date;
                serviceRequest.TotalCost = bookings.TotalPayment;
                serviceRequest.ServiceHours = bookings.Hours;
                serviceRequest.ZipCode = bookings.PostalCode;
                serviceRequest.Discount = discount;
                _helperlandContext.ServiceRequests.Add(serviceRequest);
                _helperlandContext.SaveChanges();
                int servid = serviceRequest.ServiceRequestId;
                serreqId = servid;

                return View();
         
            }
            else if (bookings.AddressID != 0)
            {
                UserAddress checkAddres = _helperlandContext.UserAddresses.Where(u => u.AddressId == bookings.AddressID).FirstOrDefault();
                ServiceRequestAddress serviceRequestAddress = new ServiceRequestAddress();

                serviceRequestAddress.AddressLine1 = checkAddres.AddressLine1;
                serviceRequestAddress.City = checkAddres.City;
                serviceRequestAddress.PostalCode = checkAddres.PostalCode;
                serviceRequestAddress.Mobile = checkAddres.Mobile;
                _helperlandContext.ServiceRequestAddresses.Add(serviceRequestAddress);
                _helperlandContext.SaveChanges();
                ModelState.Clear();
                return View();
            }




            else if (bookings.AddressLine1 != null)
            {
                UserAddress userAddress = new UserAddress();
                
                userAddress.UserId = userID;
                userAddress.AddressLine1 = bookings.AddressLine1;
                //userAddress.AddressLine2 = listAddressViewModel.AddressLine2;
                userAddress.City = bookings.City;
                userAddress.PostalCode = bookings.PostalCodeUser;
                userAddress.Mobile = bookings.Mobile;
                _helperlandContext.UserAddresses.Add(userAddress);
                _helperlandContext.SaveChanges();
                ModelState.Clear();
                return View();
                
            }
            else

            {
                return Content("Good");
            }

        }
        public List<ListAddressViewModel> ListAddress()
        {
            var addr = new List<ListAddressViewModel>();
            var addresses = _helperlandContext.UserAddresses.ToList();
            if (addresses?.Any() == true)
            {
                foreach(var ad in addresses)
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

        public IActionResult GetAddress()
        {
            var addresslistdata = ListAddress();
            //List<ListAddressViewModel> addresses = ListAddress();
            return View(addresslistdata);
        }

       









        public IActionResult Book_service()
        {
            return View();
        }
    }
}
