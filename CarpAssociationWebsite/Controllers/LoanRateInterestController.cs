using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarpAssociationWebsite.DataAccessLayer;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.Controllers
{
    public class LoanRateInterestController : Controller
    {
        private CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: LoanRateInterest
        public ActionResult Index()
        {
            return View(db.LoanRateInterests.ToList());
        }

        // GET: LoanRateInterest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanRateInterest loanRateInterest = db.LoanRateInterests.Find(id);
            if (loanRateInterest == null)
            {
                return HttpNotFound();
            }
            return View(loanRateInterest);
        }

        // GET: LoanRateInterest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanRateInterest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Percentage,Date")] LoanRateInterest loanRateInterest)
        {
            if (ModelState.IsValid)
            {
                db.LoanRateInterests.Add(loanRateInterest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loanRateInterest);
        }

        // GET: LoanRateInterest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanRateInterest loanRateInterest = db.LoanRateInterests.Find(id);
            if (loanRateInterest == null)
            {
                return HttpNotFound();
            }
            return View(loanRateInterest);
        }

        // POST: LoanRateInterest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Percentage,Date")] LoanRateInterest loanRateInterest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanRateInterest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loanRateInterest);
        }

        // GET: LoanRateInterest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanRateInterest loanRateInterest = db.LoanRateInterests.Find(id);
            if (loanRateInterest == null)
            {
                return HttpNotFound();
            }
            return View(loanRateInterest);
        }

        // POST: LoanRateInterest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanRateInterest loanRateInterest = db.LoanRateInterests.Find(id);
            db.LoanRateInterests.Remove(loanRateInterest);
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
