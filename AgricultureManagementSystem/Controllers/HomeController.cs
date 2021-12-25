using AgricultureManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IHostApplicationLifetime lifetime;

        public HomeController(ApplicationDbContext db, IHostApplicationLifetime lifetime)
        {
            this.db = db;
            this.lifetime = lifetime;
        }

        public IActionResult Index()
            => View(db.Notes.Where(n => n.Index == 0).FirstOrDefault());

        public IActionResult Error()
            => View();

        public IActionResult Shutdown()
        {
            lifetime.StopApplication();
            return View();
        }
    }
}
