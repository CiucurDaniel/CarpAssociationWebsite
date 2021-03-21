using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    /// <summary>
    ///
    /// Interest rate for a loan rate
    /// this loan rate is added monthly by the employee in the database
    ///
    /// Example:
    /// interest rate -> January 2020 -> 4.00%
    /// interest rate -> February 2020 -> 5.76%
    /// ...
    ///
    /// </summary>
    public class LoanRateInterest
    {
        public int Id { get; set; }
        public float Percentage { get; set; }
        public DateTime Date { get; set; }  
    }
}