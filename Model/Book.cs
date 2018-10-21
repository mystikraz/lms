using System;
using System.Collections.Generic;
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
        public int LoanDuration { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
