using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Jill's
namespace SaveTheWorld.Models.Tip
{
    public class TipDetail
    {
        public int TipID { get; set; }
        public string TipText { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }

        //[ForeignKey(nameof(OwnerAuthor))]
        //[Display(Name = "Author")]
        //public virtual Owner Owner { get; set; }
    }
}
