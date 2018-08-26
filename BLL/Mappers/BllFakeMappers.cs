using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Account;

namespace BLL.Mappers
{
    public static class BllFakeMappers
    {
        public static DalAccount ToDalAccount(this Account.Account account)
        {
            return new DalAccount()
            {
                Id = account.Id,
                AccountStatus = account.Status,
                AccountType = account.TypeOfBankScore,
                Balance = account.Balance,
                BonsuPoint = account.BonusPoints,
                DalAccountHolder = ToDalAccountHolder(account.Holder)
            };
        }

        public static Account.Account ToBllAccount(this DalAccount dalAccount)
        {
            return new AccountFabric().Create(ToBllAccountHolder(dalAccount.DalAccountHolder), dalAccount.Id,
                dalAccount.AccountType,dalAccount.AccountStatus);
        }

        public static DalAccountHolder ToDalAccountHolder(this AccountHolder accountHolder)
        {
            return new DalAccountHolder()
            {
                FirstName = accountHolder.FirstName,
                LastName = accountHolder.LastName,
                Email = accountHolder.Email,
                ListId = accountHolder.listOfAccounts
            };
        }

        public static AccountHolder ToBllAccountHolder(this DalAccountHolder dalAccountHolder)
        {
            return new AccountHolder(dalAccountHolder.FirstName,dalAccountHolder.LastName,dalAccountHolder.Email,dalAccountHolder.ListId);
        }
    }
}
