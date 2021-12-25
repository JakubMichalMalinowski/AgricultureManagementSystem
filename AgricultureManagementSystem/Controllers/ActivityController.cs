using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext db;

        public ActivityController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int fieldId,
            Activity activity)
        {
            if (ModelState.IsValid)
            {
                Field field = GetField(fieldId);
                if (field != null)
                {
                    field.Activities.Add(activity);
                    db.SaveChanges();

                    return RedirectToAction("Details",
                        "Field",
                        new { id = fieldId },
                        "activity-partial-" + activity.Id);
                }

                return NotFound();
            }

            return View(activity);
        }

        public IActionResult Edit(int id,
            int fieldId)
        {
            if (id != 0)
            {
                Field field = GetField(fieldId);

                if (field != null)
                {
                    try
                    {
                        Activity activity = field.Activities
                            .Single(a => a.Id == id);

                        return View(activity);
                    }
                    catch { }
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Activity activity,
           int fieldId)
        {
            if (ModelState.IsValid)
            {
                Field field = GetField(fieldId);

                if (field != null)
                {
                    int activityListIndex = field.Activities.ToList()
                        .FindIndex(a => a.Id == activity.Id);

                    try
                    {
                        field.Activities[activityListIndex].Update(activity);

                        db.SaveChanges();

                        return RedirectToAction("Details",
                            "Field",
                            new { id = fieldId },
                            "activity-partial-" + activity.Id);
                    }
                    catch { }
                }

                return NotFound();
            }

            return View(activity);
        }

        public IActionResult Delete(int id,
            int fieldId)
        {
            if (id != 0)
            {
                Field field = GetField(fieldId);

                if (field != null)
                {
                    try
                    {
                        Activity activity = field.Activities
                            .Single(a => a.Id == id);

                        return View(activity);
                    }
                    catch { }
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id,
            int fieldId)
        {
            if (id != 0)
            {
                Field field = GetField(fieldId);

                if (field != null)
                {
                    try
                    {
                        Activity activity = field.Activities
                            .Single(a => a.Id == id);

                        field.Activities.Remove(activity);
                        db.SaveChanges();

                        return RedirectToAction("Details",
                            "Field",
                            new { id = fieldId },
                            "activity-partial");
                    }
                    catch { }
                }
            }

            return NotFound();
        }

#nullable enable
        private Field? GetField(int fieldId)
#nullable disable
        {
            if (fieldId != 0)
            {
                return db.Fields
                    .Where(f => f.Id == fieldId)
                    .Include(f => f.Activities)
                    .FirstOrDefault();
            }

            return null;
        }
    }
}
