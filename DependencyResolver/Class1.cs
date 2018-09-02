using AccountNumberGeneratorLogic;
using BLL;
using BLL.Account;
using DAL.Interface;
using BLL.Interface.Interface;
using System.Data.Entity;
using DAL;
using DAL.Interface.DTO;
using DAL.Interface.Interface;
using DAL.Repositories;
using Ninject;
using Ninject.Web.Common;
using ORM;
using AccountHolder = BLL.Account.AccountHolder;

namespace DependencyResolver
{
    public static class ResolverConfig
    {


        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<IRepository<DalAccount>>().To<AccountRepository>();
            kernel.Bind<IRepository<DalAccountHolder>>().To<AccountHolderRepository>();
            kernel.Bind<IService>().To<Service>();
            kernel.Bind<IAccountNumberGenerator>().To<NumberGeneratorByHashCode>();
            //kernel.Bind<IAccountHolder>().To<AccountHolder>();
            kernel.Bind<DbContext>().To<EntityContext>().InRequestScope();
        }
    }

}
