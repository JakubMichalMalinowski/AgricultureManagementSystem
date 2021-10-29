using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Controllers
{
    public class TractorController : Controller
    {
        IList<Tractor> tractors = new List<Tractor>();

        // GET: TractorController
        public ActionResult Index()
        {
            tractors.Add(new Tractor("Fendt 712", 2000, 9000, 50, FuelType.Diesel, 300, 125));
            tractors.Add(new Tractor("Fendt 311", 1987, 15000, 40, FuelType.Diesel, 100, 115));
            tractors.Add(new Tractor("Fendt 308", 1980, 10000, 40, FuelType.Diesel, 100, 80));
            return View(tractors);
        }

        // GET: TractorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TractorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TractorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TractorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TractorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TractorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TractorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
