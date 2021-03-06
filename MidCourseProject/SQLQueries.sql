--DROP TABLE IF exists Employee

--CREATE TABLE Employee
--(
--	employeeID varchar(5) PRIMARY KEY,
--	firstName varchar(MAX) NOT NULL,
--	lastName varchar(MAX) NOT NULL,
--	address varchar(MAX) NOT NULL,
--	city varchar(MAX) NOT NULL,
--	postCode varchar(10) NOT NULL,
--	phoneNumber varchar(MAX) NOT NULL,
--	position varchar(MAX) NOT NULL,
--	isWorking integer NOT NULL,
--	hrRate decimal(10,5) NOT NULL,
--	password varchar(MAX) NOT NULL,
--	employerID varchar(7) FOREIGN KEY REFERENCES Employer(employerID)
--)

--CREATE TABLE EmployeeClocks
--(
--	employeeClockID int IDENTITY(1,1) PRIMARY KEY,
--	clockDate dateTime NOT NULL,
--	clockIn DateTime,
--	clockOut DateTime,
--	totalPay decimal(10,5),
--	employeeID varchar(5) FOREIGN KEY REFERENCES Employee(employeeID)
--)

--CREATE TABLE Employer
--(
--	employerID varchar(7) PRIMARY KEY, --Example 7 => Admin01
--	firstName varchar(MAX) NOT NULL,
--	lastName varchar(MAX) NOT NULL,
--	password varchar(MAX) NOT NULL,
--)

SELECT * FROM Employee

-----ADDING ADMIN
--INSERT INTO Employer (employerID, firstName, lastName, password)
--VALUES ('Admin01', 'Nishant', 'Mandal', 'Admin123'); 


-----Manual Update employee position and data
--UPDATE Employee
--SET position = 'Basic Staff', isWorking = 1
--WHERE employeeID = 'trkmj';

-----Manual Update employee position and data
--UPDATE EmployeeClocks
--SET employeeID = 'trkmj'
--WHERE employeeClockID = 1;

--DROP TABLE Employer;

--DROP TABLE EmployeeClocks;

--DROP TABLE Employee;

--- Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HrDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False' Microsoft.EntityFrameworkCore.SqlServer -force
-- Had to use this to show the amount i needed to fix