using ElevenNote.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class GameController : Controller
    {
        #region GET

        // GET: Game
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexGet()
        {
            var correctAnswer = new Random().Next(1, 10);
            Session["Answer"] = correctAnswer;
            return View();
        }

        #endregion

        #region POST

        // POST: Game
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(GuessingGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Guess == (int)Session["Answer"])
                {
                    ViewBag.Win = true;
                }
                else
                {
                    ViewBag.Win = false;
                }
            }
            return View(model);
        }

        #endregion

    }
}