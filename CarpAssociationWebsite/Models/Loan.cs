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
        [Display(Name = "3 rates")]
        ThreeRates = 3,

        [Display(Name = "6 rates")]
        SixRates = 6,

        [Display(Name = "12 rates")]
        TwelveRates = 12,

        [Display(Name = "24 rates")]
        TwentyFourRates = 24,

        [Display(Name = "36 rates")]
        ThirtySixRates = 36
    }
    

    public enum LoanStatus
    {
        Ongoing,
        Finalized   
    }


    public class Loan   
    {
        [Key]
        [ForeignKey("Member")]
        public int IdLoan { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } 

        [Required]
        [Range(500.00, 15000.00, ErrorMessage = "Maximum {0} is between {1} and {2}")]
        public decimal Amount { get; set; }

        // Remaining/Balance
        [Display(Name = "Current balance")]
        public decimal Balance { get; set; }

        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }
        // rata se calculeaza la soldul curent (la balance din Loan)

        [Required]
        [Display(Name = "Number of rates")]
        public NumberOfRates NumberOfRates { get; set; }

        public LoanStatus Status { get; set; }


        /// <summary>
        /// Relationship configurations bellow
        /// </summary>

        // add this for one to one relationship between member and loan
        public virtual Member Member { get; set; }

        //add one to many Rate that the loan has
        public List<Rate> Rates { get; set; }

    }
}