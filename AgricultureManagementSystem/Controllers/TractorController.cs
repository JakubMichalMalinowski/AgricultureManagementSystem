﻿using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class TractorController : Controller
    {
        private readonly ApplicationDbContext db;

        public TractorController(ApplicationDbContext db)
            => this.db = db;

        public IActionResult Index()
            => View(db.Tractors);

        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var item = db.Tractors
                    .Where(t => t.Id == id)
                    .Include(t => t.Services)
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
        public IActionResult Create(Tractor tractor)
        {
            if (ModelState.IsValid)
            {
                db.Tractors.Add(tractor);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(tractor);
        }

        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                var item = db.Tractors.Find(id);
                if (item != null)
                {
                    return View(item);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tractor tractor)
        {
            if (ModelState.IsValid)
            {
                db.Tractors.Update(tractor);
                db.SaveChanges();
                return RedirectToAction(nameof(Details),
                    new { id = tractor.Id });
            }

            return View(tractor);
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var item = db.Tractors.Find(id);
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
                var item = db.Tractors
                    .Where(t => t.Id == id)
                    .Include(t => t.Services)
                    .FirstOrDefault();

                if (item != null)
                {
                    db.Tractors.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }
    }
}
