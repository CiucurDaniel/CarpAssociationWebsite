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
        public int TotalNumberOfMembers { get; set; }


        public List<Member> Members { get; set; }
    }
}