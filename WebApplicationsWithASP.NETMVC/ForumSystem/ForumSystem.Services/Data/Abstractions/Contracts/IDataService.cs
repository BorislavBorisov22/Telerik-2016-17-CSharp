using ForumSystem.Data.Models.Abstraction;
using System;
using System.Collections.Generic;

namespace ForumSystem.Services.Data.Abstractions.Contracts
{
    public interface IDataService<T> where T : DataModel
    {
        void Add(T entity);

        void Delete(T entity);

        void Delete(Guid id);

        T GetById(Guid Id);

        ICollection<T> GetAll();
    }
}
