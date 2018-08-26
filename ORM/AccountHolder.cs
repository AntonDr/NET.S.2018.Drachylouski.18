using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class AccountHolder
    {
        public AccountHolder()
        {
            Accounts = new List<Account>();
        }

        public int AccountHolderId { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}