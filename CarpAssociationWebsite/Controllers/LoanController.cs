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
using Rotativa;

namespace CarpAssociationWebsite.Controllers
{
    public class LoanController : Controller
    {
        private CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: Loan
        public ActionResult Index()
        {
            var loans = db.Loans.Include(l => l.Member);
            return View(loans.ToList());
        }

        // GET: Loan/Details/5
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

        // GET: Loan/Create
        public ActionResult Create()
        {
            ViewBag.IdLoan = new SelectList(db.Members, "Id", "NameAndPID");

            // Get the latest InterestRate
            var latestInterestRate = db.LoanRateInterests.OrderByDescending(p => p.Date)
                                        .FirstOrDefault();


            ViewBag.InterestRateLatest = latestInterestRate.Percentage;

            return View();
        }

        // POST: Loan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLoan,StartDate,Amount,InterestRate,NumberOfRates")] Loan loan)
        {
            if (ModelState.IsValid)
            {

                // Add balance and status here do not make the user input them because first time their value is predefined

                loan.Balance = loan.Amount; // at first balance = amount

                loan.Status = LoanStatus.Ongoing;

                // Get the latest InterestRate
                var latestInterestRate = db.LoanRateInterests.OrderByDescending(p => p.Date)
                                            .FirstOrDefault();

                loan.InterestRate = latestInterestRate.Percentage;

                ViewBag.InterestRateLatest = latestInterestRate.Percentage;

                // First add the loan without the rates in order to obtain FK

                db.Loans.Add(loan);
                db.SaveChanges();

                // Now update the loan right afterwards - add the rates list to the loan

                int noOfRates = ConvertEnumRatesNumber(loan.NumberOfRates);

                var rates = CalculateRates(loan.Amount, loan.InterestRate, noOfRates, loan.StartDate);

                var newlyCreatedLoan = db.Loans.SingleOrDefault(b => b.IdLoan == loan.IdLoan);
                if (newlyCreatedLoan != null)
                {
                    newlyCreatedLoan.Rates = rates;
                    db.SaveChanges();
                }

                // SqlException: Violation of PRIMARY KEY constraint 'PK_dbo.Loan'.
                // Cannot insert duplicate key in object 'dbo.Loan'. The duplicate key value is (1).

                // Here make a case for treating the error case when a user gives a loan to a member that already has a loan

                // TODO: Double check, now happens at the first db.SaveChanges()
                db.SaveChanges();

                // return RedirectToAction("Index");

                return RedirectToAction("LoanSummary", new { idOfLoan = newlyCreatedLoan.IdLoan});
            }


            ViewBag.IdLoan = new SelectList(db.Members, "Id", "NameAndPID", loan.IdLoan);
            return View(loan);
        }

        // GET: Loan/Edit/5
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
            ViewBag.IdLoan = new SelectList(db.Members, "Id", "NameAndPID", loan.IdLoan);
            return View(loan);
        }

        // POST: Loan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLoan,StartDate,Amount,Balance,InterestRate,NumberOfRates,Status")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLoan = new SelectList(db.Members, "Id", "NameAndPID", loan.IdLoan);
            return View(loan);
        }

        // GET: Loan/Delete/5
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

        // POST: Loan/Delete/5
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


        // helper methods for Bussiness Logic

        /// <summary>
        /// 
        /// The following method calculates and return the List of Rates for a given loan
        /// 
        /// </summary>
        /// <param name="amount">Amount of money requested by the loan. </param>
        /// <param name="interest">Interest rate for the loan. </param>
        /// <param name="numberOfRates">Number of rates that the loan has. </param>
        /// <param name="startDate">The date when the loan was requested, used to calculate the due date for the rates. </param>
        /// <returns>List<Rate> containing all the rates for the given loan ready to be added in the db.</returns>
        public List<Rate> CalculateRates(decimal amount, decimal interest, int numberOfRates, DateTime startDate)
        {
            // At first balance is equal to the amount of money requested
            decimal balance = amount;
            
            // Calculate how much to pay for a rate (without interest)
            decimal amountForASingleRate = amount / numberOfRates;

            List<Rate> rates = new List<Rate>() { };

            DateTime lastUsedDate = startDate;

            for(int index = 1; index <= numberOfRates; index++)
            {
                // TODO: Add the corect formula here
                decimal interestToPayForCurrentRate = balance * (interest / 100);

                // No longer needed, amount and interest_amount are being kept separately
                // decimal amountToPayForCurrentRate = interestToPayForCurrentRate + amountForASingleRate;

                // A rate was calculated now cut it from balance
                balance -= amountForASingleRate;

                // Compute the day when the rate payment is due
                DateTime currentRateDateDue = lastUsedDate.AddMonths(1);

                Rate rateToPay = new Rate() 
                { 
                    PaymentStatus = RateStatus.WaitingPayment,
                    Amount = amountForASingleRate, 
                    AmountForInterest = interestToPayForCurrentRate, 
                    DateDue= currentRateDateDue
                };

                // Update lastUsedDate to reflect the new last added month on last for loop rate
                lastUsedDate = currentRateDateDue;

                rates.Add(rateToPay);
            }
            return rates;
        }

        /// <summary>
        /// ConvertEnumRatesNumber
        /// 
        /// Helper Function used to transform the rates from enum to an actual integer so we can perform math operations.
        /// 
        /// </summary>
        /// <param name="numberOfRates">The number of rates as an enum.</param>
        /// <returns></returns>
        public int ConvertEnumRatesNumber(NumberOfRates numberOfRates)
        {
            int noOfRates = 1;

            switch (numberOfRates)
            {
                case NumberOfRates.SixRates:
                    noOfRates = 6;
                    break;

                case NumberOfRates.ThreeRates:
                    noOfRates = 3;
                    break;

                case NumberOfRates.TwelveRates:
                    noOfRates = 12;
                    break;

                case NumberOfRates.TwentyFourRates:
                    noOfRates = 24;
                    break;

                case NumberOfRates.ThirtySixRates:
                    noOfRates = 36;
                    break;

            }

            return noOfRates;
        }


        /// <summary>
        /// LoanSummary
        /// 
        /// The following ActionResult is called after a Loan was created in order to show the summary of the loan
        /// this ActionResult is also used by the Rotativa library to be transformed in a PDF so the requesting member can sign 
        /// that he confirms the loan.
        /// 
        /// </summary>
        /// <returns>the view with the loan summary the rates and all</returns>
        public ActionResult LoanSummary(int idOfLoan)
        {
            // search the loan

            // because of default lazy-loading one to many of Loan to Many Rates
            // won't include the rates, so explicitely tell EntityFramework to load everything.

            var loan = db.Loans.Include(r => r.Rates)
                .SingleOrDefault(b => b.IdLoan == idOfLoan);



                // I have the loan now give it to the View and also pass the carp employee name with a ViewBag so we do not need a ViewModel
                

            return View(loan);
        }

        /// <summary>  
        /// PrintLoanSummaryPDF
        /// 
        /// The following ActionResult takes the LoanSummaryPDF action and transforms it's output from HTML to PDF;
        /// 
        /// It always the requesting member and carp employee to have the document printed on paper after a loan request 
        /// from the this application.
        /// 
        /// </summary>  
        /// <returns>the view with the loan summary the rates and all CONVERTED TO PDF </returns>  
        public ActionResult PrintLoanSummaryAsPDF(int idOfLoan)
        {
            // Here we have the View itself, not the partial view, this one includes the website header and footer
            var report = new Rotativa.ActionAsPdf("LoanSummary", new { idOfLoan });



            // Here we have the partial view which only includes the effective PDF part
            //var loan = db.Loans.Include(r => r.Rates)
            //    .SingleOrDefault(b => b.IdLoan == idOfLoan);

            //var report = new Rotativa.PartialViewAsPdf("_LoanSummaryPDF", loan);
            return report;
        }
            
    }
}
