using Microsoft.EntityFrameworkCore;
using Sensores.Radix.Domain.Core.Interfaces.Repositories;
using Sensores.Radix.Domain.Core.Interfaces;
using Sensores.Radix.Infra.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sensores.Radix.Domain.Core;

namespace Sensores.Radix.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity<T>
    {
        protected SensorEventContext Db;
        protected DbSet<T> DbSet;

        public Repository(SensorEventContext Context)
        {
            Db = Context;
            DbSet = Db.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate) => await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        public virtual async Task<IEnumerable<T>> GetAll() => await DbSet.AsNoTracking().ToListAsync();
        public virtual async Task<IEnumerable<T>> FromSql(string sqlQuery, object[] parameters) => await DbSet.FromSqlRaw<T>(sqlQuery).ToListAsync();
        public virtual async Task<T> GetByIdId(Guid id) => await DbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        public virtual async Task<int> Count() => await DbSet.CountAsync();
        public virtual async void Add(T obj) => await DbSet.AddAsync(obj);
        public virtual void Remove(int id) => DbSet.Remove(DbSet.Find(id));
        public virtual void Update(T obj) => DbSet.Update(obj);
        public virtual void Dispose() => Db.Dispose();

    }
}
