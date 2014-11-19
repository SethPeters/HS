using EmployeeDirectory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDirectory.Data
{
    internal interface IEmployeeDataRepository
    {
        Employee GetEmployee(int empId);

        IQueryable<Employee> GetEmployeeList();

        bool Update(Employee emp);

        bool Add(Employee emp);

        bool Delete(Employee emp);
    }
}