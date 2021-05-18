

# WPF-EF_Project

### Project Description

---------------------------------------------------------------------

The main purpose of this project is to work as a clock in/out an application for a small business where the "Employee" can create an "Account". This is then approved by the Admin. The employee is able to access the application after being confirmed to be working. And can select the clock in and out functionalities of the application to register their hours and get an idea of their total pay. Whilst Admins/Employers are able to view these details by seeing who has clocked on what day and time by selecting their employee. Employees personal details that they provided are visible to both Admin and Employee.



#### Project Goals

---------------------------------------------------

The project will be a 3 tier application consisting of:

* Model(Database)
* Business Logic(Code that interacts with your database and GUI)
* GUI(Graphical User Interface)

The MVP goals of the project are to successfully show both employer and employees their correct data. For example, if an employer wants to see how many hours an employee has done they can do so along with their pay. And the same goes for the employee which can also view their hours, pay and personal information.



Goals for expansion of some features are such:

* Requesting holidays
* Request for more shifts
* Employer able to see a calendar view of what employee is working when
* Employer able to set an amount on how many people can request a shift for the specific day

#### Class Diagram:

![Diagram](/Images/ClassDiagram/Diagram.png)



#### Project File Requirements & set up:

--------------------------------

If you want to download the repository you will need to download a few NuGet files on Visual studio for the different solutions.

* MidCourseProjectModel - these NuGet packages below handle database connections, migrations, scaffolding etc
  * Microsoft.EntityFrameworkCore (v5.0.5)
  * Microsoft.EntityFrameworkCore.SqlServer (v5.0.5)
  * Microsoft.EntityFrameworkCore.Tools (v5.0.5)
* MidCourseProjectWPF - these NuGet packages allows for the use of googles Material Design in your WPF application
  * MaterialDesignColors (v2.0.0)
  * MaterialDesignThemes (v4.0.0) - for a quick start guide on how to install features ([Click Here](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit/wiki/Super-Quick-Start))

`````sql
DROP TABLE IF exists Employee

CREATE TABLE Employee
(
	employeeID varchar(5) PRIMARY KEY,
	firstName varchar(MAX) NOT NULL,
	lastName varchar(MAX) NOT NULL,
	address varchar(MAX) NOT NULL,
	city varchar(MAX) NOT NULL,
	postCode varchar(10) NOT NULL,
	phoneNumber varchar(MAX) NOT NULL,
	position varchar(MAX) NOT NULL,
	isWorking integer NOT NULL,
	hrRate decimal(10,5) NOT NULL,
	password varchar(MAX) NOT NULL,
	employerID varchar(7) FOREIGN KEY REFERENCES Employer(employerID)
);

CREATE TABLE EmployeeClocks
(
	employeeClockID int IDENTITY(1,1) PRIMARY KEY,
	clockDate dateTime NOT NULL,
	clockIn DateTime,
	clockOut DateTime,
	totalPay decimal(10,5),
	employeeID varchar(5) FOREIGN KEY REFERENCES Employee(employeeID)
);

CREATE TABLE Employer
(
	employerID varchar(7) PRIMARY KEY, --Example 7 => Admin01
	firstName varchar(MAX) NOT NULL,
	lastName varchar(MAX) NOT NULL,
	password varchar(MAX) NOT NULL,
);
`````

After downloading the NuGet packages. Open Package manager and enter this: 

```c#
Scaffold-DbContext ['CONNECTION STRING FOUND IN DB'] Microsoft.EntityFrameworkCore.SqlServer -force
```



#### Sprint 1:

--------------------------------------------------

***Start of the day Kanban Board***

![initail_11_05_2021_first](/Images/Kanban/initail_11_05_2021_first.PNG)

***End of the day Kanban Board***

![11_05_2021_Second.](/Images/Kanban/11_05_2021_Second..PNG)



**Sprint 2 Goals**

- [x] 1.1
- [x] 1.2
- [x] 1.3
- [x] 1.4
- [x] 1.5
- [x] 1.6



***ERD - Database***

Here is a Entity relationship diagram of my database.

![MidCourse_Project](/Images/Database/MidCourse_Project.png)



#### Sprint Review

In this very first sprint I was able to finish all the tasks set out mainly getting the CRUD(Create, Read, Update, Delete) functionalities sorted and the creating the ERD or otherwise known as the entity relation diagram helping me to understand and break down the relations of the different tables and what columns are going to be needed in the database. I don't think this is the last iteration of this database. But so far it addresses the key aspects of the project and is able to store the core details. 

##### Sprint Retrospective

In this sprint I was able to get through it successfully without any delays or blockers affecting my work.

#### Sprint 2:

---------------------------------------

***Start of the day Kanban Board***

![11_05_2021_Second SPRINT](/Images/Kanban/11_05_2021_Second..PNG)

***End of the day Kanban Board*** 

![12_05_2021_second SPRINT](/Images/Kanban/12_05_2021_second.PNG)

**Sprint 2 Goals**

- [x] 1.1
- [x] 1.2
- [x] 1.3
- [x] 1.4
- [x] 1.5
- [x] 1.6



#### Sprint Review

In this second sprint I was able to finish all the tasks set out for the development of the Login window mainly the GUI and the business logic code which allows the employee to access the dashboard.  So now the employee can access the dashboard by either creating an account or login in directly if they already have an account. Once completed the sprint for today I focused on getting the readme document up to date and working on designs for the next sprint which is going to require more time do develop. 

##### Sprint Retrospective

I managed to work quickly on this sprint but I did run into a few issues that could have been avoided I had taken a bit more time to think about the possible use case of certain database fields. As a result I had to drop my tables as I noticed that by making my database primary keys auto increment I am unable to set them manually.  After that I was able recreate the tables and scaffold the database. 

I noticed that I had underestimated this sprint as I managed to finish it ahead of our evening reviews. I need to take into consideration on how long a feature may take and plan properly. Based on todays situation I can predict that I will be doing more than today in tomorrows sprint. 



#### Sprint 3:

---------------------------------------

***Start of the day Kanban Board***

![12_05_2021_second SPRINT](/Images/Kanban/12_05_2021_second.PNG)

***End of the day Kanban Board*** 

![13_05_2021_second SPRINT](/Images/Kanban/13_05_2021_second.PNG)

**Sprint 2 Goals**

- [x] Task 3
- [x] 1.1
- [x] 1.2
- [x] 1.3
- [x] 1.4
- [x] 1.5
- [x] 1.6



#### Sprint Review

In this third sprint I was able to finish all the tasks set out for the development such as the graphical user interface for the employee dashboard. The dashboard allows the user to interact with most feature of the application from one place. Manage to set up its functionalities in no time and by the end of the day I manged to finish the task. 

##### Sprint Retrospective

In this sprint I was able to get through it successfully without any delays or blockers affecting my work and I manged to work on some issues that affected the program and some string formatting issues.

#### Sprint 4:

---------------------------------------

***Start of the day Kanban Board***

![13_05_2021_second SPRINT](/Images/Kanban/13_05_2021_second.PNG)

***End of the day Kanban Board*** 

![14_05_2021_second](/Images/Kanban/14_05_2021_second.PNG)



**Sprint 2 Goals**

- [x] 1.1
- [x] 1.2
- [x] 1.3
- [x] 1.4
- [x] 1.5
- [x] 1.6



#### Sprint Review

In this fourth sprint I was able to finish the Admin half of the application. This consisted of setting up the GUI and database business logic fairly quickly as  I have now gained the experience and knowledge to make the right decisions regarding how the application is designed and developed. Now the Admin/Employer is able to interact and view the data needed in their dashboard. This was my final sprint but since I have some time before deadline I am able to use the time I have remaining on bug fixes and adding any small features that may help the application.

##### Sprint Retrospective

In this sprint I had no issues with developing the Admin side of the application. This is probably because most of the codes rely on one another and I was able to keep my code DRY so that I am not constantly repeating myself and causing unnecessary issues later down the line. But there are a few bugs that I have noticed which will be fixed.  

#### Remaining Tasks:

---------------------------------------

***Start of the day Kanban Board***

![14_05_2021_second](/Images/Kanban/14_05_2021_second.PNG)

***End of the day Kanban Board*** 

![15-16_05_2021_second](/Images/Kanban/15-16_05_2021_second.PNG)



**Sprint 2 Goals**

- [x] Task 4
- [x] Task 5



#### Task Review

In this final stages of the development I worked on mainly bug fixes that I may have missed which has helped me fix some things that I didn't realise during development and things that decided to leave towards the end such as fixing the hourly pay to be more accurate. Also I made sure to fix the clocking dates so that a user cannot have multiple clocking hours on the same day.



