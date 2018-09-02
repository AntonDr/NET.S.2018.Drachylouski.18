using TypeOfAccount;

namespace BLL.Interface.Entities
{
    public  class AccountEntity
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public TypeOfBankScore AccountType { get; set; }
        public Status AccountStatus { get; set; }
        public int BonsuPoint { get; set; }
        public AccountHolderEntity AccountHolder { get; set; }
    }
}
