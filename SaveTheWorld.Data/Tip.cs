using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Data
{
    public class Tip
    {
        [Key]
        public int TipID { get; set; }

       [Required]
       public Guid OwnerID { get; set; }

        [ForeignKey(nameof(Owner))]
        [Display(Name = "Author")]
        public virtual Owner Owner { get; set;}

        [Required]
        public string Title { get; set; }

        [Required]
        public string TipText { get; set; }
        public string Category { get; set; }

    }
}
