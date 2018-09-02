using System.Collections.Generic;
using TypeOfAccount;
using AccountNumberGeneratorLogic;
using BLL.Interface.Entities;


namespace BLL.Interface.Interface
{
    public interface IService
    {
        void Deposite(string id,decimal value);
        IEnumerable<AccountEntity> GetAll();
        void Withdraw(string id,decimal value);
        void OpenAccount(string firstName,string lastName,string email, TypeOfBankScore typeOfBankScore);
        void CloseAccount(string id);
    }
}
