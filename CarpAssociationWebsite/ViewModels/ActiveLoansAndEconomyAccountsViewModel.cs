using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.ViewModels
{
    public class ActiveLoansAndEconomyAccountsViewModel
    {

        public List<Loan> Loans { get; set; }


        public List<EconomyAccount> EconomyAccounts { get; set; }

    }
}
