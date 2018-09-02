using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Interface;
using DAL.Interface.DTO;
using DAL.Interface.Interface;
using ORM;
using TypeOfAccount;

namespace DAL.Repositories
{
    public class AccountRepository : IRepository<DalAccount>
    {
        private readonly DbContext context;

        public AccountRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IEnumerable<DalAccount> GetAll()
        {
            return context.Set<Account>().ToArray().Select(account => new DalAccount()
            {
                Id = account.AccountID,
                Balance = account.Balance,
                AccountStatus = (Status) account.AccountStatus,
                AccountType = (TypeOfBankScore) account.AccountType,
                BonsuPoint = account.BonsuPoint,
                DalAccountHolder = new DalAccountHolder()
                {
                    Email = account.AccountHolder.Email,
                    FirstName = account.AccountHolder.FirstName,
                    LastName = account.AccountHolder.LastName
                }
            });

            
        }

        public DalAccount GetById(string key)
        { 
            var account = context.Set<Account>().FirstOrDefault(ormaccount => ormaccount.AccountID == key);
            //var accountHolder = context.Set<AccountHolder>().Where(x=> x.ID==account.ID);
            return new DalAccount()
            {
                Id = account.AccountID,
                Balance = account.Balance,
                AccountStatus = (Status) account.AccountStatus,
                AccountType = (TypeOfBankScore) Enum.ToObject(typeof(TypeOfBankScore), account.AccountType),
                BonsuPoint = account.BonsuPoint,
                DalAccountHolder = new DalAccountHolder()
                {
                    Email = account.AccountHolder.Email,
                    FirstName = account.AccountHolder.FirstName,
                    LastName = account.AccountHolder.LastName,
                
                }

            };
        }

        public void Create(DalAccount dalAccount)
        {


            var account = new Account
            {
                AccountID = dalAccount.Id,
                AccountStatus = (int) dalAccount.AccountStatus,
                AccountType = (int) dalAccount.AccountType,
                Balance = dalAccount.Balance,
                BonsuPoint = dalAccount.BonsuPoint,
                AccountHolder = new AccountHolder()
                {
                    Email = dalAccount.DalAccountHolder.Email,
                    FirstName = dalAccount.DalAccountHolder.FirstName,
                    LastName = dalAccount.DalAccountHolder.LastName,
                }
            };

            account.AccountHolder.Accounts.Add(account);
                

            context.Set<Account>().Add(account);
          
            context.SaveChanges();
        }

        public void Update(DalAccount item)
        {
            
            var account = context.Set<Account>().FirstOrDefault(ormaccount => ormaccount.AccountID == item.Id);

            account.AccountID = item.Id;
            account.AccountStatus = (int)item.AccountStatus;
            account.AccountType = (int)item.AccountType;
            account.Balance = item.Balance;
            account.BonsuPoint = item.BonsuPoint;

            context.Entry(account).State = EntityState.Modified;

            context.SaveChanges();
        }

    }
}