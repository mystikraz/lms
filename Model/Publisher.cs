﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Books")]
        public int BookId { get; set; }
        public virtual Book Books { get; set; }
    }
}
