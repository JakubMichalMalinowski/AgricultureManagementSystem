using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Controllers
{
    public class TractorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
