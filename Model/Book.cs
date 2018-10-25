using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantities { get; set; }
        public bool AgeRestricted { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Authors")]
        public int AuthorId { get; set; }
        public virtual Author Authors { get; set; }
        [ForeignKey("Publishers")]
        public int PublisherId { get; set; }
        public virtual Publisher Publishers { get; set; }

    }
}
