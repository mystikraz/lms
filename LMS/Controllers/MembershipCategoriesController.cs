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

namespace LMS.Controllers
{
    public class MembershipCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MembershipCategories
        public ActionResult Index()
        {
            var membershipCategories = db.MembershipCategories.Include(m => m.Members);
            return View(membershipCategories.ToList());
        }

        // GET: MembershipCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCategory membershipCategory = db.MembershipCategories.Find(id);
            if (membershipCategory == null)
            {
                return HttpNotFound();
            }
            return View(membershipCategory);
        }

        // GET: MembershipCategories/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName");
            return View();
        }

        // POST: MembershipCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AllowedDuration,AllowedQuantity,Price,penalty,MemberId")] MembershipCategory membershipCategory)
        {
            if (ModelState.IsValid)
            {
                db.MembershipCategories.Add(membershipCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", membershipCategory.MemberId);
            return View(membershipCategory);
        }

        // GET: MembershipCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCategory membershipCategory = db.MembershipCategories.Find(id);
            if (membershipCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", membershipCategory.MemberId);
            return View(membershipCategory);
        }

        // POST: MembershipCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AllowedDuration,AllowedQuantity,Price,penalty,MemberId")] MembershipCategory membershipCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", membershipCategory.MemberId);
            return View(membershipCategory);
        }

        // GET: MembershipCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCategory membershipCategory = db.MembershipCategories.Find(id);
            if (membershipCategory == null)
            {
                return HttpNotFound();
            }
            return View(membershipCategory);
        }

        // POST: MembershipCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembershipCategory membershipCategory = db.MembershipCategories.Find(id);
            db.MembershipCategories.Remove(membershipCategory);
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
