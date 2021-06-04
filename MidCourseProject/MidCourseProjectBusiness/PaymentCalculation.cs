using MidCourseProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidCourseProjectBusiness
{
    public class PaymentCalculation
    {
        public static void CalculateTotalPay(Employee _employee, EmployeeClock _employeeClocks, DateTime cin, DateTime cout)
        {

            var difference = cin - cout;

            var totalMins = Math.Abs(difference.Minutes);
            var totalHours = Math.Abs(difference.Hours);

            var totalhourlyPay = (totalHours * _employee.HrRate);
            var totalMinDiv = totalMins / 60.0;
            var totalMinPay = (Decimal)totalMinDiv * _employee.HrRate;
            var totalPay = totalhourlyPay + totalMinPay;
            _employeeClocks.TotalPay = totalPay;
        }
    }
}
