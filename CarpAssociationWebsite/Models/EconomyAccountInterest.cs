using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Economy Interest RATE")]
        public float Percentage { get; set; }
        public DateTime Date { get; set; }  
    }
}