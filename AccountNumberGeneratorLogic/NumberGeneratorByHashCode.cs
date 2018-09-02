using System;

namespace AccountNumberGeneratorLogic
{
    /// <summary>
    /// Number generator
    /// </summary>
    /// <seealso cref="AccountNumberGeneratorLogic.IAccountNumberGenerator" />
    public class NumberGeneratorByHashCode:IAccountNumberGenerator
    {
        /// <summary>
        /// Generates the account numbers.
        /// </summary>
        /// <returns></returns>
        public string GenerateAccountNumbers() => Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
    }
}
