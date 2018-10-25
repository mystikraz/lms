using LMS.Models;
using LMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string option, string search)
        {
            if (option == "Book")
            {
                var books = db.Books.Where(x=>x.Name==search||search==null).ToList();
                
                return View(books);
            }
            else if (option == "Author")
            {
                var books = db.Books.Where(x => x.Authors.FirstName == search || search == null).ToList();

                return View(books);
            }
            else
            {
                var books = db.Books.Where(x => x.Publishers.Name == search || search == null).ToList();

                return View(books);
            }
            
        }

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