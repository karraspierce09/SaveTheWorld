using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Data
{
    public class Disapproval
    {

        [Key]
        public int DisapprovalId { get; set; }
        public Tip DisapprovalTip { get; set; }

        [Required]
        public Owner Disapprovaled { get; set; }
    }
}
