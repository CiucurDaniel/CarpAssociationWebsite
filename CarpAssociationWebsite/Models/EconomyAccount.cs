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
        [Key]
        [ForeignKey("Member")]
        public int EconomyAccountId { get; set; }

        [Required]
        [Display(Name = "Balance")]
        public float Balance { get; set; } 

        [Required]
        [Display(Name = "Date started")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStarted { get; set; }

        public virtual Member Member { get; set; }

        // TODO: Add another prop : bool Closed { get; set;}

        // might also need an enum instead of closed, and have a renew option
    }
}