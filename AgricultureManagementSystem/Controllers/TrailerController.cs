using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Controllers
{
    public class TrailerController : Controller
    {
        private readonly ApplicationDbContext db;

        public TrailerController(ApplicationDbContext db)
            => this.db = db;
        public IActionResult Index()
            => View(db.Trailers);

        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var item = db.Trailers.Find(id);
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
        public IActionResult Create(Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.Trailers.Add(trailer);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(trailer);
        }

        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                var item = db.Trailers.Find(id);
                if (item != null)
                {
                    return View(item);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.Trailers.Update(trailer);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(trailer);
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var item = db.Trailers.Find(id);
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
                var item = db.Trailers.Find(id);
                if (item != null)
                {
                    db.Trailers.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }
    }
}
