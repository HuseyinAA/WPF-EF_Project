using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidCourseProjectModel
{
    public interface IEmployeeService
    {
        public void CreateEmployee(Employee e);
        public Employee GetEmployeeById(string employeeId);
        public bool UpdateEmployee(string employeeId, Employee e);
        public bool UpdatedEmployeePassword(string employeeId, Employee e);
        public List<Employee> RetrieveAllEmployee();
        public void RemoveEmployee(Employee employee);


        public IQueryable<EmployeeClock> GetEmployeeClocksByEmployeeId_List(string employeeId);
        public void RemoveAllEmployeeClocks(IQueryable quary);

    }
}
