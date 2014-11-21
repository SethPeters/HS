using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data.Entities
{
    public partial class Employee
    {
        public void AddExtraInfo(string dtlType, string dtlValue)
        {
            this.ExtraInfo.Add(new EmployeeExtra { EmployeeNo = this.EmployeeNo, ExtraDetailType = dtlType, ExtraDetailInfo = dtlValue });
        }
    }
}