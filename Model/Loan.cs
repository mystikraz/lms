using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Loan
    {
        public int Id { get; set; }

        [ForeignKey("Books")]
        public int BookId { get; set; }
        public virtual Book Books { get; set; }

        public DateTime LoanOn { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateReturned { get; set; }

        [ForeignKey("Members")]
        public int MemberId { get; set; }
        public virtual Member Members { get; set; }


    }
}
