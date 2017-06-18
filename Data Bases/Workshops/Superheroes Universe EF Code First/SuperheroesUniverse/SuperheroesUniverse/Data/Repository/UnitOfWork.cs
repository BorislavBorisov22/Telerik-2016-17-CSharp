using SuperheroesUniverse.Data.Repository.Contracts;
using System;
using System.Data.Entity;

namespace SuperheroesUniverse.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Context cannot be null!");
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
