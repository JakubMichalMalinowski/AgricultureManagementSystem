using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                if (equipmentId != 0)
                {
                    IQueryable<Equipment> equipmentEnum = equipmentType switch
                    {
                        EquipmentType.Tractor => db.Tractors,
                        EquipmentType.Combine => db.Combines,
                        EquipmentType.Machine => db.Machines,
                        EquipmentType.Trailer => db.Trailers,
                        EquipmentType.Header => db.Header,
                        _ => null
                    };

                    if (equipmentEnum != null)
                    {
                        Equipment equipment = equipmentEnum
                            .Where(e => e.Id == equipmentId)
                            .Include(e => e.Services)
                            .FirstOrDefault();

                        if (equipment != null)
                        {
                            equipment.Services.Add(service);
                            db.SaveChanges();
                            return RedirectToAction("Details",
                                equipmentType.ToString(),
                                new { id = equipmentId } );
                        }
                    }
                }

                return NotFound();
            }

            return View(service);
        }
    }
}
