using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidCourseProjectModel
{
    public class EmployeeService : IEmployeeService
    {
        //Our Serice is the middleman. Will allow us to interact with the database, taking
        //the dependency away from our business layer.
        private readonly HrDBContext _context;

        public EmployeeService(HrDBContext context)
        {
            _context = context;
        }

        //So our code doesn't break
        public EmployeeService()
        {
            _context = new HrDBContext();
        }

        public void CreateEmployee(Employee e)
        {
            _context.Employees.Add(e);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(string employeeId)
        {
            return _context.Employees.Find(employeeId);
        }

        public void RemoveEmployee(Employee employee)
        {
            _context.Employees.RemoveRange(employee);
            _context.SaveChanges();
        }

        public List<Employee> RetrieveAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public bool UpdatedEmployeePassword(string employeeId, Employee e)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(string employeeId, Employee e)
        {
            throw new NotImplementedException();
        }



        ///////////////////////////////////////////////////////////
        //// EmployeeClocks
        //////////////////////////////////////////////////////////

        public IQueryable<EmployeeClock> GetEmployeeClocksByEmployeeId_List(string employeeId)
        {
            return _context.EmployeeClocks.Where(ec => ec.EmployeeId == employeeId);
        }
        public void RemoveAllEmployeeClocks(IQueryable query)
        {
            _context.RemoveRange(query);
            _context.SaveChanges();
        }
    }
}
