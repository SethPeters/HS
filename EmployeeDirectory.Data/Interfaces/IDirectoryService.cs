using EmployeeDirectory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeDirectory.Data
{
    public interface IDirectoryService
    {
        Employee GetEmployee(int id);

        IQueryable<Employee> GetEmployeesByFilter(Expression<Func<Employee, bool>> filter = null);

        Employee AddEmployee(Employee emp);

        Employee UpdateEmployee(Employee emp);

        void DeleteEmployee(int id);

        IQueryable<Office> GetOffices();
    }
}