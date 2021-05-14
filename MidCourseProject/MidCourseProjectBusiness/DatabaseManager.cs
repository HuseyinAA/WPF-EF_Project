using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MidCourseProjectModel;

namespace MidCourseProjectBusiness
{
    public class DatabaseManager
    {
        ///CRUD FUNCTIONALITIES HERE!
        
        public bool CreateCustomer(Employee emp, out string message)
        {
            // takes in emp and validates
            // checks and stores data into HrDBContext() through the db using keyword
            // returns true which passes the appliction to the next page
            bool re = false;
            using (var db = new HrDBContext())
            { 
                try
                {
                    db.Add(emp);
                    db.SaveChanges();
                    re = true;
                    message = "Save Successful";
                }
                catch (Exception error)
                {
                    message = error.Message;
                    re = false;
                }
            }
            //db.Customers.Add(newCustomer);
            //db.SaveChanges();

            return re;
        }

        public bool CreateCustomerClock(EmployeeClock empClock, out string message)
        {
            // takes in emp and validates
            // checks and stores data into HrDBContext() through the db using keyword
            // returns true which passes the appliction to the next page
            bool re = false;
            using (var db = new HrDBContext())
            {
                try
                {
                    db.Add(empClock);
                    db.SaveChanges();
                    re = true;
                    message = "Clocking times Added Successfully";
                }
                catch (Exception error)
                {
                    message = error.Message;
                    re = false;
                }
            }
            //db.Customers.Add(newCustomer);
            //db.SaveChanges();

            return re;
        }

        public void ChangePassword() // MIGHT NOT BET NEEDED
        {
            // 
        }

        public void UpdateCustomer(Employee emp) //Only password or 
        {
            // Passing an emp to the HrDBContext
        }

        public bool AdminUpdatingCustomer(string selectedID, Employee emp) //Only password or 
        {
            // Passing an emp to the HrDBContext
            // Admin updates customer poisition, IsWorking and Pay;
            bool isUpdatable = false;
            if (emp != null)
            {
                using (var db = new HrDBContext())
                {
                    //Selecting employee
                    var selectedEmployee = db.Employees
                        .Where(em => em.EmployeeId == selectedID).FirstOrDefault();
                    //Change to these:
                    selectedEmployee.IsWorking = emp.IsWorking;
                    selectedEmployee.Position = emp.Position;
                    selectedEmployee.HrRate = emp.HrRate;
                    //Save changes to DB
                    db.SaveChanges();
                    isUpdatable = true;
                }
            }
            else
            {
                isUpdatable = false;
            }
            return isUpdatable;
        }

        public void DeleteCustomer() //Remove customer - only Admin available
        {
            // 
        }

        public bool UpdateEmployeeClocks(int selectedID, EmployeeClock employeeClock, out string message)
        {
            bool isUpdatable = false;
            if(employeeClock != null)
            {
                using (var db = new HrDBContext())
                {
                    //Selecting employee
                    var selectedEmployeeClock = db.EmployeeClocks
                        .Where(em => em.EmployeeClockId == selectedID).FirstOrDefault();
                        //.Where(emc => emc.ClockDate == employeeClock.ClockDate).FirstOrDefault();
                    //Change to these:
                    selectedEmployeeClock.ClockDate = employeeClock.ClockDate;
                    selectedEmployeeClock.ClockIn = employeeClock.ClockIn;
                    selectedEmployeeClock.ClockOut = employeeClock.ClockOut;
                    selectedEmployeeClock.TotalPay = employeeClock.TotalPay;
                    //Save changes to DB
                    db.SaveChanges();
                    message = "Update successful!";
                    isUpdatable = true;
                }
            }
            else
            {
                message = "Update Failed";
                isUpdatable = false;
            }
            return isUpdatable;
        }



        //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- READ -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public List<Employee> RetrieveAll()
        {
            using (var db = new HrDBContext())
            {
                List<Employee> list = new List<Employee>();
                foreach (var item in db.Employees)
                {
                    list.Add(item);
                }
                return list;
            }
        }

        public void RetrieveSelected(string employeeID)
        {
            // 
        }

        public List<Employee> EmployerRetreiveEmployeeData()
        {
            using (var db = new HrDBContext())
            {
                //var selectedEmployeeClocks = db.EmployeeClocks.Where(e => e.EmployeeId == ID).Include(ec => ec.Employee).FirstOrDefault();
                return db.Employees.Include(ec => ec.EmployeeClocks).ToList();
                //return setEmpclock;
            }
        }

        //Only Selected Position will display -- position Filter
        public List<Employee> EmployerRetreiveEmployeeData_Positions(string ID, string position)
        {
            using (var db = new HrDBContext())
            {
                return db.Employees.Where(e => e.EmployeeId == ID).Where(p => p.Position == position).Include(ec => ec.EmployeeClocks).ToList();
            }
        }

        //Only Selected Name will display -- search Filter
        public List<Employee> EmployerRetreiveEmployeeData_Search(string ID, string search, out string message)
        {
            using (var db = new HrDBContext())
            {
                try
                {
                    message = "Success!";
                    return db.Employees.Where(e => e.EmployeeId == ID).Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search)).ToList();
                }
                catch (Exception error)
                {
                    message = error.Message;
                    return null;
                }
            }
        }

        public List<EmployeeClock> RetreiveEmployeeClocksData(string ID)
        {
            using (var db  = new HrDBContext())
            {
                //var selectedEmployeeClocks = db.EmployeeClocks.Where(e => e.EmployeeId == ID).Include(ec => ec.Employee).FirstOrDefault();
                return db.EmployeeClocks.Where(e => e.EmployeeId == ID).Include(ec => ec.Employee).OrderByDescending(d => d.ClockDate).ToList();
                //return setEmpclock;
            }
        }

        /////////////////////////////////////////////
        public List<EmployeeClock> RetrieveAllCustomers(string ID)
        {
            List<EmployeeClock> list = new List<EmployeeClock>();
            using (var db = new HrDBContext())
            {
                foreach (var i in db.EmployeeClocks)
                {
                    if(i.EmployeeId == ID)
                    {
                        list.Add(i);
                    }
                    
                }
                return list;
            }
        }
        /////////////////////////////////////////////
        
        public bool CheckLoginStatus(string ID, string password, out string message, out Employee employee, out Employer employer)
        {
            //Check to see if this.employeeID == employeeID && this.password == password
            bool logedin = false;
            using (var db = new HrDBContext())
            {
                var selectedEmployer = db.Employers.Where(em => em.EmployerId == ID).FirstOrDefault();
                var selectedEmployee = db.Employees.Where(e => e.EmployeeId == ID).FirstOrDefault();
                if (selectedEmployer == null && selectedEmployee != null)
                {
                    if (selectedEmployee.Password == password)
                    {
                        message = "Employee Login Successful";
                        logedin = true;
                        employee = selectedEmployee;//db.Employees.Find(employeeID);
                        employer = null;
                        return logedin;
                    }
                    else
                    {
                        message = "Please Check your username and password";
                        logedin = false;
                        employee = null;
                        employer = null;
                        return logedin;
                    }
                }
                else if (selectedEmployer != null && selectedEmployee == null) 
                {
                    if (selectedEmployer.Password == password)
                    {
                        message = "Admin Login Successful";
                        logedin = true;
                        employee = null;
                        employer = selectedEmployer;
                        return logedin;
                    }
                    else
                    {
                        message = "Please Check your username and password";
                        logedin = false;
                        employee = null;
                        employer = null;
                        return logedin;
                    }
                }
                else
                {
                    message = "Error Loging in";
                    logedin = false;
                    employee = null;
                    employer = null;
                    return logedin;
                }

            }
        }
    }
}
