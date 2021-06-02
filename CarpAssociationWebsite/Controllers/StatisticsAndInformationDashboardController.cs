using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarpAssociationWebsite.ViewModels;
using CarpAssociationWebsite.Models;
using CarpAssociationWebsite.DataAccessLayer;

namespace CarpAssociationWebsite.Controllers
{
    public class StatisticsAndInformationDashboardController : Controller
    {
        private readonly CarpAssociationWebsiteContext db = new CarpAssociationWebsiteContext();

        // GET: StatisticsAndInformationDashboard
        public ActionResult StatisticsAndInformationDashboardIndex()
        {
            List<Member> members = new List<Member>();

            members.AddRange(db.Members.ToList());

            StatisticsAndInformationViewModel model = new StatisticsAndInformationViewModel
            {
                ActiveLoans = 4,
                ActiveEconomyAccounts = 10,
                TotalMoneyFromLoanInterestRateThisMonth = 10000.0M,
                Members = members
            };
            return View(model);
        }
    }
}