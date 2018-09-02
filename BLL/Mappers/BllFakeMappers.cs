using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Account;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class BllToDllMappers
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
            return AccountFabric.Create(ToBllAccountHolder(dalAccount.DalAccountHolder), dalAccount.Id,
                dalAccount.AccountType,dalAccount.Balance,dalAccount.AccountStatus);
        }

        public static DalAccountHolder ToDalAccountHolder(this AccountHolder accountHolder)
        {
            return new DalAccountHolder()
            {
                FirstName = accountHolder.FirstName,
                LastName = accountHolder.LastName,
                Email = accountHolder.Email
            };
        }

        public static AccountHolder ToBllAccountHolder(this DalAccountHolder dalAccountHolder)
        {
            return new AccountHolder(dalAccountHolder.FirstName,dalAccountHolder.LastName,dalAccountHolder.Email);
        }

        public static AccountEntity ToAccountEntity(this Account.Account account)
        {
            return new AccountEntity()
            {
                Id = account.Id,
                AccountHolder = new AccountHolderEntity()
                {
                    Email = account.Holder.Email,
                    FirstName = account.Holder.FirstName,
                    LastName = account.Holder.LastName
                },
                AccountStatus = account.Status,
                AccountType = account.TypeOfBankScore,
                Balance = account.Balance,
                BonsuPoint = account.BonusPoints
            };
        }

        public static Account.Account ToBllAccount(this AccountEntity account)
        {
            return AccountFabric.Create(
                new AccountHolder(account.AccountHolder.FirstName, account.AccountHolder.LastName,
                    account.AccountHolder.Email), account.Id, account.AccountType, account.Balance,
                account.AccountStatus);
        }
    }
}
