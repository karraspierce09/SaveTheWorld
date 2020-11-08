using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models
{   // Properties for editing/updating a reply
    public class ReplyEdit
    {
        public int ReplyId { get; set; }

        //[ForeignKey(nameof(Tip))]
        //public int TipId { get; set; }
        //public virtual Tip Tip { get; set; }

        public string ReplyText { get; set; }

        //[ForeignKey(nameof(Author))]
        //public virtual Owner Author { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
    }
}
