using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    public enum NumberOfMonths
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
    

    public class EconomyAccount
    {
        [Key]
        [ForeignKey("Member")]
        public int EconomyAccountId { get; set; }

        [Required]
        [Display(Name = "Deposit Amount")]
        public decimal DepositAmount { get; set; } 

        [Required]
        [Display(Name = "Date started")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStarted { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public NumberOfMonths Duration { get; set; } 
        
        [Required]
        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }

        // How much the member will earn from Interest 
        [Required]
        [Display(Name = "Profit from interest")]
        public decimal ProfitFromInterest { get; set; }

        // The amount of money from ProfitFromInterest which are taxed, currently 10%
        [Required]
        [Display(Name = "Taxed Amount")]
        public decimal TaxedAmmount { get; set; }


        /// <summary>
        /// Relationship configrations bellow
        /// </summary>

        // add this for one to one relationship between member and loan
        public virtual Member Member { get; set; }

    }
}