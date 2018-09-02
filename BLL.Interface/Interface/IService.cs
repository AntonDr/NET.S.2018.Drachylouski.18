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
        void OpenAccount(IAccountNumberGenerator id, IAccountHolder accountHolder, TypeOfBankScore typeOfBankScore);
        void CloseAccount(string id);
    }
}
