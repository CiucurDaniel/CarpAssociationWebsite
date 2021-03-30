﻿using System;
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
        Closed
    }
    public class Loan   
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Member Member { get; set; }

        [Required]
        public DateTime StartDate { get; set; } 

        [Required]
        [Range(500.00, 15000.00, ErrorMessage = "Maximum {0} is between {1} and {2}")]
        public float Amount { get; set; }

        [Required]
        [Display(Name = "Number of rates")]
        public NumberOfRates NumberOfRates { get; set; }

        public IEnumerable<LoanRate> LoanRates { get; set; }

        public LoanStatus Status { get; set; }

    }
}