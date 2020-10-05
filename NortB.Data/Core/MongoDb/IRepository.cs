using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NortB.Data.Core.MongoDb
{
    public interface IRepository<T> where T : class
    {
        Task Delete(Expression<Func<T, bool>> expression);

        Task Delete(int id);

        Task<T> Single(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> SelectMany(Expression<Func<T, bool>> expression);

        Task Add(IEnumerable<T> items);

        Task<int> Add(T item);

        Task Update(T item);

        IQueryable<T> GetAllQueryable();
    }
}