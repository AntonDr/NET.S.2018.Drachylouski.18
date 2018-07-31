using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancAccountLogic.Account;

namespace BancAccountLogic.Mappers
{
    public static class BllFakeMappers
    {
        public static DalAccount ToDalAccount(this Account.Account account)
        {
            return new DalAccount()
            {
                Id = account.Id,
                AccounType = account.TypeOfBankScore,
                Banance = account.Balance,
                BonsuPoint = account.BonusPoints
            };
        }

        public static Account.Account ToBllAccount(this DalAccount dalAccount)
        {
            return new AccountFabric().Create(ToBllAccountHolder(dalAccount.DalAccountHolder), dalAccount.Id,
                dalAccount.AccounType);
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
