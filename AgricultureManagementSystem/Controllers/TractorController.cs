using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Controllers
{
    public class TractorController : Controller
    {
        private readonly ApplicationDbContext db;

        public TractorController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Tractor> tractors = db.Tractors;
            return View(tractors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tractor tractor)
        {
            db.Tractors.Add(tractor);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
