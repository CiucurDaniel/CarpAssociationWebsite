using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    public enum RateStatus
    {
        Paid,
        WaitingPayment
    }
    public class Rate
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRate { get; set; } 

        // Effective value of a rate 
        public decimal Amount { get; set; }

        // How much Interest is needed to be paid for the current rate
        public decimal AmountForInterest { get; set; }

        [Display(Name = "Payment status")]
        public RateStatus PaymentStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDue { get; set; }


        // add the Loan who this rates belong to
        public int IdLoan { get; set; }

        public virtual Loan Loan { get; set; }


        // Used for some Views like in PickRateToPay / RatePayment
        // to make a new column more easier than with Blazor
        [NotMapped]
        public decimal Total
        {
            get
            {
                return Amount + AmountForInterest;
            }
        }
    }
}   