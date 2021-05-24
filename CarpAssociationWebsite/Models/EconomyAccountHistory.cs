using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    public enum TransactionType
    {
        Depose,
        Withdraw    
    }
    public class EconomyAccountHistory
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public EconomyAccount EconomyAccount { get; set; }   
        public TransactionType TransactionType { get; set; }    
        public int MemberId { get; set; } // TODO: REMOVE
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        // improve with more details regarding events
    }
}   