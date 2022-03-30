using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HelperlandWebsite.Controllers
{
    public class indexController : Controller
    {
        public partial class RatingController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    }
}
