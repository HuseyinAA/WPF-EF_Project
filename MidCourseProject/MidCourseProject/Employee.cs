using System;
using System.Collections.Generic;

#nullable disable

namespace MidCourseProjectModel
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeClocks = new HashSet<EmployeeClock>();
            Employers = new HashSet<Employer>();
        }

        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int IsWorking { get; set; }
        public decimal HrRate { get; set; }
        public string Password { get; set; }

        public virtual ICollection<EmployeeClock> EmployeeClocks { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
    }
}
