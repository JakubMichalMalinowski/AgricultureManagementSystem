using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                Combine combine = db.Combines
                    .Where(c => c.Id == id)
                    .Include(c => c.Headers)
                    .Include(c => c.Services)
                    .FirstOrDefault();

                if (combine != null)
                {
                    return View(combine);
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
                return RedirectToAction(nameof(Details),
                    new { id = combine.Id });
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
                var item = db.Combines
                    .Where(c => c.Id == id)
                    .Include(c => c.Headers)
                    .Include(c => c.Services)
                    .FirstOrDefault();

                if (item != null)
                {
                    db.Combines.Remove(item);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }

        public IActionResult CreateHeader()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHeader(int combineId, Header header)
        {
            if (ModelState.IsValid)
            {
                if (combineId != 0)
                {
                    Combine combine = db.Combines
                        .Where(c => c.Id == combineId)
                        .Include(c => c.Headers)
                        .FirstOrDefault();

                    if (combine != null)
                    {
                        combine.Headers.Add(header);
                        db.SaveChanges();
                        return RedirectToAction(nameof(Details),
                            new { id = combineId });
                    }
                }

                return NotFound();

            }

            return View(header);
        }

        public IActionResult EditHeader(int id, int combineId)
        {
            if (id != 0 && combineId != 0)
            {
                Combine combine = db.Combines
                    .Where(c => c.Id == combineId)
                    .Include(c => c.Headers)
                    .FirstOrDefault();

                if (combine != null)
                {
                    try
                    {
                        Header header = combine.Headers
                            .Single(h => h.Id == id);
                        return View(header);
                    }
                    catch { }
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditHeader(Header header, int combineId)
        {
            if (ModelState.IsValid)
            {
                if (combineId != 0)
                {
                    Combine combine = db.Combines
                        .Where(c => c.Id == combineId)
                        .Include(c => c.Headers)
                        .FirstOrDefault();

                    if (combine != null)
                    {
                        int headerListIndex = combine.Headers.ToList()
                            .FindIndex(h => h.Id == header.Id);

                        combine.Headers[headerListIndex].Update(header);

                        db.SaveChanges();

                        return RedirectToAction(nameof(Details),
                            new { id = combineId });
                    }
                }

                return NotFound();

            }

            return View(header);
        }

        public IActionResult DeleteHeader(int id, int combineId)
        {
            if (id != 0 && combineId != 0)
            {
                Combine combine = db.Combines
                    .Where(c => c.Id == combineId)
                    .Include(c => c.Headers)
                    .FirstOrDefault();

                if (combine != null)
                {
                    try
                    {
                        Header header = combine.Headers
                            .Single(h => h.Id == id);
                        return View(header);
                    }
                    catch { }
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteHeaderPost(int id, int combineId)
        {
            if (id != 0 && combineId != 0)
            {
                Combine combine = db.Combines
                    .Where(c => c.Id == combineId)
                    .Include(c => c.Headers)
                    .FirstOrDefault();

                if (combine != null)
                {
                    try
                    {
                        Header header = combine.Headers
                            .Single(h => h.Id == id);

                        combine.Headers.Remove(header);
                        db.SaveChanges();

                        return RedirectToAction(nameof(Details),
                            new { id = combineId });
                    }
                    catch { }
                }
            }

            return NotFound();
        }
    }
}
