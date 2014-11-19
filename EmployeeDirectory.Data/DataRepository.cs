using EmployeeDirectory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data
{
    public class DataRepository : IEmployeeDataRepository, IOfficeDataRepository
    {
        public DataRepository(DataContext data)
        {
            DataContext = data;
        }

        private DataContext DataContext { get; set; }

        public Employee GetEmployee(int empId)
        {
            return DataContext.Employees.Where(x => x.EmployeeNo == empId).FirstOrDefault();
        }

        public IQueryable<Employee> GetEmployeeList()
        {
            return DataContext.Employees;
        }

        public bool Update(Employee emp)
        {
            throw new NotImplementedException();
        }

        public bool Add(Employee emp)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Employee emp)
        {
            throw new NotImplementedException();
        }

        public Office GetOffice(string locId)
        {
            return DataContext.Offices.Where(x => x.OfficeId == locId).FirstOrDefault();
        }

        public IQueryable GetOfficeList()
        {
            throw new NotImplementedException();
        }

        public bool Add(Office office)
        {
            throw new NotImplementedException();
        }

        public bool Update(Office office)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Office office)
        {
            throw new NotImplementedException();
        }
    }
}