using System;
using System.Collections.Generic;

#nullable disable

namespace MidCourseProjectModel
{
    public partial class EmployeeClock
    {
        public int EmployeeClockId { get; set; }
        public DateTime ClockDate { get; set; }
        public DateTime? ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
        public decimal? TotalPay { get; set; }
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
