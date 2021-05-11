using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidCourseProject;

namespace MidCourseProjectBusiness
{
    class DatabaseManager
    {
        ///CRUD FUNCTIONALITIES HERE!
        
        public bool CreateCustomer(Employee emp)
        {
            // takes in emp and validates
            // checks and stores data into HrDBContext() through the db using keyword
            // returns true which passes the appliction to the next page
            return false;
        }

        public void ChangePassword() // MIGHT NOT BET NEEDED
        {
            // 
        }

        public void UpdateCustomer(Employee emp) //Only password or 
        {
            // Passing an emp to the HrDBContext
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

        public bool CheckLoginStatus(string employeeID, string password)
        {
            //Check to see if this.employeeID == employeeID && this.password == password
            return false;
        }
    }
}
