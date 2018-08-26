using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interface
{
    public interface IRepository<T>
    {
        T GetById(string id);
        void Create(T item);
        void Update(T item);
        IEnumerable<T> GetAll();
    }
}