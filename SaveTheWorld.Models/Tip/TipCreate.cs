using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Jill's
namespace SaveTheWorld.Models.Tip
{
    public class TipCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character")] // [MinLength(50, ErrorMessage = "Please enter at least 50 characters")]
        [MaxLength(5000, ErrorMessage = "There are too many characters in this field.  Can only have 5000 characters.")]
        public string TipText { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters. Can only have 100 for the Title.")]
        public string Title { get; set; }

        // do not need an id to create a tip since it will be made automatically: public int TipID { get; set; }
    }
}
