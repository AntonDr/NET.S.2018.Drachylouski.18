using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DAL.Interface;
using DAL.Interface.DTO;

namespace DAL
{
    public class AccountRepository : IRepository<DalAccount>
    {
        private List<DalAccount> datalList = new List<DalAccount>();
        //private List<AccountHolder> lastData = new List<AccountHolder>();

        public void Create(DalAccount item)
        {
            datalList.Add(item);
            //if (!lastData.Contains(item.Holder))
            //{
            //    lastData.Add(item.Holder);
            //}
        }

        public void Update(DalAccount item)
        {
            DalAccount account = GetById(item.Id);

            int index = datalList.IndexOf(account);

            datalList[index] = item;
        }

        public DalAccount GetById(string id)
        {
            return  datalList.Find(x => x.Id == id);          
        }
    }
}