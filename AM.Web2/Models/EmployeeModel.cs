using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM.Web2.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 200)]
        public int Age { get; set; }
    }
}