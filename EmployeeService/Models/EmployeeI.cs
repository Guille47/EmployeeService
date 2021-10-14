using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Models
{
    public class Employee
    {
        public long UserId { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
   
}
