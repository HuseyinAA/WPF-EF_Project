using NUnit.Framework;
using MidCourseProjectBusiness;
using MidCourseProjectModel;
using System.Linq;

namespace MidCourseProjectTest
{
    public class Tests
    {
        DatabaseManager databaseManager;
        [SetUp]
        public void Setup()
        {
            databaseManager = new DatabaseManager();
            // remove test entry in DB if present
            using (var db = new HrDBContext())
            {
                var selectedEmployees =
                from c in db.Employees
                where c.EmployeeId == "trkmj"
                select c;

                db.Employees.RemoveRange(selectedEmployees);
                db.SaveChanges();
            }
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void WhenANewEmployeeIsAdded_TheNumberOfCustomersIncreasesBy1()
        {
            using (var db = new HrDBContext())
            {

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