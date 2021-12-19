using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext db;

        public ServiceController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int equipmentId,
            EquipmentType equipmentType,
            Service service)
        {
            if (ModelState.IsValid)
            {
                Equipment equipment = GetEquipment(equipmentId, equipmentType);
                if (equipment != null)
                {
                    equipment.Services.Add(service);
                    db.SaveChanges();
                    return RedirectToAction("Details",
                        equipmentType.ToString(),
                        new { id = equipmentId },
                        "service-partial-" + service.Id);
                }

                return NotFound();
            }

            return View(service);
        }

        public IActionResult Edit(int id,
            int equipmentId,
            EquipmentType equipmentType)
        {
            if (id != 0)
            {
                Equipment equipment = GetEquipment(equipmentId, equipmentType);

                if (equipment != null)
                {
                    try
                    {
                        Service service = equipment.Services
                            .Single(s => s.Id == id);

                        return View(service);
                    }
                    catch { }
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service,
            int equipmentId,
            EquipmentType equipmentType)
        {
            if (ModelState.IsValid)
            {
                Equipment equipment = GetEquipment(equipmentId, equipmentType);

                if (equipment != null)
                {
                    int serviceListIndex = equipment.Services.ToList()
                        .FindIndex(s => s.Id == service.Id);

                    equipment.Services[serviceListIndex].Update(service);

                    db.SaveChanges();

                    return RedirectToAction("Details",
                        equipmentType.ToString(),
                        new { id = equipmentId },
                        "service-partial-" + service.Id);
                }

                return NotFound();
            }

            return View(service);
        }

        public IActionResult Delete(int id,
            int equipmentId,
            EquipmentType equipmentType)
        {
            if (id != 0)
            {
                Equipment equipment = GetEquipment(equipmentId, equipmentType);

                if (equipment != null)
                {
                    try
                    {
                        Service service = equipment.Services
                            .Single(s => s.Id == id);

                        return View(service);
                    }
                    catch { }
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id,
            int equipmentId,
            EquipmentType equipmentType)
        {
            if (id != 0)
            {
                Equipment equipment = GetEquipment(equipmentId, equipmentType);

                if (equipment != null)
                {
                    try
                    {
                        Service service = equipment.Services
                            .Single(s => s.Id == id);

                        equipment.Services.Remove(service);
                        db.SaveChanges();

                        return RedirectToAction("Details",
                            equipmentType.ToString(),
                            new { id = equipmentId },
                            "service-partial");
                    }
                    catch { }
                }
            }

            return NotFound();
        }

#nullable enable
        private Equipment? GetEquipment(int equipmentId,
            EquipmentType equipmentType)
#nullable disable
        {
            Equipment equipment = null;

            if (equipmentId != 0)
            {
                IQueryable<Equipment> equipmentQueryable = equipmentType switch
                {
                    EquipmentType.Tractor => db.Tractors,
                    EquipmentType.Combine => db.Combines,
                    EquipmentType.Machine => db.Machines,
                    EquipmentType.Trailer => db.Trailers,
                    EquipmentType.Header => db.Header,
                    _ => null
                };

                if (equipmentQueryable != null)
                {
                    equipment = equipmentQueryable
                        .Where(e => e.Id == equipmentId)
                        .Include(e => e.Services)
                        .FirstOrDefault();
                }
            }

            return equipment;
        }
    }
}
