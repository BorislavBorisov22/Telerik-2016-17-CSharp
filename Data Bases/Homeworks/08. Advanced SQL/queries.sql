--1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
-- Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName AS [Name], Salary
FROM Employees
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees)
ORDER BY FirstName

--2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% 
--higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName AS [Name], Salary
FROM Employees
WHERE Salary BETWEEN 
	(SELECT MIN(Salary) FROM Employees)
	AND (SELECT MIN(Salary) + MIN(Salary) * 0.1 FROM Employees)

--3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary
-- in their department
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], d.Name, e.Salary
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary =
	(SELECT MIN(Salary) FROM Employees
	WHERE e.DepartmentID = DepartmentID)

--4. Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average Salary in Department #1]
FROM Employees
WHERE DepartmentID = 1

--5. Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(SALARY) AS [Average Salaray for the Sales Department]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) AS [Number of employees from the sales department]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(ManagerID) AS [Number of employees without manager]
FROM Employees

--8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) - COUNT(ManagerID) AS [Number of employees without manager]
FROM Employees

--9. Write a SQL query to find all departments and the average salary for each of them.
SELECT AVG(e.Salary) AS [Average Salary], d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY [Average Salary] DESC

--10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS [Department],  t.Name AS [Town], COUNT(*) AS [Number of Employees]
FROM Employees e 
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name, d.Name

--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name. 
SELECT m.FirstName + ' ' + m.LastName AS [Name], COUNT(*) AS [Number of employees]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID 
GROUP BY m.FirstName  + ' ' + m.LastName
HAVING COUNT(*) = 5
ORDER BY m.FirstName + ' ' + m.LastName

--12. Write a SQL query to find all employees along with their managers.
-- For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName, e.LastName, ISNUll(m.FirstName, 'no manager') AS Manager
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
-- Use the built-in LEN(str) function.
SELECT FirstName + ' ' + LastName AS [Name]
FROM Employees
WHERE LEN(LastName) = 5

--14. Write a SQL query to display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds".
-- Search in Google to find how to format dates in SQL Server.
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:ms')

--15.Write a SQL statement to create a table Users. Users should have username, password,
-- full name and last login time.
--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users(
	UserID int IDENTITY,
	Username nvarchar(50) NOT NULL UNIQUE,
	Pass nvarchar(20) NOT NULL,
	FullName nvarchar(30) NOT NULL,
	LastLogin smalldatetime NOT NULL,
	CONSTRAINT PK_User PRIMARY KEY (UserID),
	CONSTRAINT [MinPasswordLengthConstraint] CHECK (LEN(Pass) >= 5)
)
GO

--16. Write a SQL statement to create a view that displays the users from the Users table that have been in 
--the system today.
CREATE VIEW [Users from today] AS
SELECT Username FROM Users
WHERE CONVERT(VARCHAR(10), LastLogin, 102) 
    = CONVERT(VARCHAR(10), GETDATE(), 102)
GO
-------
SELECT * FROM [Users from today]

--17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
CREATE TABLE Groups(
	GroupID int IDENTITY,
	Name nvarchar(50) NOT NULL UNIQUE,
	CONSTRAINT PK_Group PRIMARY KEY (GroupID)
)
GO

--18. Write a SQL statement to add a column GroupID to the table Users. 
    -- * Fill some data in this new column and as well in the `Groups table.
    -- * Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
 ALTER TABLE Users
 ADD GroupID int
 CONSTRAINT FK_Users_Groups
 FOREIGN KEY (GroupID)
 REFERENCES Groups(GroupID)
 GO

 -- 19.Write SQL statements to insert several records in the Users and Groups tables.
 INSERT INTO Groups VALUES 
 ('Mathematics'),
 ('Informatics'),
 ('Music')
 GO

 INSERT INTO Users VALUES
 ('Peturcho', '123456', 'Petur Petrov', '2015-10-10', 3),
 ('Asencho', '123456', 'Asencho Texito', '2016-09-03', 2)
 GO

--20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Username = 'AsenchoTaxito', FullName = 'Asen Ivanov'
WHERE Username = 'Asencho'

--21. Write SQL statements to delete some of the records from the Users and Groups tables
DELETE FROM Users
WHERE Username = 'Ivancho'

--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.

   -- * Combine the first and last names as a full name.
   -- * For username use the first letter of the first name + the last name (in lowercase).
   -- *	Use the same for the password, and NULL for last login time.

INSERT INTO Users
SELECT  LOWER(FirstName) + LOWER(LastName) AS [Username],
		LOWER(FirstName) + LOWER(LastName) AS [Pass],
		FirstName + ' ' + LastName AS [FullName],
		GETDATE() AS [LastLogin],
		1 AS [GroupID]
FROM Employees

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since
-- 10.03.2010.
UPDATE Users
SET Pass = NULL
WHERE LastLogin < '10.03.2010'

--24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE Users
WHERE Pass IS NULL

--25. Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, e.JobTitle, AVG(Salary) AS [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

--26. Write a SQL query to display the minimal employee salary by department and job title 
--    along with the name of some of the employees that take it.
SELECT e.FirstName, e.LastName, d.Name, e.JobTitle
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE SALARY = 
	(SELECT MIN(Salary) FROM Employees
	WHERE e.DepartmentID = DepartmentID)
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName

--27. Write a SQL query to display the town where maximal number of employees work
SELECT TOP 1 t.Name, COUNT(*) AS [Employees Count]
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Employees Count] DESC

--28. Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(*) AS [Managers Count]
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON t.TownID = a.TownID
WHERE EXISTS
	(SELECT * FROM Employees
	WHERE ManagerID = e.EmployeeID)
GROUP BY t.Name
ORDER BY [Managers Count] DESC


--29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
    --Don't forget to define identity, primary key and appropriate foreign key.
    --Issue few SQL statements to insert, update and delete of some data in the table.
    --Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
    --    For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours(
	WorkReportID int IDENTITY NOT NULL,
	EmployeeID int NOT NULL,
	ReportDate DATETIME NOT NULL,
	Task nvarchar(200) NOT NULL,
	Hours int NOT NULL,
	Comments nvarchar(250) NOT NULL,
	CONSTRAINT PK_WorkHours PRIMARY KEY(WorkReportID),
	CONSTRAINT FK_WorkHours_Employees
		FOREIGN KEY (EmployeeID)
		REFERENCES Employees(EmployeeID)
)
GO

INSERT INTO WorkHours VALUES
(1, GETDATE(), 'Work Work Work', 24, 'No comment'),
(3, GETDATE(), 'Work Work Work', 10, 'Some comment')


CREATE TABLE WorkHoursLogs(
	WorkHourLogID int IDENTITY,
	EmployeeID int NOT NULL,
	ReportDate DATETIME NOT NULL,
	Task nvarchar(200) NOT NULL,
	Hours int NOT NULL,
	Comments nvarchar(250) NOT NULL,
	[Action] nvarchar(10) NOT NULL,
	CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(WorkHourLogID),
	CONSTRAINT FK_WorkHhoursLogs_Employees
		FOREIGN KEY(EmployeeID)
		REFERENCES Employees(EmployeeID),
	CONSTRAINT [WorkHoursReport valida operation] CHECK ([ACTION] IN ('Insert','Update','Delete', 'DeleteUpdate', 'InsertUpdate'))
)

GO 
CREATE TRIGGER TR_InsertWorkHourReport ON WorkHours FOR INSERT
AS 
INSERT INTO WorkHoursLogs 
SELECT EmployeeID, ReportDate, Task, Hours, Comments, 'Insert' AS [Action]
FROM inserted

GO

CREATE TRIGGER TR_DeleteWorkHourReport ON WorkHours FOR DELETE
AS 
INSERT INTO WorkHoursLogs 
SELECT EmployeeID, ReportDate, Task, Hours, Comments, 'Delete' AS [Action]
FROM deleted

GO 
CREATE TRIGGER TR_UpdateWorkHourRepore ON WorkHours FOR UPDATE
AS

INSERT INTO WorkHoursLogs
SELECT EmployeeID, ReportDate, Task, Hours, Comments, 'InsertUpdate' AS [Action]
FROM inserted 

INSERT INTO WorkHoursLogs
SELECT EmployeeID, ReportDate, Task, Hours, Comments, 'DeleteUpdate' AS [Action]
FROM deleted  
GO

INSERT INTO WorkHours VALUES
(1, '2015-10-10', 'Clean office', 3, 'Nothing to add'),
(1, '2017-11-11', 'Study SQL', 2, 'No comment')

DELETE WorkHours
WHERE Task = 'Clean office'

--30.Start a database transaction, delete all employees from the 'Sales' department along with all dependent 
-- records from the pother tables.
--At the end rollback the transaction.
BEGIN TRANSACTION

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
GO
DELETE FROM e
	FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

ROLLBACK TRANSACTION


--31.Start a database transaction and drop the table EmployeesProjects. 
BEGIN TRANSACTION
	DROP TABLE EmployeesProjects
ROLLBACK TRANSACTION

--32. Find how to use temporary tables in SQL Server.
-- Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and 
--  re-creating the table.
BEGIN TRANSACTION

SELECT * INTO #TempProjects
FROM Projects

DROP TABLE Projects

SELECT * INTO Projects
FROM #TempProjects

DROP TABLE #TempProjects

ROLLBACK TRANSACTION