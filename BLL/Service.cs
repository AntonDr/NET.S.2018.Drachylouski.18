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
using BLL.Interface.Entities;
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

        private readonly IAccountNumberGenerator numberGenerator;


        /// <summary>
        /// The fabric
        /// </summary>;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public Service(IRepository<DalAccount> repository,IRepository<DalAccountHolder> repositoryAccountHolders,IAccountNumberGenerator accountNumberGenerator)
        {
            this.repositoryAccounts = repository;
            this.repositoryAccountHolders = repositoryAccountHolders;
            this.numberGenerator = accountNumberGenerator;
        }

        /// <summary>
        /// Deposites the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void Deposite(string id, decimal value)
        {

            var account = repositoryAccounts.GetById(id).ToBllAccount();

            if (account.Status!=Status.Open)
            {
               throw new ArgumentException($"{nameof(account)} is not-open account");
            }

            account.Deposite(value);
            repositoryAccounts.Update(account.ToDalAccount());
        }

        public IEnumerable <AccountEntity> GetAll()
        {
            var temp = repositoryAccounts.GetAll();

            foreach (var item in temp)
            {
                yield return item.ToBllAccount().ToAccountEntity();
            }
        }

        /// <summary>
        /// Withdraws the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void Withdraw(string id, decimal value)
        {
            var account = repositoryAccounts.GetById(id).ToBllAccount();
                  
            if (account.Status != Status.Open)
            {
                throw new ArgumentException($"{nameof(account)} is not-open account");
            }

            account.Withdraw(value);
            repositoryAccounts.Update(account.ToDalAccount());
        }


        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="accountHolder">The account holder.</param>
        /// <param name="typeOfBankScore">The type of bank score.</param>
        public void OpenAccount(string firstName,string lastName,string email,TypeOfBankScore typeOfBankScore)
        {
            var accountHolder = new AccountHolder(firstName, lastName, email);

            var account = AccountFabric.Create(accountHolder, numberGenerator.GenerateAccountNumbers(),typeOfBankScore);

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


      
    }

}
