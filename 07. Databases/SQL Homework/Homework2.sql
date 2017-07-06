use TelerikAcademy

--Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--Use a nested SELECT statement.
SELECT
	FirstName,
	LastName,
	Salary
FROM Employees
WHERE Salary =
	(SELECT Min(Salary) FROM Employees)

--Write a SQL query to find the names and salaries of the employees that have a salary,
--that is up to 10% higher than the minimal salary for the company.
SELECT
	FirstName,
	LastName,
	Salary
FROM Employees
WHERE Salary <
((SELECT Min(Salary) FROM Employees) * 1.1)
ORDER BY Salary

--Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--Use a nested SELECT statement.
SELECT
	FirstName,
	LastName,
	Salary,
	d.Name AS Department
FROM Employees AS e
JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary)
	FROM Employees 
	WHERE DepartmentID = e.DepartmentID)

--Write a SQL query to find the average salary in the department #1.
SELECT 
	AVG(Salary) AS [Average Salary in Department #1]
FROM Employees
WHERE DepartmentID = 1

--Write a SQL query to find the average salary in the "Sales" department.
SELECT 
	AVG(Salary) AS [Average Salary in "Sales" Department]
FROM Employees
JOIN Departments
	ON Employees.DepartmentID = Departments.DepartmentID
WHERE Departments.Name = 'Sales'

--Write a SQL query to find the number of employees in the "Sales" department.
SELECT 
	Count(*) AS [Employees in "Sales" Department]
FROM Employees
JOIN Departments
	ON Employees.DepartmentID = Departments.DepartmentID
WHERE Departments.Name = 'Sales'

--Write a SQL query to find the number of all employees that have manager.
SELECT 
	Count(*) AS [Employees with Manager]
FROM Employees
WHERE ManagerID IS NOT NULL

--Write a SQL query to find the number of all employees that have no manager.
SELECT 
	Count(*) AS [Employees with no Manager]
FROM Employees
WHERE ManagerID IS NULL

--Write a SQL query to find all departments and the average salary for each of them.
SELECT
	DepartmentID,
	AVG(Salary) AS [Average Salary]
FROM Employees
GROUP BY DepartmentID

--Write a SQL query to find the count of all employees in each department and for each town.
SELECT
	Departments.Name,
	Towns.Name,
	COUNT(*) AS Count
FROM Employees
JOIN Departments
	ON Employees.DepartmentID = Departments.DepartmentID
JOIN Addresses
	ON Employees.AddressID = Addresses.AddressID
JOIN Towns
	ON Addresses.TownID = Towns.TownID
GROUP BY 
	Towns.Name,
	Departments.Name

--Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT
	m.FirstName,
	m.LastName,
	COUNT(*) AS [Employee Count]
FROM Employees AS e
JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
GROUP BY 
	m.FirstName,
	m.LastName
HAVING COUNT(*) = 5

--Write a SQL query to find all employees along with their managers. 
	--For employees that do not have manager display the value "(no manager)".
SELECT
	e.FirstName + ' ' + e.LastName AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager]
FROM Employees AS e
LEFT JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID

--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT 
	LastName,
	LEN(LastName) AS LastNameLength
FROM Employees
WHERE LEN(LastName) = 5

--Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT
	FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:f') AS [Current DateTime]

--Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
	--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
	--Define the primary key column as identity to facilitate inserting records.
	--Define unique constraint to avoid repeating usernames.
	--Define a check constraint to ensure the password is at least 5 characters long.

--Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
	--Test if the view works correctly.

--Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
	--Define primary key and identity column.

--Write a SQL statement to add a column GroupID to the table Users.
	--Fill some data in this new column and as well in the `Groups table.
	--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

--Write SQL statements to insert several records in the Users and Groups tables.

--Write SQL statements to update some of the records in the Users and Groups tables.

--Write SQL statements to delete some of the records from the Users and Groups tables.

--Write SQL statements to insert in the Users table the names of all employees from the Employees table.
	--Combine the first and last names as a full name.
	--For username use the first letter of the first name + the last name (in lowercase).
	--Use the same for the password, and NULL for last login time.

--Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

--Write a SQL statement that deletes all users without passwords (NULL password).

--Write a SQL query to display the average employee salary by department and job title.

--Write a SQL query to display the minimal employee salary by department and job title 
--along with the name of some of the employees that take it.

--Write a SQL query to display the town where maximal number of employees work.

--Write a SQL query to display the number of managers from each town.

--Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
	--Don't forget to define identity, primary key and appropriate foreign key.
	--Issue few SQL statements to insert, update and delete of some data in the table.
	--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
		--For each change keep the old record data, the new record data and the command (insert / update / delete).

--Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
	--At the end rollback the transaction.

--Start a database transaction and drop the table EmployeesProjects.
	--Now how you could restore back the lost table data?

--Find how to use temporary tables in SQL Server.
	--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.