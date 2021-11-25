using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureManagementSystem.Controllers
{
    public class ExController : Controller
    {
        // GET: ExController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExController/Create
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

        // GET: ExController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExController/Edit/5
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

        // GET: ExController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExController/Delete/5
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
