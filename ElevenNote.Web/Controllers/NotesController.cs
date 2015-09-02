using ElevenNote.Models.ViewModels;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ElevenNote.Web.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            if (TempData["Result"] != null)
            {
                ViewBag.Success = TempData["Result"];
                TempData.Remove("Result");
            }
            var noteService = new NoteService();
            var notes = noteService.GetAllForUser(Guid.Parse(User.Identity.GetUserId()));
            return View(notes);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Create(model, userId);
                TempData.Add("Result", result ? "Note added." : "Note not added.");
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}