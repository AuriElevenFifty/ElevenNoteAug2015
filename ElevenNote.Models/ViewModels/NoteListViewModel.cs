using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.ViewModels
{
    public class NoteListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        public bool IsFavorite { get; set; }
    }
}
