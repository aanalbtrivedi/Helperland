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
        public IActionResult Index()
        {
            ViewBag.email = HttpContext.Session.GetString("email");

            return View();
        }
    }
}
