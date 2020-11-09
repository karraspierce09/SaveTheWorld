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
    public class TipDetail
    {

        public int TipID { get; set; }
        public string TipText { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }

        [ForeignKey(nameof(Owner))]
        [Display(Name = "Author")]
        public virtual Owner Owner { get; set; }
    }
}
