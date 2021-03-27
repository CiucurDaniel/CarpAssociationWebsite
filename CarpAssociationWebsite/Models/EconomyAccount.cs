using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    public class EconomyAccount
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] 
        public Member Member { get; set; }

        [Required]
        [Display(Name = "Total savings")]
        public float TotalSavings { get; set; }

        [Required] 
        [Display(Name = "Interest rate")]
        public float InterestRate { get; set; }  

        [Required]
        [Display(Name = "Date started")]
        public DateTime DateStarted { get; set; }

    }
}