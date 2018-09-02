using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure
{
    public static class MvcBLLMappers
    {
        public static AccountViewModel ToMvcAccount(this AccountEntity accountEntity)
        {
            return new AccountViewModel()
            {
                AccountID = accountEntity.Id,
                AccountStatus = accountEntity.AccountStatus,
                AccountType = accountEntity.AccountType,
                Balance = accountEntity.Balance,
                BonsuPoint = accountEntity.BonsuPoint,
                HolderEmail = accountEntity.AccountHolder.Email,
                HolderFirstName = accountEntity.AccountHolder.FirstName,
                HolderLastName = accountEntity.AccountHolder.LastName
            };
        }

        public static AccountEntity ToBllAccount(this AccountViewModel accountViewModel)
        {
            return new AccountEntity()
            {
                AccountHolder = new AccountHolderEntity()
                {
                    FirstName = accountViewModel.HolderFirstName,
                    Email = accountViewModel.HolderEmail,
                    LastName = accountViewModel.HolderLastName
                },
                AccountStatus = accountViewModel.AccountStatus,
                AccountType = accountViewModel.AccountType,
                Balance = accountViewModel.Balance,
                BonsuPoint = accountViewModel.BonsuPoint,
                Id = accountViewModel.AccountID
            };
        }
    }
}