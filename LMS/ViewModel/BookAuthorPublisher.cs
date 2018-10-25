using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.ViewModel
{
    public class BookAuthorPublisher
    {
        public List<Book> books { get; set; }
        public List<Author> authors { get; set; }
        public List<Publisher> publishers { get; set; }
    }
}