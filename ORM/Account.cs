using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Account
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string AccountID { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public int AccountType { get; set; }

        [Required]
        public int AccountStatus { get; set; }

        [Required]
        public int BonsuPoint { get; set; }

        public virtual int? AccountHolderId { get; set; }
        public virtual AccountHolder AccountHolder { get; set; }
    }
}
