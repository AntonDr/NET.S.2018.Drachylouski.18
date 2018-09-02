using System;
using System.Collections.Generic;
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
        public TypeOfBankScore AccountType { get; set; }
        public Status AccountStatus { get; set; }
        public int BonsuPoint { get; set; }
        public string HolderFirstName { get; set; }
        public string HolderLastName { get; set; }
        public string HolderEmail { get; set; }
    }
}