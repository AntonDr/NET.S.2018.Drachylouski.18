﻿namespace BLL.Account
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Account" />
    public class SilverAccount:Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilverAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="accountHolder">The account holder.</param>
        public SilverAccount(string id, AccountHolder accountHolder) : base(id, accountHolder)
        {
        }

        /// <summary>
        /// Bonuses the сalculation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected override int BonusСalculation(decimal value)
        {
            return (int)(value * 0.03M + value * 0.3M );
        }

        /// <summary>
        /// Determines whether [is valid value] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is valid value] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsValidValue(decimal value)
        {
            return value >= -1000M;
        }
    }
}
