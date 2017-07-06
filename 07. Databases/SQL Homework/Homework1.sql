use TelerikAcademy

--Write a SQL query to find all department names.
SELECT Name
FROM Departments

--Write a SQL query to find the salary of each employee.
SELECT 
	FirstName + ' ' + LastName AS Employee,
	Salary
FROM Employees

--Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + LastName AS [Employee Full Name]
FROM Employees

--Write a SQL query to find the email addresses of each employee (by his first and last name).
--Consider that the mail domain is telerik.com. Emails should look like "John.Doe@telerik.com".
--The produced column should be named "Full Email Addresses".
SELECT
	FirstName + ' ' + LastName AS Employee,
	FirstName + '.' + LastName + '@telerik.com' AS [Email Address]
FROM Employees

--Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary
FROM Employees

--Write a SQL query to find all information about the employees whose job title is "Sales Representative".
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'

--Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName + ' ' + LastName AS Employee 
FROM Employees
WHERE FirstName LIKE 'sa%'

--Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName + ' ' + LastName AS Employee
FROM Employees
WHERE LastName LIKE '%ei%'

--Write a SQL query to find the salary of all employees whose salary is in the range [20000 - 30000].
SELECT FirstName + ' ' + LastName AS Employee, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + LastName AS Employee, Salary
FROM Employees
WHERE Salary IN(25000, 14000, 12500, 23600)

--Write a SQL query to find all employees that do not have manager.
SELECT *
FROM Employees
WHERE ManagerID IS NULL

--Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT *
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--Write a SQL query to find the top 5 best paid employees.
SELECT TOP(5) *
FROM Employees
ORDER BY Salary DESC

--Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT *
FROM Employees
JOIN Addresses
	ON Employees.AddressID = Addresses.AddressID 

--Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT *
FROM Employees, Addresses
WHERE Employees.AddressID = Addresses.AddressID

--Write a SQL query to find all employees along with their manager.
SELECT
	e.FirstName + ' ' + e.LastName AS Employee,
	m.FirstName + ' ' + m.LastName AS Manager
FROM Employees AS e
JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID

--Write a SQL query to find all employees, along with their manager and their address.
--Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT
	e.FirstName + ' ' + e.LastName AS Employee,
	Addresses.AddressText AS [Employee Address],
	m.FirstName + ' ' + m.LastName AS Manager
FROM Employees AS e
JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
JOIN Addresses
	ON e.AddressID = Addresses.AddressID

--Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

--Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager.
--Use right outer join.
SELECT *
FROM Employees AS e
LEFT JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID

--Rewrite the query to use left outer join.
SELECT *
FROM Employees AS m
RIGHT JOIN Employees AS e
	ON e.ManagerID = m.EmployeeID

--Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT 
	FirstName + ' ' + LastName AS Employee, 
	Departments.Name AS Department, 
	HireDate
FROM Employees
JOIN Departments
	ON Employees.DepartmentID = Departments.DepartmentID
WHERE 
	Departments.Name IN ('Sales', 'Finance') AND
	year(HireDate) BETWEEN 1995 AND 2005