using System.Collections.Generic;
using System.Linq;
using NortB.Data.Entities;

namespace NortB.Data.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
