using ForumSystem.Data.Models.Abstraction;
using ForumSystem.Data.Repositories;
using ForumSystem.Data.SaveContext;
using ForumSystem.Services.Data.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumSystem.Services.Data.Abstractions
{
    public class DataService<T> : IDataService<T>
        where T : DataModel
    {
        private readonly IEfRepository<T> repository;
        private readonly ISaveContext saveContext;

        public DataService(IEfRepository<T> repository, ISaveContext saveContext)
        {
            this.repository = repository;
            this.saveContext = saveContext;
        }

        public virtual void Add(T entity)
        {
            this.repository.Add(entity);
            this.saveContext.Commit();
        }

        public virtual void Delete(T entity)
        {
            this.repository.Delete(entity);
            this.saveContext.Commit();
        }

        public virtual void Delete(Guid id)
        {
            var targetEntity = this.repository.All.FirstOrDefault(x => x.Id == id);

            if (targetEntity == null)
            {
                throw new ArgumentNullException("No entity with the provided id was found!");
            }

            this.repository.Delete(targetEntity);
        }

        public T GetById(Guid Id)
        {
            var targetEntity = this.repository.All.FirstOrDefault(x => x.Id == Id);

            if (targetEntity == null)
            {
                throw new ArgumentNullException("No entity with the provided id was found!");
            }

            return targetEntity;
        }

        public virtual ICollection<T> GetAll()
        {
            return this.repository.All.ToList();
        }
    }
}
