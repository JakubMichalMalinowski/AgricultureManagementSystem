using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
            => View(db.Notes.Where(n => n.Index == 0).FirstOrDefault());

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
