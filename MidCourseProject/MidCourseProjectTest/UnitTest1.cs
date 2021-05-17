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

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void WhenANewEmployeeIsAdded_TheNumberOfEmployeesIncreasesBy1()
        {
            employee.EmployeeId = "ghaza";
            employee.FirstName = "Hossain";
            employee.LastName = "Ghazal";
            employee.Address = "9 Baker Street";
            employee.City = "London";
            employee.PostCode = "W1 4DD";
            employee.PostCode = "None";
            employee.IsWorking = 1;
            employee.HrRate = (decimal)8.95;
            employee.PhoneNumber = "07439562751";
            employee.Password = "hello1234";

            using (var db = new HrDBContext())
            {
                var EmployeeCountBefore = db.Employees.Count();
                var i = manager.CreateEmployee(employee, out string message);
                var EmployeeCountAfter = db.Employees.Count();

                Assert.AreEqual(EmployeeCountBefore + 1, EmployeeCountAfter);
                Assert.AreEqual(message, "Save Successful");
            }
        }

        [Test]
        public void WhenAEmployeeDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new HrDBContext())
            {

            }
        }

        [Test]

        public void WhenAEmployeeIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new HrDBContext())
            {

            }
        }

    }
}