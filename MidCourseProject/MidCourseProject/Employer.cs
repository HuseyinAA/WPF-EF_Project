using System;
using System.Collections.Generic;

#nullable disable

namespace MidCourseProjectModel
{
    public partial class Employer
    {
        public Employer()
        {
            Employees = new HashSet<Employee>();
        }

        public string EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
