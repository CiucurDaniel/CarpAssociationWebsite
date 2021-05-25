using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarpAssociationWebsite.ViewModels;

namespace CarpAssociationWebsite.Controllers
{
    public class StatisticsAndInformationDashboardController : Controller
    {
        // GET: StatisticsAndInformationDashboard
        public ActionResult StatisticsAndInformationDashboardIndex()
        {
            StatisticsAndInformationViewModel model = new StatisticsAndInformationViewModel
            {
                ActiveLoans = 4,
                ActiveEconomyAccounts = 10,
                TotalMoneyFromLoanInterestRateThisMonth = 10000.0M
            };
            return View(model);
        }
    }
}