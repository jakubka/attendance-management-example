using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Entities
{
    public class Employee
    {
        public Employee()
        {
            Passes = new List<Pass>();
        }

        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Pass> Passes { get; set; }
    }
}
