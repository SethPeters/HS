using EmployeeDirectory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDirectory.Data
{
    internal interface IOfficeDataRepository
    {
        Office GetOffice(string locId);

        IQueryable GetOfficeList();

        bool Add(Office office);

        bool Update(Office office);

        bool Delete(Office office);
    }
}