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

        public void ChangePassword() // MIGHT NOT BET NEEDED
        {
            // 
        }

        public void UpdateCustomer(Employee emp) //Only password or 
        {
            // Passing an emp to the HrDBContext
        }

        public void AdminUpdatingCustomer(Employee emp) //Only password or 
        {
            // Passing an emp to the HrDBContext
            // Admin updates customer poisition, IsWorking and Pay;
        }

        public void DeleteCustomer() //Remove customer - only Admin available
        {
            // 
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

        public List<Employee> JoiningEmployerWithEmployerClockToRetreiveData(string ID)
        {
            using (var db  = new HrDBContext())
            {
                //var selectedEmployeeClocks = db.EmployeeClocks.Where(e => e.EmployeeId == ID).Include(ec => ec.Employee).FirstOrDefault();
                return db.Employees.Where(e => e.EmployerId == ID).Include(ec => ec.EmployeeClocks).ToList();
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
