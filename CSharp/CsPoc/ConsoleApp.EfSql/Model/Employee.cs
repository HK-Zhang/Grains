using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime EmploymentStarted { get; set; }
        public int Salary { get; set; }
        public DateTime? LastPayRaise { get; set; }
    }
}
