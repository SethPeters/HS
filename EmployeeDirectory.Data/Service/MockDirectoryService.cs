using EmployeeDirectory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data.Service
{
    public class MockDirectoryService : IDirectoryService
    {
        public Entities.Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetEmployeesByFilter(Expression<Func<Employee, bool>> filter = null)
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { FirstName = "Abby", LastName = "Smith", OfficeId = "HOUTX", Title = "VP" });
            list.Add(new Employee { FirstName = "Michael", LastName = "Smith", OfficeId = "HOUTX", Title = "Manager" });
            return list.AsQueryable();
        }

        public Entities.Employee AddEmployee(Entities.Employee emp)
        {
            throw new NotImplementedException();
        }

        public Entities.Employee UpdateEmployee(Entities.Employee emp)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.Office> GetOffices()
        {
            throw new NotImplementedException();
        }
    }
}