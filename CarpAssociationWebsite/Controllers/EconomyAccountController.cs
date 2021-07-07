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
    public class EconomyAccountController : Controller
    {
        private readonly CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: EconomyAccount
        public ActionResult Index()
        {
            var economyAccounts = db.EconomyAccounts.Include(e => e.Member);
            return View(economyAccounts.ToList());
        }

        // GET: EconomyAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            if (economyAccount == null)
            {
                return HttpNotFound();
            }
            return View(economyAccount);
        }

        // GET: EconomyAccount/Create
        public ActionResult Create()
        {
            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "NameAndPID");

            // Get the latest InterestRate
            var latestInterestRate = db.EconomyAccountInterests.OrderByDescending(p => p.Date)
                .FirstOrDefault();

            ViewBag.InterestRateLatest = latestInterestRate.Percentage;

            return View();
        }

        // POST: EconomyAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EconomyAccountId,DepositAmount,DateStarted,Duration")] EconomyAccount economyAccount)
        {
            if (ModelState.IsValid)
            {

                // Profit from interest
                economyAccount.ProfitFromInterest = 120.0M;

                // Taxed Amount
                economyAccount.TaxedAmount = 12.0M;

                // Get the latest InterestRate
                var latestInterestRate = db.EconomyAccountInterests.OrderByDescending(p => p.Date)
                    .FirstOrDefault();

                economyAccount.InterestRate = latestInterestRate.Percentage;

                db.EconomyAccounts.Add(economyAccount);
                db.SaveChanges();


                //return RedirectToAction("ActiveLoansAndEconomyAccountsIndex", "ActiveLoansAndEconomyAccounts");

                var newlyCreatedEconomyAccount = db.EconomyAccounts.SingleOrDefault(b => b.EconomyAccountId == economyAccount.EconomyAccountId);

                return RedirectToAction("EconomyAccountSummary", new { idOfEconomyAccount = newlyCreatedEconomyAccount.EconomyAccountId });
            }

            // change select list to one with ID and name like on Loan
            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "NameAndPID", economyAccount.EconomyAccountId);
            return View(economyAccount);
        }

        // GET: EconomyAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            if (economyAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "NameAndPID", economyAccount.EconomyAccountId);
            return View(economyAccount);
        }

        // POST: EconomyAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EconomyAccountId,DepositAmount,DateStarted,Duration,InterestRate,ProfitFromInterest,TaxedAmount")] EconomyAccount economyAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(economyAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EconomyAccountId = new SelectList(db.Members, "Id", "NameAndPID", economyAccount.EconomyAccountId);
            return View(economyAccount);
        }

        // GET: EconomyAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            if (economyAccount == null)
            {
                return HttpNotFound();
            }
            return View(economyAccount);
        }

        // POST: EconomyAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EconomyAccount economyAccount = db.EconomyAccounts.Find(id);
            db.EconomyAccounts.Remove(economyAccount);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("ActiveLoansAndEconomyAccountsIndex", "ActiveLoansAndEconomyAccounts");
        }


        public ActionResult EconomyAccountSummary(int idOfEconomyAccount)
        {
            // search the Economy account


            var loan = db.EconomyAccounts.SingleOrDefault(b => b.EconomyAccountId == idOfEconomyAccount);

            // I have the economy account now give it to the View

            return View(loan);
        }

        
        public ActionResult PrintEconomyAccountSummaryAsPDF(int idOfEconomyAccount)
        {
            // Here we have the View itself, this one includes the website header and footer
            var report = new Rotativa.ActionAsPdf("EconomyAccountSummary", new { idOfEconomyAccount });


            return report;
        }


        public ActionResult Withdraw(int idOfEconomyAccount)
        {
            // search the Economy account


            var economyAccount = db.EconomyAccounts.SingleOrDefault(b => b.EconomyAccountId == idOfEconomyAccount);


            // I have the economy account now give it to the View

            return View(economyAccount);
        }


        public ActionResult WithdrawAsPDF(int idOfEconomyAccount)
        {
            // Here we have the View itself, this one includes the website header and footer
            var withdrawConfirmationDocument = new Rotativa.ActionAsPdf("Withdraw", new { idOfEconomyAccount });


            return withdrawConfirmationDocument;
        }

        

        public static int ConvertEnumMonthsToInteger(NumberOfMonths numberOfMonths)
        {
            int noOfMonths = 1;

            switch (numberOfMonths)
            {
                case NumberOfMonths.SixMonths:
                    noOfMonths = 6;
                    break;

                case NumberOfMonths.ThreeMonths:
                    noOfMonths = 3;
                    break;

                case NumberOfMonths.TwelveMonths:
                    noOfMonths = 12;
                    break;

                case NumberOfMonths.TwentyFourMonths:
                    noOfMonths = 24;
                    break;

                case NumberOfMonths.ThirtySixMonths:
                    noOfMonths = 36;
                    break;

            }

            return noOfMonths;
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
