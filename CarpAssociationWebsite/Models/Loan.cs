using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarpAssociationWebsite.Models;

namespace CarpAssociationWebsite.Models
{
    public enum NumberOfRates
    {
        [Display(Name = "3 months")]
        ThreeMonths = 3,

        [Display(Name = "6 months")]
        SixMonths = 6,

        [Display(Name = "12 months")]
        TwelveMonths = 12,

        [Display(Name = "24 months")]
        TwentyFourMonths = 24,

        [Display(Name = "36 months")]
        ThirtySixMonths = 36
    }


    public enum LoanStatus
    {
        Ongoing,
        Finalized   
    }


    public class Loan   
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLoan { get; set; }

        [Required]
        public Member Member { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } 

        [Required]
        [Range(500.00, 15000.00, ErrorMessage = "Maximum {0} is between {1} and {2}")]
        public double Amount { get; set; }

        // Remaining/Balance
        [Display(Name = "Current balance")]
        public double Balance { get; set; }

        [Display(Name = "Interest Rate")]
        public float InterestRate { get; set; }
        // rata se calculeaza la soldul curent (la balance din Loan)

        [Required]
        [Display(Name = "Number of rates")]
        public NumberOfRates NumberOfRates { get; set; }

        public LoanStatus Status { get; set; }


        //add one to many Rate that the loan has
        public List<Rate> Rates { get; set; }

    }
}