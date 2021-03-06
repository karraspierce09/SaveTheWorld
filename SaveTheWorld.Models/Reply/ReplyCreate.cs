﻿using SaveTheWorld.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models//.Reply
{   // We only need to include things in this class that are needed to make a reply
    public class ReplyCreate
    {
        [Key]
        public int ReplyId { get; set; }

 
        [ForeignKey(nameof(Tip))]
        public int TipId { get; set; }
        public virtual Tip Tip { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please type at least 1 character.")]
        [MaxLength(8000, ErrorMessage = "Please have no more than 8000 characters.")]
        [Display(Name = "Your Reply")]
        public string ReplyText { get; set; }

        //Owner class needs to be made/edited first
        [Required]
        [ForeignKey(nameof(Owner))]
        [Display(Name = "Author")]

        public string Id { get; set; }  //owner ID
        public virtual Owner Owner { get; set; }

    }
}
