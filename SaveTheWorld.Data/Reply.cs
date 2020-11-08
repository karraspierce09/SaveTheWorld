using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        //[ForeignKey(nameof(Tip))]
        //public int TipId { get; set; }
        //public virtual Tip Tip { get; set; }

        [Required]
        //[MinLength(1, ErrorMessage = "Please type at least 1 character.")]
        //[MaxLength(8000, ErrorMessage = "Please have no more than 8000 characters.")]
        //[Display(Name = "Your Reply")]
        public string ReplyText { get; set; }

        //[ForeignKey(nameof(Author))]
        public Guid OwnerId { get; set; }
        //public virtual Owner Author { get; set; }
        public string Name { get; set; }

        [Required]
        //[Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
