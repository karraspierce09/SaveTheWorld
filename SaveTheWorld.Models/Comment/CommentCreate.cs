using SaveTheWorld.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [ForeignKey(nameof(Reply))]
        public int ReplyId { get; set; }
        public virtual Reply Reply { get; set; }

    }
}
