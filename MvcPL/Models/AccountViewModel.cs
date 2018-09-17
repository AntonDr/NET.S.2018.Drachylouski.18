using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TypeOfAccount;

namespace MvcPL.Models
{
    public class AccountViewModel
    {

        public string AccountID { get; set; }

        public decimal Balance { get; set; }

        [Required]
        public TypeOfBankScore AccountType { get; set; }
        public Status AccountStatus { get; set; }
        public int BonsuPoint { get; set; }

        [Required]
        [DisplayName("First name")]
        [StringLength(15,MinimumLength = 2)]
        public string HolderFirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        [StringLength(20,MinimumLength = 2)]
        public string HolderLastName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string HolderEmail { get; set; }
    }
}