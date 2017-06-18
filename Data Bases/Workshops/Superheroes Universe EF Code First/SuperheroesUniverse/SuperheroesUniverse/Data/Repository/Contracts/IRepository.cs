using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuperheroesUniverse.Data.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All(Expression<Func<T, bool>> filterExpression);

        void Add(T entity);

        void Deleted(T entity);

        void Update(T entity);

        T GetById(int id);
    }
}
