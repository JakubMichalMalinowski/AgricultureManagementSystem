using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Controllers
{
    public class CombineController : Controller
    {
        private readonly ApplicationDbContext db;

        public CombineController(ApplicationDbContext db)
            => this.db = db;

        public IActionResult Index()
            => View(db.Combines);

        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var item = db.Combines.Find(id);
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
        public IActionResult Create(Combine combine)
        {
            if (ModelState.IsValid)
            {
                db.Combines.Add(combine);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(combine);
        }

        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                var item = db.Combines.Find(id);
                if (item != null)
                {
                    return View(item);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Combine combine)
        {
            if (ModelState.IsValid)
            {
                db.Combines.Update(combine);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(combine);
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var item = db.Combines.Find(id);
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
                var item = db.Combines.Find(id);
                if (item != null)
                {
                    db.Combines.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }
    }
}
