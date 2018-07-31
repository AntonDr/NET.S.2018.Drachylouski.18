using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BancAccountLogic.Account;
using BLL.Interface.Interface;
using DAL.Interface.DTO;
using TypeOfAccount;

namespace BancAccountLogic
{
    /// <summary>
    /// Fabric method pattern
    /// </summary>
    public class AccountFabric
    {
        /// <summary>
        /// Creates the specified account holder.
        /// </summary>
        /// <param name="accountHolder">The account holder.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="typeOfBankScore">The type of bank score.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">typeOfBankScore</exception>
        public Account.Account Create(AccountHolder accountHolder,string id,TypeOfBankScore typeOfBankScore)
        {
            switch (typeOfBankScore)
            {
                case TypeOfBankScore.Base:
                    accountHolder.AddAccount(id);
                    return new BaseAccount(id,accountHolder);
                case TypeOfBankScore.Silver:
                    accountHolder.AddAccount(id);
                    return new SilverAccount(id,accountHolder);
                case TypeOfBankScore.Gold:
                    accountHolder.AddAccount(id);
                    return new GoldAccount(id,accountHolder);
                case TypeOfBankScore.Platinum:
                    accountHolder.AddAccount(id);
                    return new PlatinumAccount(id,accountHolder);
                    default:
                        throw new ArgumentException($"Invalid {nameof(typeOfBankScore)}");
            }
        }
    }
}
