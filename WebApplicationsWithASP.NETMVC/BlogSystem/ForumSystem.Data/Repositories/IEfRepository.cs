using System.Linq;
using ForumSystem.Data.Models.Contracts;

namespace ForumSystem.Data.Repositories
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}