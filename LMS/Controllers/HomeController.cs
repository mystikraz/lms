using LMS.Models;
using LMS.ViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        BookLoanVM BookLoan = new BookLoanVM();

        public ActionResult Index(string option, string search)
        {
            List<Book> books = new List<Book>();
            if (option == "Book")
            {

                books = db.Books.Where(x => x.Name == search || search == null).ToList();
                //var booksOnShelf = from l in db.Loans join b in db.Books on l.BookId equals b.Id join a in db.Authors on b.AuthorId equals a.Id join p in db.Publishers on b.PublisherId equals p.Id where b.Name == search select new { b, l, a, p };

            }
            else if (option == "Author")
            {
                books = db.Books.Where(x => x.Authors.FirstName == search || search == null).ToList();

            }
            else
            {
                books = db.Books.Where(x => x.Publishers.Name == search || search == null).OrderBy(x=>x.PublishedOn).OrderBy(x=>x.Authors.FirstName).ToList();

            }
            BookLoan.Books = books;
            //BooksOnLoan(option,search);


            return View(BookLoan);

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            BookLoan = new BookLoanVM();
            ViewBag.OnShelf = true;
            //var booksOnLoan = (from l in db.Loans join b in db.Books on l.BookId equals b.Id where b.Id == id && l.DateReturned!=null select new { l }).ToList().Select(x => x.l).ToList();
            var booksOnLoan = (from l in db.Loans join b in db.Books on l.BookId equals b.Id where b.Id == id && l.DateReturned == null select new { l }).ToList().Select(x => x.l).ToList();
            BookLoan.Loans = booksOnLoan;
            BookLoan.Book = book;
            return View(BookLoan);
        }

        //public void BooksOnLoan()
        //{
        //    ViewBag.OnShelf = true;
        //    var booksOnLoan = (from l in db.Loans join b in db.Books on l.BookId equals b.Id where b.Name == search select new { l }).ToList().Select(x => x.l).ToList();
        //    BookLoan.Loans = booksOnLoan;
            //else if (option == "Author")
            //{
            //    ViewBag.OnShelf = true;
            //    var booksOnLoan = (from l in db.Loans join a in db.Authors on l.BookId equals a.Id where a.FirstName == search select new { l }).ToList().Select(x => x.l).ToList();
            //    BookLoan.Loans = booksOnLoan;
            //}
            //else if (option == "Publisher")
            //{
            //    ViewBag.OnShelf = true;
            //    var booksOnLoan = (from l in db.Loans join p in db.Publishers on l.BookId equals p.Id where p.Name == search select new { l }).ToList().Select(x => x.l).ToList();
            //    BookLoan.Loans = booksOnLoan;
            //}



            //var totalBooksOnLoan = Convert.ToInt32(booksOnLoan);

        //}
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}