using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LMS.ViewModel
{
    public class BookLoanViewModel
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
        [ForeignKey("Loans")]
        public int onShelf { get; set; }
        public virtual Loan Loans { get; set; }
    }
}