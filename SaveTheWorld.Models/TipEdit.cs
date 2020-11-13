using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models
{
    public class TipEdit
    {

        public int TipId { get; set; }
        public string TipText { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date Created")] // stretch goal to add
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date Edited")] // stretch goal to add
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
