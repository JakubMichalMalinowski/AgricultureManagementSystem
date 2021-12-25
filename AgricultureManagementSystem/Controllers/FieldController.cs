using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class FieldController : Controller
    {
        private readonly ApplicationDbContext db;

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

        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                var item = db.Fields.Find(id);
                if (item != null)
                    return View(item);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Field field)
        {
            if (ModelState.IsValid)
            {
                db.Fields.Update(field);
                db.SaveChanges();
                return RedirectToAction(nameof(Details),
                    new { id = field.Id });
            }

            return View(field);
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var item = db.Fields.Find(id);
                if (item != null)
                    return View(item);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            if (id != 0)
            {
                var item = db.Fields
                    .Where(f => f.Id == id)
                    .Include(f => f.Activities)
                    .FirstOrDefault();

                if (item != null)
                {
                    db.Fields.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }
    }
}
