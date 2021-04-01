using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Loan Interest RATE")]
        public double Percentage { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }  
    }
}