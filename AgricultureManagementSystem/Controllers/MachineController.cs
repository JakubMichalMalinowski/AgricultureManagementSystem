using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class MachineController : Controller
    {
        private readonly ApplicationDbContext db;

        public MachineController(ApplicationDbContext db)
            => this.db = db;

        public IActionResult Index()
            => View(db.Machines);

        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var item = db.Machines
                    .Where(m => m.Id == id)
                    .Include(m => m.Services)
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
        public IActionResult Create(Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Add(machine);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(machine);
        }

        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                var item = db.Machines.Find(id);
                if (item != null)
                {
                    return View(item);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Update(machine);
                db.SaveChanges();
                return RedirectToAction(nameof(Details),
                    new { id = machine.Id });
            }

            return View(machine);
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var item = db.Machines.Find(id);
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
                var item = db.Machines
                    .Where(m => m.Id == id)
                    .Include(m => m.Services)
                    .FirstOrDefault();

                if (item != null)
                {
                    db.Machines.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }
    }
}
