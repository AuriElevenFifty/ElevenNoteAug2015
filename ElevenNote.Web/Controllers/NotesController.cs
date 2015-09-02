using ElevenNote.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            var notes = new List<NoteListViewModel>();
            notes.Add(new NoteListViewModel()
            {
                Id = 0,
                DateCreated = DateTime.Parse("1/10/2000 8:00 AM"),
                DateModified = DateTime.UtcNow,
                IsFavorite = true,
                Title = "Some note title"
            });
            notes.Add(new NoteListViewModel()
            {
                Id = 1,
                DateCreated = DateTime.UtcNow.AddMonths(-2),
                DateModified = DateTime.UtcNow,
                IsFavorite = true,
                Title = "Another note"
            });
            notes.Add(new NoteListViewModel()
            {
                Id = 2,
                DateCreated = DateTime.UtcNow.AddMonths(-2),
                DateModified = null,
                IsFavorite = false,
                Title = "Still, yes, another note"
            });
            return View(notes);
        }
    }
}