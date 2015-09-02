

using ElevenNote.DataAccess;
using ElevenNote.Models;
using ElevenNote.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService
    {
        /// <summary>
        /// Create a note.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Create(NoteEditViewModel model, Guid userId)
        {
            using (var context = new ElevenNoteDataContext())
            {
                var note = new Note();
                note.Title = model.Title;
                note.Contents = model.Contents;
                note.DateCreated = DateTime.UtcNow;
                note.ApplicationUserId = userId;

                context.Notes.Add(note);
                var result = context.SaveChanges();
                return result == 1;
            }

        }

        /// <summary>
        /// Gets all notes for the passed user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<NoteListViewModel> GetAllForUser(Guid userId)
        {
            using (var context = new ElevenNoteDataContext())
            {
                var result = (from note in context.Notes
                              where note.ApplicationUserId == userId
                              select new NoteListViewModel()
                              {
                                  DateCreated = note.DateCreated.Value,
                                  DateModified = note.DateModified,
                                  Id = note.Id,
                                  Title = note.Title,
                                  IsFavorite = note.IsFavorite
                              }).ToList();

                return result;
            }
        }

        /// <summary>
        /// Retrieves the passed note for the passed user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public NoteEditViewModel GetById(int id, Guid userId)
        {
            using (var context = new ElevenNoteDataContext())
            {
                var result = (from note in context.Notes
                              where note.ApplicationUserId == userId
                              && note.Id == id
                              select new NoteEditViewModel()
                              {
                                  Contents = note.Contents,
                                  Id = note.Id,
                                  Title = note.Title
                              }).SingleOrDefault();

                return result;
            }
        }

        public bool Update(NoteEditViewModel model, Guid userId)
        {
            using (var context = new ElevenNoteDataContext())
            {
                // Attempt to get the note from the database.
                var note = context.Notes.Where(w => w.Id == model.Id && w.ApplicationUserId == userId).SingleOrDefault();

                // Functionally equivalent expressive syntax:
                //var note2 = (from w in context.Notes
                //             where w.Id == model.Id && w.ApplicationUserId == userId
                //             select w).SingleOrDefault();

                // Make sure we actually received a note back before updating.
                if (note == null) return false;

                // Update the note.
                note.Contents = model.Contents;
                note.Title = model.Title;
                note.DateModified = DateTime.UtcNow;

                // Save the changes to the database.
                var result = context.SaveChanges();
                return result == 1 /* was 1 record (success) or 0 records (unsuccessful) updated? */;
            }
        }

        public bool Delete(int id, Guid userId)
        {
            using (var context = new ElevenNoteDataContext())
            {
                // Attempt to get the note from the database.
                var note = context.Notes.Where(w => w.Id == id && w.ApplicationUserId == userId).SingleOrDefault();

                // Make sure we actually received a note back before updating.
                if (note == null) return false;

                // Delete the note.
                context.Notes.Remove(note);

                // Save the changes to the database.
                var result = context.SaveChanges();

                // Return the result.
                return result == 1;
            }


        }

        public bool ToggleFavorite(int id, Guid userId)
        {
            using (var context = new ElevenNoteDataContext())
            {
                // Attempt to get the note from the database.
                var note = context.Notes.Where(w => w.Id == id && w.ApplicationUserId == userId).SingleOrDefault();

                // Make sure we actually received a note back before updating.
                if (note == null) return false;

                // Toggle the note IsFavorite flag.
                note.IsFavorite = !note.IsFavorite;

                // Save the changes to the database.
                var result = context.SaveChanges();

                // Return the result.
                return result == 1;
            }


        }

    }
}

