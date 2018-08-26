using TypeOfAccount;

namespace DAL.Interface.DTO
{
    public struct DalAccount:IEntity
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public TypeOfBankScore AccountType { get; set; }
        public Status AccountStatus { get; set; }
        public int BonsuPoint { get; set; }
        public DalAccountHolder DalAccountHolder { get; set; }
    }
}
