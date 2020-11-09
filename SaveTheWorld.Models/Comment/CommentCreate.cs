using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models
{
    public class CommentCreate
    {
        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        [MaxLength(100, ErrorMessage = "Please do not enter more than 100 characters.")]
        public string CommentText { get; set; }

    }
}
