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
    public class RateController : Controller
    {
        private CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: Rate
        public ActionResult Index()
        {
            var loanRates = db.LoanRates.Include(r => r.Loan);
            return View(loanRates.ToList());
        }

        // GET: Rate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.LoanRates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // GET: Rate/Create
        public ActionResult Create()
        {
            ViewBag.IdLoan = new SelectList(db.Loans, "IdLoan", "IdLoan");
            return View();
        }

        // POST: Rate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRate,Amount,AmountForInterest,PaymentStatus,DateDue,IdLoan")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.LoanRates.Add(rate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLoan = new SelectList(db.Loans, "IdLoan", "IdLoan", rate.IdLoan);
            return View(rate);
        }

        // GET: Rate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.LoanRates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLoan = new SelectList(db.Loans, "IdLoan", "IdLoan", rate.IdLoan);
            return View(rate);
        }

        // POST: Rate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRate,Amount,AmountForInterest,PaymentStatus,DateDue,IdLoan")] Rate rate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLoan = new SelectList(db.Loans, "IdLoan", "IdLoan", rate.IdLoan);
            return View(rate);
        }

        // GET: Rate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rate rate = db.LoanRates.Find(id);
            if (rate == null)
            {
                return HttpNotFound();
            }
            return View(rate);
        }

        // POST: Rate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rate rate = db.LoanRates.Find(id);
            db.LoanRates.Remove(rate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult PayRate(int idOfRate)
        {
            

            var rate = db.LoanRates.Find(idOfRate);

            // mark the rate as paid
            rate.PaymentStatus = RateStatus.Paid;
            db.SaveChanges();

            // I have the rate now give it to the View and also pass the member with a ViewBag so we do not need a ViewModel
            // Not anymore, just request his/hers name on the signature on the document


            return View(rate);
        }


        public ActionResult PayRateAsPDF(int idOfRate)
        {
            var report = new Rotativa.ActionAsPdf("PayRate", new { idOfRate });

            return report;
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
