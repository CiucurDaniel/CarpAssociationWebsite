using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    /// <summary>
    /// Interest Rate applied to Economy accounts
    /// this kind of interest rate is added by the employee
    /// and it changes only every year
    ///
    /// Example:
    /// 2021 -> 3.75% interest rate for economy accounts
    /// 2020 -> 20.00% interest rate for economy accounts
    /// </summary>
    public class EconomyAccountInterest
    {
        public int Id { get; set; }
        public float Percentage { get; set; }
        public DateTime Date { get; set; }  
    }
}