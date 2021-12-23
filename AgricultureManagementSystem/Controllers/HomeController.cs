using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
            => View(db.Notes.Where(n => n.Index == 0).FirstOrDefault());
    }
}
