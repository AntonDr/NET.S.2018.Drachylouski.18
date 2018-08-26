using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountNumberGeneratorLogic;
using BLL.Account;
using TypeOfAccount;
using BLL.Mappers;
using BLL.Interface;
using BLL.Interface.Interface;
using DAL.Interface;
using DAL.Interface.DTO;
using DAL.Interface.Interface;

namespace BLL
{
    /// <summary>
    /// Service for work with Bank account
    /// </summary>
    public class Service:IService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository<DalAccount> repositoryAccounts;

        private readonly IRepository<DalAccountHolder> repositoryAccountHolders;


        /// <summary>
        /// The fabric
        /// </summary>
        private AccountFabric fabric = new AccountFabric();

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public Service(IRepository<DalAccount> repository,IRepository<DalAccountHolder> repositoryAccountHolders)
        {
            this.repositoryAccounts = repository;
            this.repositoryAccountHolders = repositoryAccountHolders;
        }

        /// <summary>
        /// Deposites the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void Deposite(string id, decimal value)
        {

            var accountDal = repositoryAccounts.GetById(id);
            decimal temp = accountDal.Balance;

            var account = accountDal.ToBllAccount();

            if (account.Status!=Status.Open)
            {
               throw new ArgumentException($"{nameof(account)} is not-open account");
            }

            account.Deposite(value+temp);
            repositoryAccounts.Update(account.ToDalAccount());
        }

        /// <summary>
        /// Withdraws the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void Withdraw(string id, decimal value)
        {
            var accountDal = repositoryAccounts.GetById(id);
            decimal temp = accountDal.Balance;

            var account = accountDal.ToBllAccount();
            
            if (account.Status != Status.Open)
            {
                throw new ArgumentException($"{nameof(account)} is not-open account");
            }
            account.Withdraw(value+temp);
            repositoryAccounts.Update(account.ToDalAccount());
        }


        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="accountHolder">The account holder.</param>
        /// <param name="typeOfBankScore">The type of bank score.</param>
        private void OpenAccount(IAccountNumberGenerator id, AccountHolder accountHolder,TypeOfBankScore typeOfBankScore)
        {
            var account = fabric.Create(accountHolder, id.GenerateAccountNumbers(),typeOfBankScore);

            repositoryAccountHolders.Create(accountHolder.ToDalAccountHolder());

            repositoryAccounts.Create(account.ToDalAccount());
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void CloseAccount(string id)
        {
            var account = repositoryAccounts.GetById(id);

            if (account.AccountStatus == Status.Closed)
            {
                throw new ArgumentException($"{nameof(account)} already closed");
            }

            account.AccountStatus = Status.Closed;

            repositoryAccounts.Update(account);

        }


        public void OpenAccount(IAccountNumberGenerator id, IAccountHolder accountHolder,TypeOfBankScore typeOfBankScore)
        {
            OpenAccount(id,accountHolder as AccountHolder, typeOfBankScore);
        }
    }

}
