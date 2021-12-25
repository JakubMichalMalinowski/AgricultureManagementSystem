using AgricultureManagementSystem.Data;
using AgricultureManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgricultureManagementSystem.Controllers
{
    public class FinanceController : Controller
    {
        private readonly ApplicationDbContext db;

        public FinanceController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Transfer> transfers = db.Transfers
                .OrderByDescending(t => t.DateTime);
            decimal total = 0.0M;

            foreach (Transfer transfer in transfers)
            {
                if (transfer.TransferIn)
                {
                    total += transfer.Amount;
                }
                else
                {
                    total -= transfer.Amount;
                }
            }

            BalanceWithTransfersEnumerable balanceWithTransfers = new()
            {
                Balance = total,
                Transfers = transfers
            };

            return View(balanceWithTransfers);
        }

        public IActionResult Transfer()
            => View();

        [Route("[controller]/[action]/{inOut}")]
        public IActionResult Transfer(string inOut)
        {
            DateTime now = DateTime.Now;
            now = new DateTime(now.Year,
                now.Month,
                now.Day,
                now.Hour,
                now.Minute,
                now.Second);

            Transfer transfer = new()
            {
                DateTime = now,
                TransferIn = inOut switch
                {
                    "In" => true,
                    _ => false
                }
            };

            return View("TransferForm", transfer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTransfer(Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                transfer.Amount = Math.Abs(transfer.Amount);
                db.Transfers.Add(transfer);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View("TransferForm", transfer);
        }

        public IActionResult EditTransfer(int id)
        {
            if (id != 0)
            {
                Transfer transfer = db.Transfers.Find(id);
                if (transfer != null)
                    return View(transfer);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTransfer(Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                db.Transfers.Update(transfer);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(transfer);
        }

        public IActionResult DeleteTransfer(int id)
        {
            if (id != 0)
            {
                Transfer transfer = db.Transfers.Find(id);
                if (transfer != null)
                    return View(transfer);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTransferPost(int id)
        {
            if (id != 0)
            {
                Transfer transfer = db.Transfers.Find(id);
                if (transfer != null)
                {
                    db.Transfers.Remove(transfer);
                    db.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }
    }
}
