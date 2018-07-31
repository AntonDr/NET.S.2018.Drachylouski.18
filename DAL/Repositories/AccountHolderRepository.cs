using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.DTO;

namespace DAL.Repositories
{
    public class AccountHolderRepository : IRepository<DalAccountHolder>
    {
        private List<DalAccountHolder> datalList = new List<DalAccountHolder>();
        //private List<AccountHolder> lastData = new List<AccountHolder>();

        public void Create(DalAccountHolder item)
        {
            //datalList.Add(item);
            if (!datalList.Contains(item))
            {
                datalList.Add(item);
            }
            else
            {
                Update(item);
            }
        }

        //public bool Constains(AccountHolder item) => datalList.Contains(item);

        public void Update(DalAccountHolder item)
        {
            DalAccountHolder accountHolder = datalList.Find(x => item==x);

            int index = datalList.IndexOf(accountHolder);

            datalList[index] = item;
        }

        public DalAccountHolder GetById(string email)
        {
            return datalList.Find(x => x.Email == email);
        }
    }
}
