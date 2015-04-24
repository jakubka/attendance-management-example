using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM.Web2.Models
{
    public class EmployeeDetailModel
    {
        public EmployeeModel Employee { get; set; }

        public TimeSpan TotalTimeAtWork { get; set; }
    }
}