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
                ActiveLoans = db.Loans.Count(),
                ActiveEconomyAccounts = db.EconomyAccounts.Count(),
                TotalNumberOfMembers = db.Members.Count(),
                Members = members
            };
            return View(model);
        }
    }
}