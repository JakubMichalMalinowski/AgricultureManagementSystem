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
    public class NoteController : Controller
    {
        private ApplicationDbContext db;

        public NoteController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
            => View(db.Notes.OrderBy(n => n.Index));

        public IActionResult Create()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                note.Index = db.Notes.Count();
                db.Notes.Add(note);
                db.SaveChanges();

                return RedirectToAction(nameof(Index),
                    "Note",
                    "note-" + note.Id);
            }

            return View(note);
        }

        public IActionResult Edit(int id)
            => View(db.Notes.Find(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Update(note);
                db.SaveChanges();

                return RedirectToAction(nameof(Index),
                    "Note",
                    "note-" + note.Id);
            }

            return View(note);
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                Note note = db.Notes.Find(id);

                if (note != null)
                {
                    return View(note);
                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            if (id != 0)
            {
                Note note = db.Notes.Find(id);

                if (note != null)
                {
                    db.Notes.Remove(note);
                    UpdateIndexesDuringDelete(note);
                    db.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }

        public IActionResult MoveCard(int noteId, string direction)
        {
            if (noteId != 0
                && (direction == "up" || direction == "down"))
            {
                DbSet<Note> notes = db.Notes;
                Note currentNote = notes.Find(noteId);

                Note changingNote = direction switch
                {
                    "up" => notes.Where(n => n.Index == currentNote.Index - 1)
                    .FirstOrDefault(),

                    "down" => notes.Where(n => n.Index == currentNote.Index + 1)
                    .FirstOrDefault(),

                    _ => null
                };

                int changingIndex = changingNote?.Index ?? -1;

                if (changingIndex >= 0)
                {
                    changingNote.Index = currentNote.Index;
                    currentNote.Index = changingIndex;

                    db.Notes.Update(currentNote);
                    db.Notes.Update(changingNote);

                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index),
                    "Note",
                    "note-" + noteId);
            }

            return RedirectToAction(nameof(Index));
        }

        private void UpdateIndexesDuringDelete(Note deleteNote)
        {
            IQueryable<Note> nextNotes = db.Notes
                .Where(n => n.Index > deleteNote.Index);

            foreach (Note note in nextNotes)
            {
                note.Index--;
                db.Notes.Update(note);
            }

            db.SaveChanges();
        }
    }
}
