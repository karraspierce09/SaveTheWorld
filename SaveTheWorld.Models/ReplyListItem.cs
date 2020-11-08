using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models
{   // Make it public, add properties (These are the properties that will show up in the view), add using statements
    // We only need things in this class that the viewer will see from a posted reply
    public class ReplyListItem
    {
        public int ReplyId { get; set; }

        //[ForeignKey(nameof(Tip))]
        //public int TipId { get; set; }
        //public virtual Tip Tip { get; set; }

        // do not need Required here
        // do not need Min/Maxlengths here
        [Display(Name = "Your Reply")]
        public string ReplyText { get; set; }

        //[ForeignKey(nameof(Author))]
        //public virtual Owner Author { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "Written By")]
        public string Name { get; set; }

        // do not need Required here
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
