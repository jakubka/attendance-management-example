using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Entities
{
    public enum PassTypeEnum
    {
        Arrive,
        Leave
    }

    public class Pass
    {
        public int Id { get; set; }

        public DateTime Time { get; set;}

        public PassTypeEnum Type { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
