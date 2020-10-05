using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NortB.Data.Core.MongoDb
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _collection;
        protected readonly IMongoDatabase Database;

        protected Repository(IContextFactory factory, string collection)
        {
            _collection = collection;
            Database = factory.GetMongoDatabase();
        }

        public abstract Task<int> Add(T item);

        public abstract Task Update(T item);

        public abstract Task Delete(int id);

        public async Task Delete(Expression<Func<T, bool>> expression)
        {
            await Database.GetCollection<T>(_collection).DeleteManyAsync(expression);
        }

        public async Task<T> Single(Expression<Func<T, bool>> expression)
        {
            var filter = Builders<T>.Filter.Where(expression);

            var item = await Database.GetCollection<T>(_collection).FindAsync(filter);
            return item.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> SelectMany(Expression<Func<T, bool>> expression)
        {
            var filter = Builders<T>.Filter.Where(expression);

            var items = await Database.GetCollection<T>(_collection).FindAsync(filter);
            return items.ToList();
        }

        public async Task Add(IEnumerable<T> items)
        {
            await Database.GetCollection<T>(_collection).InsertManyAsync(items);
        }

        public IQueryable<T> GetAllQueryable()
        {
            return Database.GetCollection<T>(_collection).AsQueryable();
        }
    }
}
