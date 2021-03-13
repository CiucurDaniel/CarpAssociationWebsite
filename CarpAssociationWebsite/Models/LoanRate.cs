using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpAssociationWebsite.Models
{
    public class LoanRate
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime DateDue { get; set; }
        public string Status { get; set; }  
    }
}