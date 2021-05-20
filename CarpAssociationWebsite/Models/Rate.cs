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

        public double Amount { get; set; }

        [Display(Name = "Payment status")]
        public RateStatus PaymentStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDue { get; set; }

        public string Status { get; set; }


        // add the Loan who this rates belong to
        public int IdLoan { get; set; }
        public virtual Loan Loan { get; set; }
    }
}   