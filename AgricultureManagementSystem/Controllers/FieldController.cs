using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class FieldController : Controller
    {
        private ApplicationDbContext db;

        public FieldController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
            => View(db.Fields);

        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var item = db.Fields
                    .Where(f => f.Id == id)
                    .Include(f => f.Activities)
                    .FirstOrDefault();

                if (item != null)
                {
                    return View(item);
                }
            }

            return NotFound();
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Field field)
        {
            if (ModelState.IsValid)
            {
                db.Fields.Add(field);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(field);
        }
    }
}
