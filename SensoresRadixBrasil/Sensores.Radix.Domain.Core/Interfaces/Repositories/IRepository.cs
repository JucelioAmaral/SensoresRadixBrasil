using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sensores.Radix.Domain.Core.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity<T>
    {
        void Add(T obj);
        Task<T> GetByIdId(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<int> Count();
    }
}
