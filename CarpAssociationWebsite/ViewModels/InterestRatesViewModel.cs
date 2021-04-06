using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.ViewModels
{
    /// <summary>
    ///
    /// 
    /// InterestRatesViewModel
    /// ViewModel which contains interest rates for both
    /// - EconomyAccount
    /// - Loan(Rate)
    ///
    /// </summary>
    public class InterestRatesViewModel
    {
        public List<EconomyAccountInterest> CurrentEconomyAccountInterests { get; set; }
        public List<LoanRateInterest> CurrentLoanRateInterests { get; set; }   

        // new interest rates, in case user wants to add the new values

    }
}       