using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using Model;
using Vereyon.Web;

namespace LMS.Controllers
{
    public class LoansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Loans
        public ActionResult Index(string option, string search)
        {
            if (option == "id")
            {
                int memberId = 0;
                if (search != null)
                {
                    memberId = Convert.ToInt32(search);

                }
                var loans = db.Loans.Include(l => l.Books).Include(l => l.Members).Where(x => x.MemberId == memberId);
                return View(loans.ToList());

            }
            else if (option == "memberName")
            {
                var loans = db.Loans.Include(l => l.Books).Include(l => l.Members).Where(x => x.Members.FirstName == search || x.Members.LastName == search);
                return View(loans.ToList());
            }
            else if (option == "bookTitle")
            {
                var loans = db.Loans.Include(l => l.Books).Include(l => l.Members).Where(x => x.Books.Name == search);
                return View(loans.ToList());
            }

            else
            {
                var loans = db.Loans.Include(l => l.Books).Include(l => l.Members);
                return View(loans.ToList());
            }

        }

        // GET: Loans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loans/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookId,LoanOn,Quantity,DateReturned,AgeRestricted,MemberId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                var books = db.Books.Find(loan.BookId);
                //var loans = db.Loans.Find(loan.BookId);
                var loans = db.Loans.Where(x => x.BookId == loan.BookId).FirstOrDefault();
                ViewBag.BookId = new SelectList(db.Books, "Id", "Name", loan.BookId);
                ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", loan.MemberId);
                //if (loanQuantity > 0)
                //{
                //    FlashMessage.Warning("The book is not available currenlty!");
                //    return View(loan);
                //}
                if (books == null)
                {
                    FlashMessage.Warning("The book is not on the shelf currently!!");

                    return View(loan);
                }
                if (loans != null)
                {
                    int bookOnShelf = books.Quantities - loans.Quantity;

                    if (bookOnShelf < loan.Quantity)
                    {
                        FlashMessage.Warning(@"We have {0} books on the shelf currently!", bookOnShelf);

                        return View(loan);
                    }
                }

                //if (books.Quantities <= loanQuantity)
                //{
                //    FlashMessage.Warning("The Quantity of the book is less on the shelf!");
                //    return View(loan);

                //}
                db.Loans.Add(loan);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(loan);
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name", loan.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", loan.MemberId);
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookId,LoanOn,Quantity,DateReturned,MemberId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "Id", "Name", loan.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", loan.MemberId);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loans.Find(id);
            db.Loans.Remove(loan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
