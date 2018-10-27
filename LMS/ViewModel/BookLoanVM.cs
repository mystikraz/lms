using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.ViewModel
{
    public class BookLoanVM
    {
        public Loan Loan { get; set; }
        public Book Book { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Book> Books { get; set; }
    }
}