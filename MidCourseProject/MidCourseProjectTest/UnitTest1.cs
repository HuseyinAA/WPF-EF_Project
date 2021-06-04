using NUnit.Framework;
using MidCourseProjectBusiness;
using MidCourseProjectModel;
using System.Linq;

namespace MidCourseProjectTest
{
    public class Tests
    {
        DatabaseManager manager;
        Employee employee = new Employee();

        [SetUp]
        public void Setup()
        {
            manager = new DatabaseManager();
        }

        //[Ignore("Cannot be used simultaneous")]
        [Test]
        public void WhenANewEmployeeIsAdded_TheNumberOfEmployeesIncreasesBy1()
        {
            employee.EmployeeId = "ghaza";
            employee.FirstName = "Hossain";
            employee.LastName = "Ghazal";
            employee.Address = "9 Baker Street";
            employee.City = "London";
            employee.PostCode = "W1 4DD";
            employee.Position = "None";
            employee.IsWorking = 1;
            employee.HrRate = (decimal)8.95;
            employee.PhoneNumber = "07439562751";
            employee.Password = "hello1234";
            employee.EmployerId = "Admin01";

            using (var db = new HrDBContext())
            {
                var EmployeeCountBefore = db.Employees.Count();
                var i = manager.CreateEmployee(employee, out string message);
                var EmployeeCountAfter = db.Employees.Count();

                Assert.AreEqual(EmployeeCountBefore + 1, EmployeeCountAfter);
                Assert.AreEqual(message, "Save Successful");
            }
        }


        [Ignore("Cannot be used simultaneous")]
        [Test]
        public void AdminUpdatingEmployeeDetails_TheDatabaseIsUpdated()
        {
            employee.EmployeeId = "ghaza";
            employee.FirstName = "Hossain";
            employee.LastName = "Ghazal";
            employee.Address = "9 Baker Street";
            employee.City = "London";
            employee.PostCode = "W1 4DD";
            employee.Position = "Trainee"; //Updated 'None; -> 'Trainee'
            employee.IsWorking = 0; //Updated 1 - > 0
            employee.HrRate = (decimal)8.95;
            employee.PhoneNumber = "07439562751";
            employee.Password = "hello1234";
            employee.EmployerId = "Admin01";

            Employee emp = new Employee();

            using (var db = new HrDBContext())
            {
                manager.AdminUpdatingEmployee("ghaza", employee);
                var EmployeeUpdatedResult = db.Employees.Where(e => e.EmployeeId == "ghaza").FirstOrDefault();
                emp = EmployeeUpdatedResult;
            }
            Assert.AreEqual("Trainee", emp.Position);
            Assert.AreEqual(0, emp.IsWorking);
        }

        [Ignore("They cannot be ran at the same time")]
        [Test]
        public void RemovingEmployeeByAdmin_TheyAreNoLongerInTheDatabase()
        {
            employee.EmployeeId = "ghaza";
            employee.FirstName = "Hossain";
            employee.LastName = "Ghazal";
            employee.Address = "9 Baker Street";
            employee.City = "London";
            employee.PostCode = "W1 4DD";
            employee.Position = "None";
            employee.IsWorking = 0; //False
            employee.HrRate = (decimal)8.95;
            employee.PhoneNumber = "07439562751";
            employee.Password = "hello1234";
            employee.EmployerId = "Admin01";

            using (var db = new HrDBContext())
            {
                var EmployeeCountBefore = db.Employees.Count();
                manager.RemoveEmployee(employee.EmployeeId, employee.IsWorking, out int close);
                var EmployeeCountAfter = db.Employees.Count();

                Assert.AreEqual(EmployeeCountBefore - 1, EmployeeCountAfter);
                Assert.AreEqual(close, 1);
            }
        }

        //[Ignore("Cannot be used simultaneous")]
        //[TearDown]
        //public void TearDownEmployeeTest()
        //{
        //    using (var db = new HrDBContext())
        //    {
        //        manager.RemoveEmployee("ghaza", 0, out int close);
        //    }
        //}
    }
}