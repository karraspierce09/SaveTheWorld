using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models
{
    public class TipCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage ="There are too many characters. Can only have 100 for the Title.")]
        public string Title { get; set; }
        [Required]
        [MinLength(50, ErrorMessage = "Please enter at least 50 characters")]
        [MaxLength(5000, ErrorMessage = "There are too many characters in this field.  Can only have 200 characters.")]
        public string TipText { get; set; }

        public int TipId { get; set; }
    }
}
