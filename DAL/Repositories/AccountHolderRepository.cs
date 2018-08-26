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
    public class AccountHolderRepository : IRepository<DalAccountHolder>
    {
        private readonly DbContext context;

        public AccountHolderRepository(DbContext uow)
        {
            this.context = uow;
        }

        public void Create(DalAccountHolder item)
        {
            var accountHolder = new AccountHolder()
            {
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                //ListAccount = item.ListId
            };

            var flagContains = context.Set<AccountHolder>().FirstOrDefault(x=> x.Email==item.Email);

            if (flagContains==null)
            {
                context.Set<AccountHolder>().Add(accountHolder);
            }
            else
            {
                Update(item);
            }

            context.SaveChanges();
        }

        public void Update(DalAccountHolder item)
        {
            //var accountHolderTemp = new AccountHolder()
            //{
            //    Email = item.Email,
            //    FirstName = item.FirstName,
            //    LastName = item.LastName,
            //    ListAccount = item.ListId
            //};

            var accountHolder = context.Set<AccountHolder>().FirstOrDefault(x => x.Email == item.Email);
            accountHolder.Email = item.Email;
            accountHolder.FirstName = item.FirstName;
            accountHolder.LastName = item.LastName;
            //accountHolder.ListAccount = item.ListId;

            context.Entry(accountHolder).State = EntityState.Modified;

            context.SaveChanges();
        }

        public DalAccountHolder GetById(string email)
        {
            var accountHolder = context.Set<AccountHolder>().FirstOrDefault(x => x.Email == email);

            return new DalAccountHolder()
            {
                Email = accountHolder.Email,
                FirstName = accountHolder.FirstName,
                LastName = accountHolder.LastName,
                //ListId = accountHolder.ListAccount
            };
        }
  
        public IEnumerable<DalAccountHolder> GetAll()
        {
            return context.Set<AccountHolder>().Select(accountHolder => new DalAccountHolder()
            {


                Email = accountHolder.Email,
                FirstName = accountHolder.FirstName,
                LastName = accountHolder.LastName,
                //ListId = accountHolder.ListAccount

            });
            
        }
    }
}

