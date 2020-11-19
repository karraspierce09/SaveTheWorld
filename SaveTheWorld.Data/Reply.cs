using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [ForeignKey(nameof(Tip))]
        public int TipId { get; set; }
        public virtual Tip Tip { get; set; }

        [Required]
        [Display(Name = "Your Reply")]
        public string ReplyText { get; set; }
       
        [Required]
        [ForeignKey(nameof(Owner))]
        [Display(Name = "Author")]

        public string Id { get; set; }
        public virtual Owner Owner { get; set; }

        [Required]
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
