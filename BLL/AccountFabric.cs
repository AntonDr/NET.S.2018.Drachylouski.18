using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BLL.Account;
using BLL.Interface.Interface;
using DAL.Interface.DTO;
using TypeOfAccount;

namespace BLL
{
    /// <summary>
    /// Fabric method pattern
    /// </summary>
    public class AccountFabric
    {
        public Account.Account Create(AccountHolder accountHolder, string id, TypeOfBankScore typeOfBankScore,Status status = Status.Open)
        {
            Account.Account account = null;

            switch (typeOfBankScore)
            {
                case TypeOfBankScore.Base:
                    accountHolder.AddAccount(id);
                    account =new BaseAccount(id, accountHolder);
                    account.Status = status;
                    return account;
                case TypeOfBankScore.Silver:
                    accountHolder.AddAccount(id);
                    account = new SilverAccount(id, accountHolder);
                    account.Status = status;
                    return account;
                case TypeOfBankScore.Gold:
                    accountHolder.AddAccount(id);
                    account = new GoldAccount(id, accountHolder);
                    account.Status = status;
                    return account;
                case TypeOfBankScore.Platinum:
                    accountHolder.AddAccount(id);
                    account = new PlatinumAccount(id, accountHolder);
                    account.Status = status;
                    account.Balance = 20;
                    return account;
                default:
                    throw new ArgumentException($"Invalid {nameof(typeOfBankScore)}");
            }
        }
    }
}
