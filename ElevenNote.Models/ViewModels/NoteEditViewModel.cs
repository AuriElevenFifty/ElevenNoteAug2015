using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.ViewModels
{
    public class NoteEditViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Contents { get; set; }
    }
}
