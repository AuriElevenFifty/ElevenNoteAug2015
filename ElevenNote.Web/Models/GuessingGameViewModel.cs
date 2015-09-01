using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.Web.Models
{
    public class GuessingGameViewModel
    {
        [Required(ErrorMessage = "Required")]
        [MinLength(2, ErrorMessage = "Too short")]
        [MaxLength(20, ErrorMessage = "Too long")]
        [Display(Name = "Your Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(1, 10, ErrorMessage = "Must be between 1 and 10.")]
        [Display(Name = "Your Guess")]
        public int Guess { get; set; }
    }
}