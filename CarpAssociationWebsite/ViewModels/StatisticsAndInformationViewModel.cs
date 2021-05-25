using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.ViewModels
{
    public class StatisticsAndInformationViewModel
    {
        public int ActiveLoans { get; set; }
        public int ActiveEconomyAccounts { get; set; }

        // public int NewMembersThisMonth { get; set; } i cannot do this because I do not have Date Joined on member

        public int TotalMoneyFromLoanInterestRateThisMonth { get; set; }

        // public int TotalNumberOfMembers { get; set; } we get this from List<Memebers> members

        public List<Member> Members { get; set; }
    }
}