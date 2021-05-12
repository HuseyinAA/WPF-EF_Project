using System;
using System.Collections.Generic;

#nullable disable

namespace MidCourseProjectModel
{
    public partial class Employer
    {
        public Employer()
        {
            //Employees = new hashset of employee type
        }
        public int EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        //Make a list of Employees ICollection
    }
}
