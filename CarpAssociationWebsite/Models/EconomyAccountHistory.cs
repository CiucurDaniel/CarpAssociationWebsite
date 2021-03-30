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
        public int MemberId { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
    }
}   