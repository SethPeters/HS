using EmployeeDirectory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data.Service
{
    public class DirectoryService : IDirectoryService
    {
        public DirectoryService(IRepository<Employee> empRepository, IRepository<Office> officeRepository)
        {
            EmployeeRepository = empRepository;
            OfficeRepository = officeRepository;
        }

        public Employee GetEmployee(int id)
        {
            return EmployeeRepository.GetByKey(id);
        }

        public IQueryable<Employee> GetEmployeesByFilter(Expression<Func<Employee, bool>> filter = null)
        {
            IQueryable<Employee> query = EmployeeRepository.Get();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = query.OrderBy(a => a.LastName).ThenBy(b => b.FirstName);
            return query;
        }

        public Employee AddEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException();
            }
            return EmployeeRepository.Add(emp);
        }

        public Employee UpdateEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException();
            }
            return EmployeeRepository.Update(emp);
        }

        public void DeleteEmployee(int id)
        {
            EmployeeRepository.Delete(id);
        }

        public IQueryable<Office> GetOffices()
        {
            return OfficeRepository.Get();
        }

        protected IRepository<Employee> EmployeeRepository { get; set; }

        protected IRepository<Office> OfficeRepository { get; set; }
    }
}