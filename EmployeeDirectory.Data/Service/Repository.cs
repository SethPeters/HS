using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data
{
    public class Repository<T> : EmployeeDirectory.Data.IRepository<T> where T : class
    {
        private DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<T>();
        }

        public DbSet<T> EntitySet { get; private set; }

        public virtual IQueryable<T> Get()
        {
            IQueryable<T> query = EntitySet;
            return query;
        }

        public virtual T GetByKey(params object[] id)
        {
            return EntitySet.Find(id);
        }

        public virtual T Add(T item)
        {
            EntitySet.Add(item);
            Context.SaveChanges();
            return item;
        }

        public virtual T Update(T item)
        {
            EntitySet.Attach(item);
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
            return item;
        }

        public virtual void Delete(object id)
        {
            T item = EntitySet.Find(id);
            Delete(item);
        }

        public virtual void Delete(T item)
        {
            if (Context.Entry(item).State == EntityState.Detached)
            {
                EntitySet.Attach(item);
            }
            EntitySet.Remove(item);
            Context.SaveChanges();
        }
    }
}