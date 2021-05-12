using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool CheckLoginStatus(string employeeID, string password, out string message, out Employee emp)
        {
            //Check to see if this.employeeID == employeeID && this.password == password
            bool logedin = false;
            using (var db = new HrDBContext())
            {
                var selectedEmployee = db.Employees.Where(e => e.EmployeeId == $"{employeeID}").FirstOrDefault();
                //Change selected customers city
                if (selectedEmployee.Password == password)
                {
                    message = "Login Successful";
                    logedin = true;
                    emp = selectedEmployee;//db.Employees.Find(employeeID);
                    return logedin;
                }
                else
                {
                    message = "Please Check your username and password";
                    logedin = false;
                    emp = null;
                    return logedin;
                }
                
            }
        }
    }
}
