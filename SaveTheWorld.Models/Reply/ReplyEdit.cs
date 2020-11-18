﻿using SaveTheWorld.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Models
{   // Properties for editing/updating a reply
    public class ReplyEdit
    {
        public int ReplyId { get; set; }

        [ForeignKey(nameof(Tip))]
        public int TipId { get; set; }
        public virtual Tip Tip { get; set; }

        public string ReplyText { get; set; }

        // Owner class needs to be made/edited first
        [ForeignKey(nameof(Author))]
        public virtual Owner Author { get; set; }

    }
}
