using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

// Todo: Add action which verifies that the CNP entered is correct

namespace CarpAssociationWebsite.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        public string PersonalIdentificationNumber { get; set; }

        [Required(ErrorMessage = "Phone number is required!")]
        [Range(10, 15)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Married")]
        public bool IsMarried { get; set; }

        [Required]
        public int NetIncome { get; set; }  

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter an address (eg: Street A, No. 99)")]
        public string Address { get; set; }
    }
}
