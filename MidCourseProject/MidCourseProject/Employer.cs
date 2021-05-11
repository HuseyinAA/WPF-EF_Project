using System;
using System.Collections.Generic;

#nullable disable

namespace MidCourseProject
{
    public partial class Employer
    {
        public int EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
