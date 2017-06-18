--1. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * FROM Departments

--2. Write a SQL query to find all department names.
SELECT Name FROM Departments

--3. Write a SQL query to find the salary of each employee.
SELECT Salary FROM Employees

--4. Write a SQL to find the full name of each employee.
SELECT FirstName + ' '  + LastName AS [Full Name]
FROM Employees

--5. Write a SQL query to find the email addresses of each employee (by his first and last name).
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com".
-- The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' as [Full Email Addresses]
FROM Employees

--6. Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary FROM Employees

--7. Write a SQL query to find all different employee salaries.
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--8. Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName
FROM Employees
WHERE FirstName LIKE 'SA%'

--9. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--10. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT FirstName, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--11. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);	

--12. Write a SQL query to find all employees that do not have manager.
SELECT FirstName, LastName, ManagerID
FROM Employees
WHERE ManagerID IS NULL

--13. Write a SQL query to find all employees that have salary more than 50000.
-- Order them in decreasing order by salary.
SELECT FirstName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--14. Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 * FROM Employees
ORDER BY Salary DESC

--15. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName, e.LastName, a.AddressText
FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID

--16. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.firstName, e.LastName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--17. Write a SQL query to find all employees along with their manager.
SELECT e.firstName AS [Employee], m.FirstName AS [Manager]
FROM Employees e
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--18. Write a SQL query to find all employees, along with their manager and their address.
-- Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName AS [Employee], m.FirstName AS [MANAGER], a.AddressText as [Address]
FROM Employees e 
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses a
ON e.AddressID = a.AddressID

--19. Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

--20. Write a SQL query to find all the employees and the manager for each of them along with the employees
-- that do not have manager. Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName AS [Employee], m.FirstName AS [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID
------------------------------
SELECT e.FirstName AS [Employee], m.FirstName AS [Manager]
FROM Employees m
RIGHT OUTER JOIN Employees e
ON e.ManagerID = m.EmployeeID

--21. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance"
-- whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], d.Name, e.HireDate
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' or d.Name = 'Finance') AND (DATEPART(YEAR,e.HireDate) BETWEEN 1997 AND 2005)
