using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    public class Loan
    {   
        public int Id { get; set; }

        [Required]
        public Member Member { get; set; }

        public DateTime StartDate { get; set; } 

        [Required]
        [Range(500.00, 15000.00, ErrorMessage = "Maximum {0} is between {1} and {2}")]
        public float Amount { get; set; }

        [Required]
        [Display(Name = "Number of rates")]
        public int NumberOfRates { get; set; }

        public IEnumerable<LoanRate> LoanRates { get; set; }

    }
}