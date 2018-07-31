using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeOfAccount;

namespace DAL.Interface.DTO
{
    public class DalAccount
    {
        public string Id { get; set; }
        public decimal Banance { get; set; }
        public TypeOfBankScore AccounType { get; set; }
        public int BonsuPoint { get; set; }
        public DalAccountHolder DalAccountHolder { get; set; }
    }
}
