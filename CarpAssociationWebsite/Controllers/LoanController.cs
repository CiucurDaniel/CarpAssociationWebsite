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

                ViewBag.InterestRateLatest = latestInterestRate.Percentage;

                // First add the loan without the rates in order to obtain FK

                db.Loans.Add(loan);
                db.SaveChanges();

                // Now update the loan right afterwards - add the rates list to the loan

                int noOfRates = ConvertEnumRatesNumber(loan.NumberOfRates);

                var rates = CalculateRates(loan.Amount, loan.InterestRate, noOfRates, loan.StartDate);

                var result = db.Loans.SingleOrDefault(b => b.IdLoan == loan.IdLoan);
                if (result != null)
                {
                    result.Rates = rates;
                    db.SaveChanges();
                }

                // SqlException: Violation of PRIMARY KEY constraint 'PK_dbo.Loan'.
                // Cannot insert duplicate key in object 'dbo.Loan'. The duplicate key value is (1).

                // Here make a case for treating the error case when a user gives a loan to a member that already has a loan
                db.SaveChanges();

                return RedirectToAction("Index");
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

                rates.Add(rateToPay);
            }
            return rates;
        }
        

        public int ConvertEnumRatesNumber(NumberOfRates numberOfRates)
        {
            int noOfRates = 1;

            switch (numberOfRates)
            {
                case NumberOfRates.SixMonths:
                    noOfRates = 6;
                    break;

                case NumberOfRates.ThreeMonths:
                    noOfRates = 3;
                    break;

                case NumberOfRates.TwelveMonths:
                    noOfRates = 12;
                    break;

                case NumberOfRates.TwentyFourMonths:
                    noOfRates = 24;
                    break;

                case NumberOfRates.ThirtySixMonths:
                    noOfRates = 36;
                    break;

            }

            return noOfRates;
        }
    }
}
