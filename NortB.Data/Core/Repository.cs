using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NortB.Data.Entities;

namespace NortB.Data.Core
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _entities;
        public Repository(DbContext context)
        {
            this.Context = context;
            _entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }
        public T GetById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _entities.Add(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            T entity = _entities.SingleOrDefault(s => s.Id == id);
            _entities.Remove(entity ?? throw new InvalidOperationException());
            Context.SaveChanges();
        }
    }
}