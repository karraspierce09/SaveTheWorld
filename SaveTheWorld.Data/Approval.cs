using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Data
{
    public class Approval
    {
        [Key]
        public Tip ApprovaledTip { get; set; }

        [Required]
        public Owner Approvaled { get; set; }

    }
}