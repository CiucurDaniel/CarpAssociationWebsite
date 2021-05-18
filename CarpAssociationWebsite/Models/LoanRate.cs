using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    public enum LoanRateStatus
    {
        Paid,
        WaitingPayment
    }
    public class LoanRate
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public double Amount { get; set; }

        [Display(Name = "Interest Rate")]
        public float InterestRate { get; set; }
        // rata se calculeaza la soldul curent (la balance din Loan)

        [Display(Name = "Payment status")]
        public LoanRateStatus PaymentStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDue { get; set; }


        public string Status { get; set; }  
    }
}   