using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Controllers
{
    public class CheckUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
