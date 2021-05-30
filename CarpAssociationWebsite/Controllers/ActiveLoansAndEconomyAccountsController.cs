using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarpAssociationWebsite.ViewModels;
using CarpAssociationWebsite.DataAccessLayer;

namespace CarpAssociationWebsite.Controllers
{
    public class ActiveLoansAndEconomyAccountsController : Controller
    {
        private readonly CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: ActiveLoansAndEconomyAccounts
        public ActionResult ActiveLoansAndEconomyAccountsIndex()
        {
            // get economy accounts

            // TODO: Perform query to get Economy Accounts
            // var economyAccounts = db.EconomyAccounts.ToList();

            // get loans that are still ongoing  

            var loans = db.Loans.ToList();  // TODO: where status = Ongoing (now we get also the finalized loans)

            ActiveLoansAndEconomyAccountsViewModel loansAndEconomyAccountsViewModel = new ActiveLoansAndEconomyAccountsViewModel()
            {
                Loans = loans
            };
            return View(loansAndEconomyAccountsViewModel);
        }
    }
}