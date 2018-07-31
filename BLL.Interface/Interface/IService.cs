using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeOfAccount;
using AccountNumberGeneratorLogic;


namespace BLL.Interface.Interface
{
    public interface IService
    {
        void Deposite(string id,decimal value);
        void Withdraw(string id,decimal value);
        void OpenAccount(IAccountNumberGenerator id, IAccountHolder accountHolder, TypeOfBankScore typeOfBankScore);
        void CloseAccount(string id);
    }
}
