using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManagementSystem.Tools;

namespace StaffManagementSystem.Model
{
    public class StaffInGrid
    {
        public string Id { get; set; }
              
        public string Name { get; set; }

        public EnumInGrid.sex Sex { get; set; }

        public EnumInGrid.department Department { get; set; }

        public string Salary { get; set; }

        public bool IsRetired { get; set; }
    }
}
