using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperlandWebsite.Controllers
{
    public class BookServiceController : Controller
    {
        public IActionResult Book_now()
        {
            return View();
        }
    }
}
