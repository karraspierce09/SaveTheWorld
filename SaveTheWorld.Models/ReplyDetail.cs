using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models
{   // This section will let us view all the properties of a reply.
    public class ReplyDetail
    {
        // do not need Key, Required, Min/Max lengths here
        public int ReplyId { get; set; }

        //[ForeignKey(nameof(Tip))]
        //public int TipId { get; set; }
        //public virtual Tip Tip { get; set; }

        // do not need Key, Required, Min/Max lengths here
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

        [Display(Name = "Date Edited")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
