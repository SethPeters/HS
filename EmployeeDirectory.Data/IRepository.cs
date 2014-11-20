using System;
using System.Data.Entity;
using System.Linq;

namespace EmployeeDirectory.Data
{
    public interface IRepository<T>
     where T : class
    {
        DbSet<T> EntitySet { get; }

        IQueryable<T> Get();

        T GetByKey(params object[] id);

        void Add(T entity);

        void Update(T item);

        void Delete(object id);

        void Delete(T item);
    }
}