using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarpAssociationWebsite.DataAccessLayer;
using CarpAssociationWebsite.Models;
using CarpAssociationWebsite.ViewModels;

namespace CarpAssociationWebsite.Controllers
{
    public class InterestRatesDashboardController : Controller
    {
        private CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: InterestRatesDashboard
        public ActionResult InterestRateDashboardIndex()
        {
            // get the lists with the interest rates for loan and economy rates 

            List<LoanRateInterest> loanRateInterests =  db.LoanRateInterests.ToList();
            List<EconomyAccountInterest> economyAccountInterests = db.EconomyAccountInterests.ToList();

            // add them to the ViewModel

            InterestRatesViewModel interestRatesViewModel = new InterestRatesViewModel()
            {
                CurrentEconomyAccountInterests = economyAccountInterests,
                CurrentLoanRateInterests = loanRateInterests,
            };

            return View(interestRatesViewModel);
        }
    }
}