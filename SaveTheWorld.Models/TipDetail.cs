﻿using System;
using System.Collections.Generic;
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

        //[ForeignKey(nameof(OwnerAuthor))]
        //[Display(Name = "Author")]
        //public virtual Owner Owner { get; set; }
    }
}
