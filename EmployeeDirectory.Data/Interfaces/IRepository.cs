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

        T Add(T item);

        T Update(T item);

        void Delete(object id);

        void Delete(T item);
    }
}