using SuperheroesUniverse.Data.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SuperheroesUniverse.Data.Repository
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> dbSet;
        private readonly DbContext context;

        public EfRepository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Passed context cannot be null!");
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> filterExpression)
        {
            var filtered = this.dbSet.Where(filterExpression);
            return filtered.ToList();
        }

        public void Deleted(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(int id)
        {
            var entity = this.dbSet.Find(id);
            return entity;
        }

        public void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
