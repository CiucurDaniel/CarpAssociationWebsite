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
        [ForeignKey("Member")]
        public int EconomyAccountId { get; set; }

        public virtual Member Member { get; set; }

        [Required]
        [Display(Name = "Total savings")]
        public float TotalSavings { get; set; }

        [Required]
        [Display(Name = "Date started")]
        public DateTime DateStarted { get; set; }

    }
}