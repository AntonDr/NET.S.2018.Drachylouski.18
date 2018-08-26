using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AccountNumberGeneratorLogic;
using BLL.Account;
using BLL.Interface;
using BLL.Interface.Interface;
using ExchangeRateNBRB.Model;
using Ninject;
using DependencyResolver;
using TypeOfAccount;

namespace BankAccountProgram
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.Configure();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<IService>();
            var generator = resolver.Get<IAccountNumberGenerator>();
           
            var holer = new AccountHolder("Anton","Drachylouski","djjadjajdj@gmail");
            service.OpenAccount(generator,holer, TypeOfBankScore.Gold);
            service.Deposite(1790601405.ToString(),120);




            //Service bankService = new Service(new AccountRepository());

            //AccountHolder accountHolder = new AccountHolder("Anton","Drachylouski","anton.drachylouski@gmail.com");

            //bankService.OpenAccount(new NumberGeneratorByHashCode(), accountHolder,TypeOfBankScore.Gold);

            //string id = accountHolder.ListOfAccounts.First();

            //bankService.Deposite(id,12882);

            //bankService.Withdraw(id,999m);

            //bankService.OpenAccount(new NumberGeneratorByHashCode(),accountHolder,TypeOfBankScore.Platinum);

            //id = accountHolder.ListOfAccounts.Last();

            //bankService.Withdraw(id,1200m);

            //bankService.CloseAccount(id);

            //AccountHolder accountHolder1 = new AccountHolder("Vova", "Sidorov", "vova.sidorov@mail.ru");

            //bankService.OpenAccount(new NumberGeneratorByHashCode(),accountHolder1,TypeOfBankScore.Base );

            //id = accountHolder1.ListOfAccounts.Last();

            //bankService.Deposite(id,11111111m);

            //bankService.CloseAccount(id);
        }
    }
}
